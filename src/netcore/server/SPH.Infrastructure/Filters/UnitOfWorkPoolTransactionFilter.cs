using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SPH.Infrastructure.Attributes;
using SPH.Infrastructure.UnitOfWork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SPH.Infrastructure.Filters
{
    public class UnitOfWorkPoolTransactionFilter : IActionFilter
    {
        protected IUnitOfWorkPool unitOfWorkPool;

        public UnitOfWorkPoolTransactionFilter(IUnitOfWorkPool _unitOfWorkPool)
        {
            unitOfWorkPool = _unitOfWorkPool;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Queue<IUnitOfWork> uowsQueue = new Queue<IUnitOfWork>();

            //check if transactions order was specified an order the UoWs by placing them in the queue
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var transactionOrderAttributes = descriptor.MethodInfo.GetCustomAttributes<TransactionOrderAttribute>(true)?.OrderBy(x => x.Order);
            if (transactionOrderAttributes != null)
            {
                //enqueue UoWs with specified order
                foreach (var orderAttribute in transactionOrderAttributes)
                    uowsQueue.Enqueue(unitOfWorkPool.Get(orderAttribute.UnitOfWorkKey));

                //enqueue the rest of uows
                IEnumerable<string> unordererUoWKeys = unitOfWorkPool.RegisteredUoWKeys.Where(x => !transactionOrderAttributes.Any(y => y.UnitOfWorkKey == x));
                foreach (string key in unordererUoWKeys)
                    uowsQueue.Enqueue(unitOfWorkPool.Get(key));
            }
            else
            {
                //enqueue all uows without ordering them
                foreach (var uow in unitOfWorkPool.GetAll())
                    uowsQueue.Enqueue(uow);
            }

            //try to commit the transactions in each unit of work or rollback when an exception occurrs
            while (uowsQueue.Count > 0)
            {
                var uow = uowsQueue.Dequeue();

                if (context.Exception != null)
                {
                    uow.Rollback();
                }
                else
                {
                    try
                    {
                        uow.Commit();
                    }
                    catch (Exception ex)
                    {
                        uow.Rollback();
                        context.Exception = ex;
                        context.Result = null;
                    }
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            //check if transactions isolation levels were specified for the request and if so, set them in appropriate Unit of Work
            var isolationLevelAttributes = descriptor.MethodInfo.GetCustomAttributes<TransactionIsolationLevelAttribute>(true);
            var globalIsolationLevelAttribute = isolationLevelAttributes?.SingleOrDefault(x => string.IsNullOrEmpty(x.UnitOfWorkKey));

            //set isolation level for all UoWs
            if (globalIsolationLevelAttribute != null)
            {
                var unitOfWorks = unitOfWorkPool.GetAll();
                foreach (var uow in unitOfWorks)
                    uow.SetIsolationLevel(globalIsolationLevelAttribute.Level);
            }

            //override the previously set isolation level for specific UoWs
            if (isolationLevelAttributes != null)
            {
                foreach (var attr in isolationLevelAttributes)
                {
                    var uow = unitOfWorkPool.Get(attr.UnitOfWorkKey);
                    uow.SetIsolationLevel(attr.Level);
                }
            }
        }
    }
}

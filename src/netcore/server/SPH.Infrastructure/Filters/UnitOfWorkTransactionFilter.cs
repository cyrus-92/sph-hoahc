using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SPH.Infrastructure.Attributes;
using SPH.Infrastructure.UnitOfWork.Core;
using System;
using System.Linq;
using System.Reflection;

namespace SPH.Infrastructure.Filters
{
    public class UnitOfWorkTransactionFilter : IActionFilter
    {
        protected IUnitOfWork unitOfWork;

        public UnitOfWorkTransactionFilter(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
                unitOfWork.Rollback();
            else
            {
                try
                {
                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                    context.Exception = ex;
                    context.Result = null;
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //check if transaction isolation level was specified for the request and if so, set it in Unit of Work
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var isolationLevelAttribute = descriptor.MethodInfo.GetCustomAttributes<TransactionIsolationLevelAttribute>(true).FirstOrDefault();
            if (isolationLevelAttribute != null)
                unitOfWork.SetIsolationLevel(isolationLevelAttribute.Level);
        }
    }
}

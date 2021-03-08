using System;
using System.Data;

namespace SPH.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TransactionIsolationLevelAttribute : Attribute
    {
        public IsolationLevel Level { get; set; }

        public string UnitOfWorkKey { get; set; }

        public TransactionIsolationLevelAttribute(IsolationLevel level)
        {
            Level = level;
        }

        public TransactionIsolationLevelAttribute(IsolationLevel level, string uowKey)
        {
            Level = level;
            UnitOfWorkKey = uowKey;
        }
    }
}

using System;
using System.Collections.Generic;

namespace SPH.Infrastructure.UnitOfWork.Core
{
    public class UnitOfWorkPool : IUnitOfWorkPool
    {
        protected readonly IServiceProvider serviceProvider;
        protected readonly UnitOfWorkPoolOptions options;

        public IEnumerable<string> RegisteredUoWKeys => options.RegisteredUoWs.Keys;

        public UnitOfWorkPool(IServiceProvider _serviceProvider, UnitOfWorkPoolOptions _options)
        {
            serviceProvider = _serviceProvider ?? throw new ArgumentNullException(nameof(_serviceProvider));
            options = _options ?? throw new ArgumentNullException(nameof(_options));
        }

        public IUnitOfWork Get(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (!options.RegisteredUoWs.ContainsKey(key))
                throw new ArgumentException("Unit of Work for the specified key is not registerd in the pool.", nameof(key));

            var uowType = options.RegisteredUoWs[key];
            return serviceProvider.GetService(uowType) as IUnitOfWork;
        }

        public IEnumerable<IUnitOfWork> GetAll()
        {
            foreach (var uowType in options.RegisteredUoWs)
                yield return serviceProvider.GetService(uowType.Value) as IUnitOfWork;
        }
    }
}

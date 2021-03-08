using System;
using System.Collections.Generic;

namespace SPH.Infrastructure.UnitOfWork.Core
{
    public class UnitOfWorkPoolOptions
    {
        public Dictionary<string, Type> RegisteredUoWs { get; set; } = new Dictionary<string, Type>();
    }
}

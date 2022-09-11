using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.Infrastructure
{
    public class DbFactory<DbContext> : IFactory<DbContext>
    {
        private readonly Func<DbContext> _factory;
        public DbFactory(Func<DbContext> factory)
        {
            _factory = factory;
        }
        public DbContext Create()
        {
            return _factory();
        }
    }
}

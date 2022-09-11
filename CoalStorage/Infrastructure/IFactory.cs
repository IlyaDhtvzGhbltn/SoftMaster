using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.Infrastructure
{
    public interface IFactory<out T>
    {
        T Create();
    }
}

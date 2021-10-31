using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.Interface
{
    public interface IRepository<T>
    {
        void Entry(T value);
    }
}

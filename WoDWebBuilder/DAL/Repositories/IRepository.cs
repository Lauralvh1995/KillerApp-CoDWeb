using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoDWebBuilder.DAL
{
    interface IRepository<T>
    {
        void Add(T item);
        void Refresh();
        void Update(T item);
        void Delete(T item);
    }
}

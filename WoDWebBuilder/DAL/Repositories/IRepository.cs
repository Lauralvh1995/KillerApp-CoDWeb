using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoDWebBuilder.DAL
{
    interface IRepository
    {
        void Add();
        void Refresh();
        void Update();
        void Delete();
    }
}

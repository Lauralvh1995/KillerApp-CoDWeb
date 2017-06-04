using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoDWebBuilder.Models;

namespace WoDWebBuilder.DAL
{
    interface IContext<T>
    {
        void Add();
        List<T> Read(int userid);
        void Update();
        void Delete();
    }
}

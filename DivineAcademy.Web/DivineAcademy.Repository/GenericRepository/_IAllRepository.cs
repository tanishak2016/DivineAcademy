using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Repository.GenericRepository
{
   public interface _IAllRepository<T> : IDisposable where T:class
    {
        IEnumerable<T> ExecuteQuery(String spQuery, object[] parameters);
        T ExecuteQuerySingle(String spQuery, object[] parameters);
        Task ExecuteCommand(String spQuery, object[] parameters);



    }
}

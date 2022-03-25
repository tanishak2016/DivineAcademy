using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Repository.GenericRepository
{
   public interface IRepository<T> : IDisposable where T:class
    {
        IEnumerable<T> ExecuteQuery(String spQuery);
        T ExecuteQuerySingle(String spQuery, object[] parameters);
        int ExecuteCommand(String spQuery, object[] parameters);



    }
}

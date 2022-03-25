using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivineAcademy.DataBase.Context;
using System.Data.Entity;

namespace DivineAcademy.Repository.GenericRepository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        //public static GenericRepository<T> Instance
        //{
        //    get
        //    {
        //        if (instance == null) instance = new GenericRepository<T>(new DivineDBContext());
        //        return instance;
        //    }
        //}

        //private static GenericRepository<T> instance { get; set; }



        DivineDBContext context = null;
        private DbSet<T> entities = null;

        public GenericRepository(DivineDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Insert/Update/Delete Data To Database
        /// <para>Use it when to Insert/Update/Delete data through a stored procedure</para>
        /// </summary>

        public int ExecuteCommand(string spQuery, object[] parameters)
        {

            int result = 0;
            try
            {
                using(context=new DivineDBContext())
                {
                   result = context.Database.SqlQuery<int>(spQuery, parameters).FirstOrDefault();
                  
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

           return result;


        }       


        /// <summary>
        /// Get Data From Database
        /// <para>Use it when to retive data through a stored procedure</para>
        /// </summary>
        public IEnumerable<T> ExecuteQuery(string spQuery)
        {
            
            using(context=new DivineDBContext())
            {
                return context.Database.SqlQuery<T>(spQuery).ToList();
            }
        }


        /// <summary>
        /// Get Single Data From Database
        /// <para>Use it when to retive single data through a stored procedure</para>
        /// </summary>

        public T ExecuteQuerySingle(string spQuery, object[] parameters)
        {
            using(context=new DivineDBContext())
            {
                return context.Database.SqlQuery<T>(spQuery, parameters).FirstOrDefault();
            }
        }

        
    }
}

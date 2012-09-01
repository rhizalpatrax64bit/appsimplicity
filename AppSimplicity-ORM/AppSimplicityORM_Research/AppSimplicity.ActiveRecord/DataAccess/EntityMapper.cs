using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimplicity.ActiveRecord.DataAccess
{
    public abstract class EntityMapper<T>
    {
        private string _dataSourceName;

        public EntityMapper(string dataSourceName) 
        {
            _dataSourceName = dataSourceName;
        }

        private string GetConnectionString() 
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[_dataSourceName].ConnectionString;
        }

        public T MapToEntity(System.Data.Common.DbDataReader reader);

        //public T GetSingle(System.Data.Common.DbCommand command) 
        //{
        //    T entity = default(T);
         
        //    entity = MapToEntity (new System.Data.IDataReader() );
        //    return entity;
        //}

        //public T GetSingle(string SQLCommand, System.Data.CommandType commandType) 
        //{ 
            
        //}
    }
}

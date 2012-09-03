using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AppSimplicity.ActiveRecord.DataAccess.SqlServer
{
    public abstract class EntityMapper<T> where T : Interfaces.IActiveRecord 
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

        public virtual T MapToEntity(System.Data.SqlClient.SqlDataReader reader);

        public T GetSingle(SqlCommand command)
        {
            T entity = default(T);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                entity = MapToEntity(reader);
                break;
            }

            reader.Close();
           
            return entity;
        }

        public T GetSingle(string SQLCommand, System.Data.CommandType commandType)
        {
            T entity = default(T);

            using (SqlConnection connection = new SqlConnection(GetConnectionString())) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQLCommand);
                command.Connection = connection;
                command.CommandType = commandType;              
                entity = this.GetSingle(command);
                connection.Close();
            }

            return entity;
        }

        public T GetSingle(string SQLCommand, System.Data.CommandType commandType, SqlParameter[] parameters)
        {
            T entity = default(T);

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SQLCommand);
                command.Connection = connection;
                command.CommandType = commandType;
                command.Parameters.AddRange(parameters);
                entity = this.GetSingle(command);
                connection.Close();
            }

            return entity;
        }
    }
}

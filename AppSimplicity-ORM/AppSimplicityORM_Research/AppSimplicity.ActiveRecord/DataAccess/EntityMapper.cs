using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace AppSimplicity.ActiveRecord.DataAccess
{
    public abstract class EntityDataAccess<T> where T : Interfaces.IActiveRecord 
    {
        private string _dataSourceName;

        public EntityDataAccess(string dataSourceName)
	    {
            _dataSourceName = dataSourceName;
	    }

        T MapToEntity(System.Data.SqlClient.SqlDataReader reader);

        #region ExecuteSingle
        public T ExecuteSingle(string sqlCommand) 
        {
            return ExecuteSingle(sqlCommand, System.Data.CommandType.Text);
        }

        public T ExecuteSingle(string sqlCommand, System.Data.CommandType commandType) 
        {
            return ExecuteSingle(sqlCommand, commandType, null);
        }

        public T ExecuteSingle(string sqlCommand, System.Data.CommandType commandType, SqlParameter[] parameters) 
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = sqlCommand;
            command.CommandType = commandType;
            command.Parameters.AddRange(parameters);

            return ExecuteSingle(command);    
        }

        public T ExecuteSingle(SqlCommand command) 
        {
            T entity = default(T);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[_dataSourceName].ConnectionString))
            {
                command.Connection = connection;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entity = MapToEntity(reader);
                    break;
                }
                reader.Close();
            }

            return entity;
        }

        #endregion

        #region ExecuteList
        public List<T> ExecuteList(string sqlCommand)
        {
            return ExecuteList(sqlCommand, System.Data.CommandType.Text);
        }

        public List<T> ExecuteList(string sqlCommand, System.Data.CommandType commandType)
        {
            return ExecuteList(sqlCommand, commandType, null);
        }

        public List<T> ExecuteList(string sqlCommand, System.Data.CommandType commandType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sqlCommand);
            command.CommandText = sqlCommand;
            command.CommandType = commandType;
            command.Parameters.AddRange(parameters);

            return ExecuteList(command);
        }

        public List<T> ExecuteList(SqlCommand command)
        {
            List<T> list = new List<T>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[_dataSourceName].ConnectionString))
            {
                command.Connection = connection;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    T entity = MapToEntity(reader);

                    if (entity != null)
                    {
                        list.Add(entity);
                    }
                }
                reader.Close();
            }
            return list;
        }
        #endregion        

        System.Data.SqlClient.SqlCommand GetInsertCommand(T entity);         

        System.Data.SqlClient.SqlCommand GetDeleteCommand(T entity);        

        System.Data.SqlClient.SqlCommand GetUpdateCommand(T entity);
        
    }
}

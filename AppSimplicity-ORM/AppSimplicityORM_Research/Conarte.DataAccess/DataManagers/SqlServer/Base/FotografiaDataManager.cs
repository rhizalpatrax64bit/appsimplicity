using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conarte.Entities.Interfaces;
using System.Data.SqlClient;

namespace Conarte.DataAccess.DataManagers.SqlServer
{
    public class FotografiaDataManager : IFotografiaDataMgr
    {

        public List<Entities.Fotografia> GetByFondo(int Fondo_Id)
        {            
            throw new NotImplementedException ();
            //FotografiaMapper mapper = new FotografiaMapper();
         //   return mapper.ExecuteList (        
        }

        public List<Entities.Fotografia> GetByProcesoFotografico(int ProcesoFotografico_Id)
        {
            throw new NotImplementedException();
        }

        public Entities.Fotografia GetById(int identity)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Fotografia> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Entities.Fotografia> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public bool Create(Entities.Fotografia entity)
        {
            FotografiaDataAccess Db = new FotografiaDataAccess();
            
            return false;
        }

        public bool Update(Entities.Fotografia entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entities.Fotografia entity, AppSimplicity.ActiveRecord.Interfaces.ConcurrencyMode mode)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entities.Fotografia entity)
        {
            throw new NotImplementedException();
        }
    }

    public class FotografiaDataAccess : AppSimplicity.ActiveRecord.DataAccess.EntityDataAccess<Entities.Fotografia>
    {
        public FotografiaDataAccess()
        {
            _dataSourceName = "Conarte";
        }       

        public override Entities.Fotografia MapToEntity(System.Data.SqlClient.SqlDataReader reader) 
        {
            Entities.Fotografia entity = new Entities.Fotografia();

            entity.Id = (int) reader["Id"];
            entity.Titulo = reader[""].ToString();
            entity.InformacionTecnica = (bool)reader["InformacionTecnica"];
            if (reader["InformacionTecnica"] != System.DBNull.Value) entity.InformacionTecnica = (bool)reader["InformacionTecnica"];

            return entity;
        }
        
        protected override SqlCommand GetInsertCommand(Entities.Fotografia entity)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "spcgp_fotografia_insert";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (entity.TipoMaterial_Id.HasValue) 
            {
                command.Parameters.Add(new SqlParameter("rqewrq", entity.TipoMaterial_Id.Value));
            }
            else 
            {
                command.Parameters.Add ("", System.DBNull.Value);
            }

            return command;
        }

        protected override SqlCommand GetDeleteCommand(Entities.Fotografia entity)
        {
            throw new NotImplementedException();
        }

        protected override SqlCommand GetUpdateCommand(Entities.Fotografia entity)
        {
            throw new NotImplementedException();
        }
    }
}

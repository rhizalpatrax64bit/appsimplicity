using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conarte.Entities.Interfaces;

namespace Conarte.DataAccess.DataManagers.SqlServer
{
    public class FotografiaDataManager : IFotografiaDataMgr
    {

        public List<Entities.Fotografia> GetByFondo(int Fondo_Id)
        {
            throw new NotImplementedException();
            //FotografiaMapper mapper = new FotografiaMapper();

            //return mapper.GetSingle("", System.Data.CommandType.Text);
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
            throw new NotImplementedException();
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

    public class FotografiaMapper : AppSimplicity.ActiveRecord.DataAccess.SqlServer.EntityMapper<Conarte.Entities.Fotografia> 
    {
        public override Entities.Fotografia MapToEntity(System.Data.SqlClient.SqlDataReader reader)
        {
            Conarte.Entities.Fotografia entity = new Entities.Fotografia();

            //entity.Id = reader["id"];
            //entity.Agencia = (string)reader["data"];
            //entity.Autor_Id = (int)reader["data"];

            return entity;
        }
    }
}

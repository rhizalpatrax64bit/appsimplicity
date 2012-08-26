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
        }

        public List<Entities.Fotografia> GetByProcesoFotografico(int ProcesoFotografico_Id)
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

        public bool Delete(Entities.Fotografia entity)
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
    }
}

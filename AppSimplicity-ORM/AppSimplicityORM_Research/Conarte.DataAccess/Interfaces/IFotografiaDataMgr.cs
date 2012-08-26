using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSimplicity.ActiveRecord.Interfaces;

namespace Conarte.DataAccess.Interfaces
{
    public interface IFotografiaDataMgr : IDataManager<Conarte.Entities.Fotografia>
    {
        public List<IFotografiaDataMgr> GetFotografiasByFondo(int Fondo_Id);
    }
}

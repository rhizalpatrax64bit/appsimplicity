using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSimplicity.ActiveRecord.Interfaces;
using Conarte.Entities;

namespace Conarte.Entities.Interfaces
{
    public interface IFotografiaDataMgr : IDataManager<Fotografia>, IPersister<Fotografia>
    {
        List<Fotografia> GetByFondo(int Fondo_Id);
        List<Fotografia> GetByProcesoFotografico(int ProcesoFotografico_Id);
    }
}

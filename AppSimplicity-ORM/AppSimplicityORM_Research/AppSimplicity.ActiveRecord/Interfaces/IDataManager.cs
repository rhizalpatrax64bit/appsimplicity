using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimplicity.ActiveRecord.Interfaces
{
    public interface IDataManager<T>
    {        
        T GetById(int identity);
        List<T> GetAll();
        List<T> GetAllActive();
    }
}

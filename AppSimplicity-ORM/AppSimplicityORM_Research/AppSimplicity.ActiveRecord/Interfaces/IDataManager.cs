using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimplicity.ActiveRecord.Interfaces
{
    public interface IDataManager<T>
    {        
        public T GetById(int identity);
        public List<T> GetAll();
        public List<T> GetAllActive();
    }
}

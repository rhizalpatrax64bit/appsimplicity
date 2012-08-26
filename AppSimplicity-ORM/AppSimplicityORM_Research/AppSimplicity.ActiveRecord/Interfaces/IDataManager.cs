using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimplicity.ActiveRecord.Interfaces
{
    public interface IDataManager<T>
    {
        public bool Create(T entity);
        public bool Update(T entity);
        public bool Delete(T entity);
        public T GetById(int identity);
        public List<T> GetAll();
        public List<T> GetAllActive();
    }
}

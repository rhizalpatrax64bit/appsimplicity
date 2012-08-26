using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimplicity.ActiveRecord.Interfaces
{
    public enum ConcurrencyMode 
    { 
        Optimistic,
        Pesimistic
    }

    public interface IPersister <T> where T : IActiveRecord 
    {
        public bool Create(T entity);
        public bool Update(T entity);
        public bool Update(T entity, ConcurrencyMode mode);
        public bool Delete(T entity);
    }
}

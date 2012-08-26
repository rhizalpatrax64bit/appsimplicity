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
        bool Create(T entity);
        bool Update(T entity);
        bool Update(T entity, ConcurrencyMode mode);
        bool Delete(T entity);
    }
}

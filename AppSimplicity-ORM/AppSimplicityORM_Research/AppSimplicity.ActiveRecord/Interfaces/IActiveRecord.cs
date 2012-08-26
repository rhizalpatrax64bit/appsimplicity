using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimplicity.ActiveRecord.Interfaces
{
    public interface IActiveRecord 
    {
        public int Id
        {
            get;
            set;
        }
    }
}

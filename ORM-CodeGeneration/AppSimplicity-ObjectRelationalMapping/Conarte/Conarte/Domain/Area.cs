using System;
using System.Collections.Generic;
using System.Text;

namespace Conarte.Conarte
{
    public partial class Area
    {
	
		private int ? _Id;
        public int ? Id 
        {
            get {
                return _Id;
            }
            set {
                _Id = value;
            }
        }

		private string _Descripcion;
        public string Descripcion 
        {
            get {
                return _Descripcion;
            }
            set {
                _Descripcion = value;
            }
        }

		private bool ? _Activo;
        public bool ? Activo 
        {
            get {
                return _Activo;
            }
            set {
                _Activo = value;
            }
        }

		private DateTime ? _FechaCreacion;
        public DateTime ? FechaCreacion 
        {
            get {
                return _FechaCreacion;
            }
            set {
                _FechaCreacion = value;
            }
        }

		private string _CreadoPor;
        public string CreadoPor 
        {
            get {
                return _CreadoPor;
            }
            set {
                _CreadoPor = value;
            }
        }

		private DateTime ? _FechaModificacion;
        public DateTime ? FechaModificacion 
        {
            get {
                return _FechaModificacion;
            }
            set {
                _FechaModificacion = value;
            }
        }

		private string _ModificadoPor;
        public string ModificadoPor 
        {
            get {
                return _ModificadoPor;
            }
            set {
                _ModificadoPor = value;
            }
        }

    }
}

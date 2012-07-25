using System;
using System.Collections.Generic;
using System.Text;

namespace Conarte.Conarte
{
    public partial class Aplicacion
    {
	
		private int _Id;
        public int Id 
        {
            get {
                return _Id;
            }
            set {
                _Id = value;
            }
        }

		private string _NombreAplicacion;
        public string NombreAplicacion 
        {
            get {
                return _NombreAplicacion;
            }
            set {
                _NombreAplicacion = value;
            }
        }

		private int _NumeroMaximoIntentosFallidos;
        public int NumeroMaximoIntentosFallidos 
        {
            get {
                return _NumeroMaximoIntentosFallidos;
            }
            set {
                _NumeroMaximoIntentosFallidos = value;
            }
        }

		private int _TiempoEsperaBloqueo;
        public int TiempoEsperaBloqueo 
        {
            get {
                return _TiempoEsperaBloqueo;
            }
            set {
                _TiempoEsperaBloqueo = value;
            }
        }

		private string _URL;
        public string URL 
        {
            get {
                return _URL;
            }
            set {
                _URL = value;
            }
        }

		private string _CuentaCorreoPredeterminada;
        public string CuentaCorreoPredeterminada 
        {
            get {
                return _CuentaCorreoPredeterminada;
            }
            set {
                _CuentaCorreoPredeterminada = value;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using AppSimplicity.ActiveRecord.Interfaces;

namespace Conarte.Entities {
	
	public partial class Autor : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private String _Observaciones;
			public String Observaciones 
			{
				get 
				{	
					return _Observaciones;
				}
				set 
				{
					_Observaciones = value;
				}
			}

			private String _InformacionAdicional;
			public String InformacionAdicional 
			{
				get 
				{	
					return _InformacionAdicional;
				}
				set 
				{
					_InformacionAdicional = value;
				}
			}

			private String _Direccion;
			public String Direccion 
			{
				get 
				{	
					return _Direccion;
				}
				set 
				{
					_Direccion = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.Fotografia> _Fotografias;
		public List<Conarte.Entities.Fotografia> Fotografias
		{
			get 
			{
				return _Fotografias;
			}
			set 
			{
				_Fotografias = value;
			}
		}
#endregion
	} // end class
	
	public partial class Colore : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Deterioro : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.IntervencionesDeteriorosMap> _IntervencionesDeteriorosMap;
		public List<Conarte.Entities.IntervencionesDeteriorosMap> IntervencionesDeteriorosMap
		{
			get 
			{
				return _IntervencionesDeteriorosMap;
			}
			set 
			{
				_IntervencionesDeteriorosMap = value;
			}
		}
#endregion
	} // end class
	
	public partial class Documento : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Fondo_Id;
			public Integer Fondo_Id 
			{
				get 
				{	
					return _Fondo_Id;
				}
				set 
				{
					_Fondo_Id = value;
				}
			}

			private String _NombreArchivo;
			public String NombreArchivo 
			{
				get 
				{	
					return _NombreArchivo;
				}
				set 
				{
					_NombreArchivo = value;
				}
			}

			private String _Directorio;
			public String Directorio 
			{
				get 
				{	
					return _Directorio;
				}
				set 
				{
					_Directorio = value;
				}
			}

			private String _NombreFisico;
			public String NombreFisico 
			{
				get 
				{	
					return _NombreFisico;
				}
				set 
				{
					_NombreFisico = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fondo _Fondo;
		public Fondo Fondo 
		{
			get { return _Fondo; }
			set { _Fondo = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Epoca : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private DateTime ? _FechaInicial;
			public DateTime ? FechaInicial 
			{
				get 
				{	
					return _FechaInicial;
				}
				set 
				{
					_FechaInicial = value;
				}
			}

			private DateTime ? _FechaFinal;
			public DateTime ? FechaFinal 
			{
				get 
				{	
					return _FechaFinal;
				}
				set 
				{
					_FechaFinal = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private DateTime ? _ModificadoPor;
			public DateTime ? ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.Fotografia> _Fotografias;
		public List<Conarte.Entities.Fotografia> Fotografias
		{
			get 
			{
				return _Fotografias;
			}
			set 
			{
				_Fotografias = value;
			}
		}
#endregion
	} // end class
	
	public partial class EpocasNL : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Etiqueta : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.EtiquetasEtiquetasMap> _EtiquetasEtiquetasMap;
		public List<Conarte.Entities.EtiquetasEtiquetasMap> EtiquetasEtiquetasMap
		{
			get 
			{
				return _EtiquetasEtiquetasMap;
			}
			set 
			{
				_EtiquetasEtiquetasMap = value;
			}
		}
		private List<Conarte.Entities.FotografiasEtiquetasMap> _FotografiasEtiquetasMap;
		public List<Conarte.Entities.FotografiasEtiquetasMap> FotografiasEtiquetasMap
		{
			get 
			{
				return _FotografiasEtiquetasMap;
			}
			set 
			{
				_FotografiasEtiquetasMap = value;
			}
		}
#endregion
	} // end class
	
	public partial class EtiquetasEtiquetasMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Etiqueta_Id;
			public Integer Etiqueta_Id 
			{
				get 
				{	
					return _Etiqueta_Id;
				}
				set 
				{
					_Etiqueta_Id = value;
				}
			}

			private Integer _EtiquetaRelacionada_Id;
			public Integer EtiquetaRelacionada_Id 
			{
				get 
				{	
					return _EtiquetaRelacionada_Id;
				}
				set 
				{
					_EtiquetaRelacionada_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Etiqueta _Etiqueta;
		public Etiqueta Etiqueta 
		{
			get { return _Etiqueta; }
			set { _Etiqueta = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class EventosDeUso : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private DateTime ? _FechaUso;
			public DateTime ? FechaUso 
			{
				get 
				{	
					return _FechaUso;
				}
				set 
				{
					_FechaUso = value;
				}
			}

			private Integer ? _TipoDeReproduccion_Id;
			public Integer ? TipoDeReproduccion_Id 
			{
				get 
				{	
					return _TipoDeReproduccion_Id;
				}
				set 
				{
					_TipoDeReproduccion_Id = value;
				}
			}

			private Integer ? _TipoDeUso_Id;
			public Integer ? TipoDeUso_Id 
			{
				get 
				{	
					return _TipoDeUso_Id;
				}
				set 
				{
					_TipoDeUso_Id = value;
				}
			}

			private String _Institucion;
			public String Institucion 
			{
				get 
				{	
					return _Institucion;
				}
				set 
				{
					_Institucion = value;
				}
			}

			private String _ResponsableDeUso;
			public String ResponsableDeUso 
			{
				get 
				{	
					return _ResponsableDeUso;
				}
				set 
				{
					_ResponsableDeUso = value;
				}
			}

			private Decimal ? _Monto;
			public Decimal ? Monto 
			{
				get 
				{	
					return _Monto;
				}
				set 
				{
					_Monto = value;
				}
			}

			private Boolean ? _Pagado;
			public Boolean ? Pagado 
			{
				get 
				{	
					return _Pagado;
				}
				set 
				{
					_Pagado = value;
				}
			}

			private String _Telefono;
			public String Telefono 
			{
				get 
				{	
					return _Telefono;
				}
				set 
				{
					_Telefono = value;
				}
			}

			private String _CorreoElectronico;
			public String CorreoElectronico 
			{
				get 
				{	
					return _CorreoElectronico;
				}
				set 
				{
					_CorreoElectronico = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private String _Observaciones;
			public String Observaciones 
			{
				get 
				{	
					return _Observaciones;
				}
				set 
				{
					_Observaciones = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Exposicione : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Fondo : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private Integer ? _TipoDeFondo_Id;
			public Integer ? TipoDeFondo_Id 
			{
				get 
				{	
					return _TipoDeFondo_Id;
				}
				set 
				{
					_TipoDeFondo_Id = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private String _Donante;
			public String Donante 
			{
				get 
				{	
					return _Donante;
				}
				set 
				{
					_Donante = value;
				}
			}

			private String _Contacto;
			public String Contacto 
			{
				get 
				{	
					return _Contacto;
				}
				set 
				{
					_Contacto = value;
				}
			}

			private String _Direccion;
			public String Direccion 
			{
				get 
				{	
					return _Direccion;
				}
				set 
				{
					_Direccion = value;
				}
			}

			private String _Telefono;
			public String Telefono 
			{
				get 
				{	
					return _Telefono;
				}
				set 
				{
					_Telefono = value;
				}
			}

			private String _Procedencia;
			public String Procedencia 
			{
				get 
				{	
					return _Procedencia;
				}
				set 
				{
					_Procedencia = value;
				}
			}

			private Integer ? _SituacionLegal_Id;
			public Integer ? SituacionLegal_Id 
			{
				get 
				{	
					return _SituacionLegal_Id;
				}
				set 
				{
					_SituacionLegal_Id = value;
				}
			}

			private DateTime ? _FechaIngreso;
			public DateTime ? FechaIngreso 
			{
				get 
				{	
					return _FechaIngreso;
				}
				set 
				{
					_FechaIngreso = value;
				}
			}

			private String _Observaciones;
			public String Observaciones 
			{
				get 
				{	
					return _Observaciones;
				}
				set 
				{
					_Observaciones = value;
				}
			}

			private String _CorreoElectronico;
			public String CorreoElectronico 
			{
				get 
				{	
					return _CorreoElectronico;
				}
				set 
				{
					_CorreoElectronico = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.Documento> _Documentos;
		public List<Conarte.Entities.Documento> Documentos
		{
			get 
			{
				return _Documentos;
			}
			set 
			{
				_Documentos = value;
			}
		}
		private List<Conarte.Entities.Fotografia> _Fotografias;
		public List<Conarte.Entities.Fotografia> Fotografias
		{
			get 
			{
				return _Fotografias;
			}
			set 
			{
				_Fotografias = value;
			}
		}
#endregion
	} // end class
	
	public partial class Formato : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.Fotografia> _Fotografias;
		public List<Conarte.Entities.Fotografia> Fotografias
		{
			get 
			{
				return _Fotografias;
			}
			set 
			{
				_Fotografias = value;
			}
		}
#endregion
	} // end class
	
	public partial class Fotografia : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Long ? _NumeroInventario;
			public Long ? NumeroInventario 
			{
				get 
				{	
					return _NumeroInventario;
				}
				set 
				{
					_NumeroInventario = value;
				}
			}

			private String _NumeroInventarioProvisional;
			public String NumeroInventarioProvisional 
			{
				get 
				{	
					return _NumeroInventarioProvisional;
				}
				set 
				{
					_NumeroInventarioProvisional = value;
				}
			}

			private String _NumeroActivoFijo;
			public String NumeroActivoFijo 
			{
				get 
				{	
					return _NumeroActivoFijo;
				}
				set 
				{
					_NumeroActivoFijo = value;
				}
			}

			private String _Titulo;
			public String Titulo 
			{
				get 
				{	
					return _Titulo;
				}
				set 
				{
					_Titulo = value;
				}
			}

			private Integer ? _Serie_Id;
			public Integer ? Serie_Id 
			{
				get 
				{	
					return _Serie_Id;
				}
				set 
				{
					_Serie_Id = value;
				}
			}

			private Integer ? _Fondo_Id;
			public Integer ? Fondo_Id 
			{
				get 
				{	
					return _Fondo_Id;
				}
				set 
				{
					_Fondo_Id = value;
				}
			}

			private Integer ? _Color_Id;
			public Integer ? Color_Id 
			{
				get 
				{	
					return _Color_Id;
				}
				set 
				{
					_Color_Id = value;
				}
			}

			private Integer ? _TipoMaterial_Id;
			public Integer ? TipoMaterial_Id 
			{
				get 
				{	
					return _TipoMaterial_Id;
				}
				set 
				{
					_TipoMaterial_Id = value;
				}
			}

			private Integer ? _ProcesoFotografico_Id;
			public Integer ? ProcesoFotografico_Id 
			{
				get 
				{	
					return _ProcesoFotografico_Id;
				}
				set 
				{
					_ProcesoFotografico_Id = value;
				}
			}

			private Integer ? _LugarToma_Id;
			public Integer ? LugarToma_Id 
			{
				get 
				{	
					return _LugarToma_Id;
				}
				set 
				{
					_LugarToma_Id = value;
				}
			}

			private DateTime ? _FechaTomaInicial;
			public DateTime ? FechaTomaInicial 
			{
				get 
				{	
					return _FechaTomaInicial;
				}
				set 
				{
					_FechaTomaInicial = value;
				}
			}

			private DateTime ? _FechaTomaFinal;
			public DateTime ? FechaTomaFinal 
			{
				get 
				{	
					return _FechaTomaFinal;
				}
				set 
				{
					_FechaTomaFinal = value;
				}
			}

			private Integer ? _LugarAsunto_Id;
			public Integer ? LugarAsunto_Id 
			{
				get 
				{	
					return _LugarAsunto_Id;
				}
				set 
				{
					_LugarAsunto_Id = value;
				}
			}

			private DateTime ? _FechaAsuntoInicial;
			public DateTime ? FechaAsuntoInicial 
			{
				get 
				{	
					return _FechaAsuntoInicial;
				}
				set 
				{
					_FechaAsuntoInicial = value;
				}
			}

			private DateTime ? _FechaAsuntoFinal;
			public DateTime ? FechaAsuntoFinal 
			{
				get 
				{	
					return _FechaAsuntoFinal;
				}
				set 
				{
					_FechaAsuntoFinal = value;
				}
			}

			private Boolean ? _InformacionTecnica;
			public Boolean ? InformacionTecnica 
			{
				get 
				{	
					return _InformacionTecnica;
				}
				set 
				{
					_InformacionTecnica = value;
				}
			}

			private DateTime ? _FechaInformacionTecnica;
			public DateTime ? FechaInformacionTecnica 
			{
				get 
				{	
					return _FechaInformacionTecnica;
				}
				set 
				{
					_FechaInformacionTecnica = value;
				}
			}

			private Integer ? _Autor_Id;
			public Integer ? Autor_Id 
			{
				get 
				{	
					return _Autor_Id;
				}
				set 
				{
					_Autor_Id = value;
				}
			}

			private Integer ? _Formato_Id;
			public Integer ? Formato_Id 
			{
				get 
				{	
					return _Formato_Id;
				}
				set 
				{
					_Formato_Id = value;
				}
			}

			private Integer ? _FormatoMontaje_Id;
			public Integer ? FormatoMontaje_Id 
			{
				get 
				{	
					return _FormatoMontaje_Id;
				}
				set 
				{
					_FormatoMontaje_Id = value;
				}
			}

			private String _InformacionTecnicaPor;
			public String InformacionTecnicaPor 
			{
				get 
				{	
					return _InformacionTecnicaPor;
				}
				set 
				{
					_InformacionTecnicaPor = value;
				}
			}

			private Boolean ? _InformacionCatalografica;
			public Boolean ? InformacionCatalografica 
			{
				get 
				{	
					return _InformacionCatalografica;
				}
				set 
				{
					_InformacionCatalografica = value;
				}
			}

			private DateTime ? _FechaInformacionCatalografica;
			public DateTime ? FechaInformacionCatalografica 
			{
				get 
				{	
					return _FechaInformacionCatalografica;
				}
				set 
				{
					_FechaInformacionCatalografica = value;
				}
			}

			private String _CatalogadaPor;
			public String CatalogadaPor 
			{
				get 
				{	
					return _CatalogadaPor;
				}
				set 
				{
					_CatalogadaPor = value;
				}
			}

			private String _Agencia;
			public String Agencia 
			{
				get 
				{	
					return _Agencia;
				}
				set 
				{
					_Agencia = value;
				}
			}

			private Boolean ? _Digitalizada;
			public Boolean ? Digitalizada 
			{
				get 
				{	
					return _Digitalizada;
				}
				set 
				{
					_Digitalizada = value;
				}
			}

			private Integer ? _Imagen_Id;
			public Integer ? Imagen_Id 
			{
				get 
				{	
					return _Imagen_Id;
				}
				set 
				{
					_Imagen_Id = value;
				}
			}

			private Decimal ? _Avaluo;
			public Decimal ? Avaluo 
			{
				get 
				{	
					return _Avaluo;
				}
				set 
				{
					_Avaluo = value;
				}
			}

			private DateTime ? _FechaDigitalizacion;
			public DateTime ? FechaDigitalizacion 
			{
				get 
				{	
					return _FechaDigitalizacion;
				}
				set 
				{
					_FechaDigitalizacion = value;
				}
			}

			private String _DigitalizadaPor;
			public String DigitalizadaPor 
			{
				get 
				{	
					return _DigitalizadaPor;
				}
				set 
				{
					_DigitalizadaPor = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private String _Observaciones;
			public String Observaciones 
			{
				get 
				{	
					return _Observaciones;
				}
				set 
				{
					_Observaciones = value;
				}
			}

			private Boolean ? _PublicarEnInternet;
			public Boolean ? PublicarEnInternet 
			{
				get 
				{	
					return _PublicarEnInternet;
				}
				set 
				{
					_PublicarEnInternet = value;
				}
			}

			private Integer ? _Epoca_Id;
			public Integer ? Epoca_Id 
			{
				get 
				{	
					return _Epoca_Id;
				}
				set 
				{
					_Epoca_Id = value;
				}
			}

			private Integer ? _UltimoMovimiento_Id;
			public Integer ? UltimoMovimiento_Id 
			{
				get 
				{	
					return _UltimoMovimiento_Id;
				}
				set 
				{
					_UltimoMovimiento_Id = value;
				}
			}

			private Integer ? _Aseguramiento_Id;
			public Integer ? Aseguramiento_Id 
			{
				get 
				{	
					return _Aseguramiento_Id;
				}
				set 
				{
					_Aseguramiento_Id = value;
				}
			}

			private Boolean ? _EsPiezaTemporal;
			public Boolean ? EsPiezaTemporal 
			{
				get 
				{	
					return _EsPiezaTemporal;
				}
				set 
				{
					_EsPiezaTemporal = value;
				}
			}

			private Integer ? _UltimaIntervencion_Id;
			public Integer ? UltimaIntervencion_Id 
			{
				get 
				{	
					return _UltimaIntervencion_Id;
				}
				set 
				{
					_UltimaIntervencion_Id = value;
				}
			}

			private Integer ? _EpocaNL_Id;
			public Integer ? EpocaNL_Id 
			{
				get 
				{	
					return _EpocaNL_Id;
				}
				set 
				{
					_EpocaNL_Id = value;
				}
			}

			private Boolean ? _InformacionPersonajesCompletada;
			public Boolean ? InformacionPersonajesCompletada 
			{
				get 
				{	
					return _InformacionPersonajesCompletada;
				}
				set 
				{
					_InformacionPersonajesCompletada = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Serie _Serie;
		public Serie Serie 
		{
			get { return _Serie; }
			set { _Serie = value; }
		}
		private Conarte.Entities.Fondo _Fondo;
		public Fondo Fondo 
		{
			get { return _Fondo; }
			set { _Fondo = value; }
		}
		private Conarte.Entities.Autor _Autor;
		public Autor Autor 
		{
			get { return _Autor; }
			set { _Autor = value; }
		}
		private Conarte.Entities.Formato _Formato;
		public Formato Formato 
		{
			get { return _Formato; }
			set { _Formato = value; }
		}
		private Conarte.Entities.Epoca _Epoca;
		public Epoca Epoca 
		{
			get { return _Epoca; }
			set { _Epoca = value; }
		}
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.FotografiasEtiquetasMap> _FotografiasEtiquetasMap;
		public List<Conarte.Entities.FotografiasEtiquetasMap> FotografiasEtiquetasMap
		{
			get 
			{
				return _FotografiasEtiquetasMap;
			}
			set 
			{
				_FotografiasEtiquetasMap = value;
			}
		}
		private List<Conarte.Entities.FotografiasEventosDeUsoMap> _FotografiasEventosDeUsoMap;
		public List<Conarte.Entities.FotografiasEventosDeUsoMap> FotografiasEventosDeUsoMap
		{
			get 
			{
				return _FotografiasEventosDeUsoMap;
			}
			set 
			{
				_FotografiasEventosDeUsoMap = value;
			}
		}
		private List<Conarte.Entities.FotografiasImagenesMap> _FotografiasImagenesMap;
		public List<Conarte.Entities.FotografiasImagenesMap> FotografiasImagenesMap
		{
			get 
			{
				return _FotografiasImagenesMap;
			}
			set 
			{
				_FotografiasImagenesMap = value;
			}
		}
		private List<Conarte.Entities.FotografiasPersonajesMap> _FotografiasPersonajesMap;
		public List<Conarte.Entities.FotografiasPersonajesMap> FotografiasPersonajesMap
		{
			get 
			{
				return _FotografiasPersonajesMap;
			}
			set 
			{
				_FotografiasPersonajesMap = value;
			}
		}
		private List<Conarte.Entities.Imagene> _Imagenes;
		public List<Conarte.Entities.Imagene> Imagenes
		{
			get 
			{
				return _Imagenes;
			}
			set 
			{
				_Imagenes = value;
			}
		}
		private List<Conarte.Entities.Intervencione> _Intervenciones;
		public List<Conarte.Entities.Intervencione> Intervenciones
		{
			get 
			{
				return _Intervenciones;
			}
			set 
			{
				_Intervenciones = value;
			}
		}
		private List<Conarte.Entities.Seguro> _Seguros;
		public List<Conarte.Entities.Seguro> Seguros
		{
			get 
			{
				return _Seguros;
			}
			set 
			{
				_Seguros = value;
			}
		}
#endregion
	} // end class
	
	public partial class FotografiasEtiquetasMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer ? _Fotografia_Id;
			public Integer ? Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private Integer ? _Etiqueta_Id;
			public Integer ? Etiqueta_Id 
			{
				get 
				{	
					return _Etiqueta_Id;
				}
				set 
				{
					_Etiqueta_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
		private Conarte.Entities.Etiqueta _Etiqueta;
		public Etiqueta Etiqueta 
		{
			get { return _Etiqueta; }
			set { _Etiqueta = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class FotografiasEventosDeUsoMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer ? _Fotografia_Id;
			public Integer ? Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private Integer ? _EventoDeUso_Id;
			public Integer ? EventoDeUso_Id 
			{
				get 
				{	
					return _EventoDeUso_Id;
				}
				set 
				{
					_EventoDeUso_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class FotografiasImagenesMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Fotografia_Id;
			public Integer Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private Integer _Imagen_Id;
			public Integer Imagen_Id 
			{
				get 
				{	
					return _Imagen_Id;
				}
				set 
				{
					_Imagen_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class FotografiasPersonajesMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Fotografia_Id;
			public Integer Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private Integer _Personaje_Id;
			public Integer Personaje_Id 
			{
				get 
				{	
					return _Personaje_Id;
				}
				set 
				{
					_Personaje_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
		private Conarte.Entities.Personaje _Personaje;
		public Personaje Personaje 
		{
			get { return _Personaje; }
			set { _Personaje = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Imagene : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _NombreOriginal;
			public String NombreOriginal 
			{
				get 
				{	
					return _NombreOriginal;
				}
				set 
				{
					_NombreOriginal = value;
				}
			}

			private String _Directorio;
			public String Directorio 
			{
				get 
				{	
					return _Directorio;
				}
				set 
				{
					_Directorio = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private Integer ? _Fotografia_Id;
			public Integer ? Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Intervencione : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer ? _Tipo;
			public Integer ? Tipo 
			{
				get 
				{	
					return _Tipo;
				}
				set 
				{
					_Tipo = value;
				}
			}

			private Integer _Fotografia_Id;
			public Integer Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private DateTime _FechaIntervencion;
			public DateTime FechaIntervencion 
			{
				get 
				{	
					return _FechaIntervencion;
				}
				set 
				{
					_FechaIntervencion = value;
				}
			}

			private String _IntervencionPor;
			public String IntervencionPor 
			{
				get 
				{	
					return _IntervencionPor;
				}
				set 
				{
					_IntervencionPor = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private String _Observaciones;
			public String Observaciones 
			{
				get 
				{	
					return _Observaciones;
				}
				set 
				{
					_Observaciones = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class IntervencionesDeteriorosMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Intervencion_Id;
			public Integer Intervencion_Id 
			{
				get 
				{	
					return _Intervencion_Id;
				}
				set 
				{
					_Intervencion_Id = value;
				}
			}

			private Integer _Deterioro_Id;
			public Integer Deterioro_Id 
			{
				get 
				{	
					return _Deterioro_Id;
				}
				set 
				{
					_Deterioro_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Deterioro _Deterioro;
		public Deterioro Deterioro 
		{
			get { return _Deterioro; }
			set { _Deterioro = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class IntervencionesTiposIntervencionMap : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Intervencion_Id;
			public Integer Intervencion_Id 
			{
				get 
				{	
					return _Intervencion_Id;
				}
				set 
				{
					_Intervencion_Id = value;
				}
			}

			private Integer _TipoIntervencion_Id;
			public Integer TipoIntervencion_Id 
			{
				get 
				{	
					return _TipoIntervencion_Id;
				}
				set 
				{
					_TipoIntervencion_Id = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Interventore : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Iniciales;
			public String Iniciales 
			{
				get 
				{	
					return _Iniciales;
				}
				set 
				{
					_Iniciales = value;
				}
			}

			private String _Nombre;
			public String Nombre 
			{
				get 
				{	
					return _Nombre;
				}
				set 
				{
					_Nombre = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Lugare : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Personaje : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.FotografiasPersonajesMap> _FotografiasPersonajesMap;
		public List<Conarte.Entities.FotografiasPersonajesMap> FotografiasPersonajesMap
		{
			get 
			{
				return _FotografiasPersonajesMap;
			}
			set 
			{
				_FotografiasPersonajesMap = value;
			}
		}
#endregion
	} // end class
	
	public partial class ProcesosFotografico : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Seguro : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private Integer _Fotografia_Id;
			public Integer Fotografia_Id 
			{
				get 
				{	
					return _Fotografia_Id;
				}
				set 
				{
					_Fotografia_Id = value;
				}
			}

			private String _EmpresaAseguradora;
			public String EmpresaAseguradora 
			{
				get 
				{	
					return _EmpresaAseguradora;
				}
				set 
				{
					_EmpresaAseguradora = value;
				}
			}

			private String _NumeroPoliza;
			public String NumeroPoliza 
			{
				get 
				{	
					return _NumeroPoliza;
				}
				set 
				{
					_NumeroPoliza = value;
				}
			}

			private DateTime _FechaInicial;
			public DateTime FechaInicial 
			{
				get 
				{	
					return _FechaInicial;
				}
				set 
				{
					_FechaInicial = value;
				}
			}

			private DateTime _FechaFinal;
			public DateTime FechaFinal 
			{
				get 
				{	
					return _FechaFinal;
				}
				set 
				{
					_FechaFinal = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Serie : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
		private List<Conarte.Entities.Fotografia> _Fotografias;
		public List<Conarte.Entities.Fotografia> Fotografias
		{
			get 
			{
				return _Fotografias;
			}
			set 
			{
				_Fotografias = value;
			}
		}
#endregion
	} // end class
	
	public partial class SituacionesLegale : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class SubUbicacione : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean _Activo;
			public Boolean Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private Integer ? _Ubicacion_Id;
			public Integer ? Ubicacion_Id 
			{
				get 
				{	
					return _Ubicacion_Id;
				}
				set 
				{
					_Ubicacion_Id = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class TiposDeMovimiento : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean _Activo;
			public Boolean Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class TiposDeReproduccion : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class TiposDeUso : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class TiposIntervencione : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private String _Clave;
			public String Clave 
			{
				get 
				{	
					return _Clave;
				}
				set 
				{
					_Clave = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class TiposMateriale : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Descripcion;
			public String Descripcion 
			{
				get 
				{	
					return _Descripcion;
				}
				set 
				{
					_Descripcion = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _FechaCreacion;
			public DateTime ? FechaCreacion 
			{
				get 
				{	
					return _FechaCreacion;
				}
				set 
				{
					_FechaCreacion = value;
				}
			}

			private String _CreadoPor;
			public String CreadoPor 
			{
				get 
				{	
					return _CreadoPor;
				}
				set 
				{
					_CreadoPor = value;
				}
			}

			private DateTime ? _FechaModificacion;
			public DateTime ? FechaModificacion 
			{
				get 
				{	
					return _FechaModificacion;
				}
				set 
				{
					_FechaModificacion = value;
				}
			}

			private String _ModificadoPor;
			public String ModificadoPor 
			{
				get 
				{	
					return _ModificadoPor;
				}
				set 
				{
					_ModificadoPor = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	
	public partial class Usuario : IActiveRecord
	{
		
			private Integer _Id;
			public Integer Id 
			{
				get 
				{	
					return _Id;
				}
				set 
				{
					_Id = value;
				}
			}

			private String _Login;
			public String Login 
			{
				get 
				{	
					return _Login;
				}
				set 
				{
					_Login = value;
				}
			}

			private String _Password;
			public String Password 
			{
				get 
				{	
					return _Password;
				}
				set 
				{
					_Password = value;
				}
			}

			private String _NombreCompleto;
			public String NombreCompleto 
			{
				get 
				{	
					return _NombreCompleto;
				}
				set 
				{
					_NombreCompleto = value;
				}
			}

			private String _CorreoElectronico;
			public String CorreoElectronico 
			{
				get 
				{	
					return _CorreoElectronico;
				}
				set 
				{
					_CorreoElectronico = value;
				}
			}

			private Boolean ? _Activo;
			public Boolean ? Activo 
			{
				get 
				{	
					return _Activo;
				}
				set 
				{
					_Activo = value;
				}
			}

			private DateTime ? _BloqueadoEn;
			public DateTime ? BloqueadoEn 
			{
				get 
				{	
					return _BloqueadoEn;
				}
				set 
				{
					_BloqueadoEn = value;
				}
			}

			private Boolean ? _Bloqueado;
			public Boolean ? Bloqueado 
			{
				get 
				{	
					return _Bloqueado;
				}
				set 
				{
					_Bloqueado = value;
				}
			}

			private Integer ? _IntentosFallidos;
			public Integer ? IntentosFallidos 
			{
				get 
				{	
					return _IntentosFallidos;
				}
				set 
				{
					_IntentosFallidos = value;
				}
			}

			private DateTime ? _UltimaAutenticacion;
			public DateTime ? UltimaAutenticacion 
			{
				get 
				{	
					return _UltimaAutenticacion;
				}
				set 
				{
					_UltimaAutenticacion = value;
				}
			}

			private DateTime ? _FechaRegistro;
			public DateTime ? FechaRegistro 
			{
				get 
				{	
					return _FechaRegistro;
				}
				set 
				{
					_FechaRegistro = value;
				}
			}

			private Boolean ? _AccesoConfirmado;
			public Boolean ? AccesoConfirmado 
			{
				get 
				{	
					return _AccesoConfirmado;
				}
				set 
				{
					_AccesoConfirmado = value;
				}
			}

			private DateTime ? _FechaConfirmacion;
			public DateTime ? FechaConfirmacion 
			{
				get 
				{	
					return _FechaConfirmacion;
				}
				set 
				{
					_FechaConfirmacion = value;
				}
			}

			private Boolean ? _DeseaRecibirNotificaciones;
			public Boolean ? DeseaRecibirNotificaciones 
			{
				get 
				{	
					return _DeseaRecibirNotificaciones;
				}
				set 
				{
					_DeseaRecibirNotificaciones = value;
				}
			}

			private bool _isLoadedFromDB = false;
            public bool IsLoadedFromDB
            {
                get
                {
                    return _isLoadedFromDB;
                }
                set
                {
                    _isLoadedFromDB = value;
                }
            }
#region BelongsToRelationShips
#endregion
#region HasManyRelationShips
#endregion
	} // end class
	} // end namespace

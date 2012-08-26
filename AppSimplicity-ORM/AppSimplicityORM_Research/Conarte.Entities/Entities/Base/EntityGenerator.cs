using System;
namespace Conarte.Entities {
	
	public partial class Autor 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

			private string _Observaciones;
			public string Observaciones 
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

			private string _InformacionAdicional;
			public string InformacionAdicional 
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

			private string _Direccion;
			public string Direccion 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Color 
	{
		
			private int _Id;
			public int Id 
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

			private string _Clave;
			public string Clave 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Deterioro 
	{
		
			private int _Id;
			public int Id 
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

			private string _Clave;
			public string Clave 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Documento 
	{
		
			private int _Id;
			public int Id 
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

			private int _Fondo_Id;
			public int Fondo_Id 
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

			private string _NombreArchivo;
			public string NombreArchivo 
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

			private string _Directorio;
			public string Directorio 
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

			private string _NombreFisico;
			public string NombreFisico 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

#region BelongsToRelationShips
		private Conarte.Entities.Fondo _Fondo;
		public Fondo Fondo 
		{
			get { return _Fondo; }
			set { _Fondo = value; }
		}
#endregion
	} // end class
	
	public partial class Epoca 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private string _Clave;
			public string Clave 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private DateTime _ModificadoPor;
			public DateTime ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class EpocaNL 
	{
		
			private int _Id;
			public int Id 
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

			private string _Clave;
			public string Clave 
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

			private string _Descripcion;
			public string Descripcion 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

			private bool _Activo;
			public bool Activo 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Etiqueta 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class EtiquetasEtiquetasMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Etiqueta_Id;
			public int Etiqueta_Id 
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

			private int _EtiquetaRelacionada_Id;
			public int EtiquetaRelacionada_Id 
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

#region BelongsToRelationShips
		private Conarte.Entities.Etiqueta _Etiqueta;
		public Etiqueta Etiqueta 
		{
			get { return _Etiqueta; }
			set { _Etiqueta = value; }
		}
#endregion
	} // end class
	
	public partial class EventosDeUso 
	{
		
			private int _Id;
			public int Id 
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

			private DateTime _FechaUso;
			public DateTime FechaUso 
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

			private int _TipoDeReproduccion_Id;
			public int TipoDeReproduccion_Id 
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

			private int _TipoDeUso_Id;
			public int TipoDeUso_Id 
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

			private string _Institucion;
			public string Institucion 
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

			private string _ResponsableDeUso;
			public string ResponsableDeUso 
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

			private decimal _Monto;
			public decimal Monto 
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

			private bool _Pagado;
			public bool Pagado 
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

			private string _Telefono;
			public string Telefono 
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

			private string _CorreoElectronico;
			public string CorreoElectronico 
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

			private string _Descripcion;
			public string Descripcion 
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

			private string _Observaciones;
			public string Observaciones 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Exposicione 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Fondo 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private string _Clave;
			public string Clave 
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

			private bool _Activo;
			public bool Activo 
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

			private int _TipoDeFondo_Id;
			public int TipoDeFondo_Id 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

			private string _Donante;
			public string Donante 
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

			private string _Contacto;
			public string Contacto 
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

			private string _Direccion;
			public string Direccion 
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

			private string _Telefono;
			public string Telefono 
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

			private string _Procedencia;
			public string Procedencia 
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

			private int _SituacionLegal_Id;
			public int SituacionLegal_Id 
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

			private DateTime _FechaIngreso;
			public DateTime FechaIngreso 
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

			private string _Observaciones;
			public string Observaciones 
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

			private string _CorreoElectronico;
			public string CorreoElectronico 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Formato 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private string _Clave;
			public string Clave 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Fotografia 
	{
		
			private int _Id;
			public int Id 
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

			private long _NumeroInventario;
			public long NumeroInventario 
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

			private string _NumeroInventarioProvisional;
			public string NumeroInventarioProvisional 
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

			private string _NumeroActivoFijo;
			public string NumeroActivoFijo 
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

			private string _Titulo;
			public string Titulo 
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

			private int _Serie_Id;
			public int Serie_Id 
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

			private int _Fondo_Id;
			public int Fondo_Id 
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

			private int _Color_Id;
			public int Color_Id 
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

			private int _TipoMaterial_Id;
			public int TipoMaterial_Id 
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

			private int _ProcesoFotografico_Id;
			public int ProcesoFotografico_Id 
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

			private int _LugarToma_Id;
			public int LugarToma_Id 
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

			private DateTime _FechaTomaInicial;
			public DateTime FechaTomaInicial 
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

			private DateTime _FechaTomaFinal;
			public DateTime FechaTomaFinal 
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

			private int _LugarAsunto_Id;
			public int LugarAsunto_Id 
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

			private DateTime _FechaAsuntoInicial;
			public DateTime FechaAsuntoInicial 
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

			private DateTime _FechaAsuntoFinal;
			public DateTime FechaAsuntoFinal 
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

			private bool _InformacionTecnica;
			public bool InformacionTecnica 
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

			private DateTime _FechaInformacionTecnica;
			public DateTime FechaInformacionTecnica 
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

			private int _Autor_Id;
			public int Autor_Id 
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

			private int _Formato_Id;
			public int Formato_Id 
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

			private int _FormatoMontaje_Id;
			public int FormatoMontaje_Id 
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

			private string _InformacionTecnicaPor;
			public string InformacionTecnicaPor 
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

			private bool _InformacionCatalografica;
			public bool InformacionCatalografica 
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

			private DateTime _FechaInformacionCatalografica;
			public DateTime FechaInformacionCatalografica 
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

			private string _CatalogadaPor;
			public string CatalogadaPor 
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

			private string _Agencia;
			public string Agencia 
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

			private bool _Digitalizada;
			public bool Digitalizada 
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

			private int _Imagen_Id;
			public int Imagen_Id 
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

			private decimal _Avaluo;
			public decimal Avaluo 
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

			private DateTime _FechaDigitalizacion;
			public DateTime FechaDigitalizacion 
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

			private string _DigitalizadaPor;
			public string DigitalizadaPor 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

			private string _Observaciones;
			public string Observaciones 
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

			private bool _PublicarEnInternet;
			public bool PublicarEnInternet 
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

			private int _Epoca_Id;
			public int Epoca_Id 
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

			private int _UltimoMovimiento_Id;
			public int UltimoMovimiento_Id 
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

			private int _Aseguramiento_Id;
			public int Aseguramiento_Id 
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

			private bool _EsPiezaTemporal;
			public bool EsPiezaTemporal 
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

			private int _UltimaIntervencion_Id;
			public int UltimaIntervencion_Id 
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

			private int _EpocaNL_Id;
			public int EpocaNL_Id 
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

			private bool _InformacionPersonajesCompletada;
			public bool InformacionPersonajesCompletada 
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
		private Conarte.Entities.Color _Color;
		public Color Color 
		{
			get { return _Color; }
			set { _Color = value; }
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
		private Conarte.Entities.EpocaNL _EpocaNL;
		public EpocaNL EpocaNL 
		{
			get { return _EpocaNL; }
			set { _EpocaNL = value; }
		}
#endregion
	} // end class
	
	public partial class FotografiasEtiquetasMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

			private int _Etiqueta_Id;
			public int Etiqueta_Id 
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
	} // end class
	
	public partial class FotografiasEventosDeUsoMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

			private int _EventoDeUso_Id;
			public int EventoDeUso_Id 
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

#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
	} // end class
	
	public partial class FotografiasImagenesMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

			private int _Imagen_Id;
			public int Imagen_Id 
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

#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
	} // end class
	
	public partial class FotografiasPersonajesMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

			private int _Personaje_Id;
			public int Personaje_Id 
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
	} // end class
	
	public partial class Imagene 
	{
		
			private int _Id;
			public int Id 
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

			private string _NombreOriginal;
			public string NombreOriginal 
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

			private string _Directorio;
			public string Directorio 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
	} // end class
	
	public partial class Intervencione 
	{
		
			private int _Id;
			public int Id 
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

			private int _Tipo;
			public int Tipo 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

			private string _IntervencionPor;
			public string IntervencionPor 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

			private string _Observaciones;
			public string Observaciones 
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

#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
	} // end class
	
	public partial class IntervencionesDeteriorosMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Intervencion_Id;
			public int Intervencion_Id 
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

			private int _Deterioro_Id;
			public int Deterioro_Id 
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

#region BelongsToRelationShips
		private Conarte.Entities.Deterioro _Deterioro;
		public Deterioro Deterioro 
		{
			get { return _Deterioro; }
			set { _Deterioro = value; }
		}
#endregion
	} // end class
	
	public partial class IntervencionesTiposIntervencionMap 
	{
		
			private int _Id;
			public int Id 
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

			private int _Intervencion_Id;
			public int Intervencion_Id 
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

			private int _TipoIntervencion_Id;
			public int TipoIntervencion_Id 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Interventore 
	{
		
			private int _Id;
			public int Id 
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

			private string _Iniciales;
			public string Iniciales 
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

			private string _Nombre;
			public string Nombre 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Lugare 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Personaje 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class ProcesosFotografico 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private string _Clave;
			public string Clave 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Seguro 
	{
		
			private int _Id;
			public int Id 
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

			private int _Fotografia_Id;
			public int Fotografia_Id 
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

			private string _EmpresaAseguradora;
			public string EmpresaAseguradora 
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

			private string _NumeroPoliza;
			public string NumeroPoliza 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

#region BelongsToRelationShips
		private Conarte.Entities.Fotografia _Fotografia;
		public Fotografia Fotografia 
		{
			get { return _Fotografia; }
			set { _Fotografia = value; }
		}
#endregion
	} // end class
	
	public partial class Serie 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class SituacionesLegale 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class SubUbicacione 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private int _Ubicacion_Id;
			public int Ubicacion_Id 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class TiposDeMovimiento 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class TiposDeReproduccion 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class TiposDeUso 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class TiposIntervencione 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private string _Clave;
			public string Clave 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class TiposMateriale 
	{
		
			private int _Id;
			public int Id 
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

			private string _Descripcion;
			public string Descripcion 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _FechaCreacion;
			public DateTime FechaCreacion 
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

			private string _CreadoPor;
			public string CreadoPor 
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

			private DateTime _FechaModificacion;
			public DateTime FechaModificacion 
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

			private string _ModificadoPor;
			public string ModificadoPor 
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

#region BelongsToRelationShips
#endregion
	} // end class
	
	public partial class Usuario 
	{
		
			private int _Id;
			public int Id 
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

			private string _Login;
			public string Login 
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

			private string _Password;
			public string Password 
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

			private string _NombreCompleto;
			public string NombreCompleto 
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

			private string _CorreoElectronico;
			public string CorreoElectronico 
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

			private bool _Activo;
			public bool Activo 
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

			private DateTime _BloqueadoEn;
			public DateTime BloqueadoEn 
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

			private bool _Bloqueado;
			public bool Bloqueado 
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

			private int _IntentosFallidos;
			public int IntentosFallidos 
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

			private DateTime _UltimaAutenticacion;
			public DateTime UltimaAutenticacion 
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

			private DateTime _FechaRegistro;
			public DateTime FechaRegistro 
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

			private bool _AccesoConfirmado;
			public bool AccesoConfirmado 
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

			private DateTime _FechaConfirmacion;
			public DateTime FechaConfirmacion 
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

			private bool _DeseaRecibirNotificaciones;
			public bool DeseaRecibirNotificaciones 
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

#region BelongsToRelationShips
#endregion
	} // end class
	} // end namespace

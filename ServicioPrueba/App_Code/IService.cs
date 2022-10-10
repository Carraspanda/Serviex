using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    [OperationContract]
    string Adicionar(TUsuario fUsuario);

    [OperationContract]
    string Modificar(TUsuario fUsuario);

    [OperationContract]
    DataSet Consultar();

    [OperationContract]
    string Eliminar(int idUsuario);
    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class TUsuario
{
    int fid = -1;
    string fNombre;
    DateTime fFecha;
    char fSexo;

    [DataMember]
	public int ID
    {
		get { return fid; }
		set { fid = value; }
	}

    [DataMember]
    public string Nombre
    {
        get { return fNombre; }
        set { fNombre = value; }
    }

    [DataMember]
    public DateTime Fecha
    {
        get { return fFecha; }
        set { fFecha = value; }
    }

    [DataMember]
	public char Sexo
	{
		get { return fSexo; }
		set { fSexo = value; }
	}
}

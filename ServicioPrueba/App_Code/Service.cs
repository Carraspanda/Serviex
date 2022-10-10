using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    public string Adicionar(TUsuario fUsuario)
    {
        int iAfectados = 0;
        SqlCommand cmd = new SqlCommand();
        SqlConnection con;
        con = new SqlConnection("server=LAPTOP-EJBF7GCJ\\SQLEXPRESS ; database=serviex ; integrated security = true");
        cmd.CommandText = "INSERT INTO usuario(nombre, fecha, sexo) VALUES (@Nombre, @Fecha, @Sexo);";
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = fUsuario.Nombre;
        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fUsuario.Fecha;
        cmd.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = fUsuario.Sexo;
        cmd.Connection = con;
        con.Open();
        iAfectados = cmd.ExecuteNonQuery();
        return iAfectados.ToString()+" registros insertados";
    }

    public string Modificar(TUsuario fUsuario)
    {
        int iAfectados = 0;
        SqlCommand cmd = new SqlCommand();
        SqlConnection con;
        con = new SqlConnection("server=LAPTOP-EJBF7GCJ\\SQLEXPRESS ; database=serviex ; integrated security = true");
        cmd.CommandText = "UPDATE usuario SET nombre=@Nombre, fecha=@Fecha, sexo=@Sexo WHERE id=@ID;";
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fUsuario.ID;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = fUsuario.Nombre;
        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fUsuario.Fecha;
        cmd.Parameters.Add("@Sexo", SqlDbType.Char, 1).Value = fUsuario.Sexo;
        cmd.Connection = con;
        con.Open();
        iAfectados = cmd.ExecuteNonQuery();
        return iAfectados.ToString() + " registros afectados";
    }

    public DataSet Consultar()
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con;
        con = new SqlConnection("server=LAPTOP-EJBF7GCJ\\SQLEXPRESS ; database=serviex ; integrated security = true");
        cmd.CommandText = "SELECT * FROM usuario";
        cmd.Connection = con;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Open();
        cmd.ExecuteNonQuery();
        return ds;
    }

    public string Eliminar(int idUsuario)
    {
        int iAfectados = 0;
        SqlCommand cmd = new SqlCommand();
        SqlConnection con;
        con = new SqlConnection("server=LAPTOP-EJBF7GCJ\\SQLEXPRESS ; database=serviex ; integrated security = true");
        cmd.CommandText = "DELETE FROM usuario WHERE id=@ID;";
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = idUsuario;
        cmd.Connection = con;
        con.Open();
        iAfectados = cmd.ExecuteNonQuery();
        return iAfectados.ToString() + " registros eliminados";
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ServicioCRUD;

public partial class _Default : Page
{
    public ServiceClient WSClient = new ServiceClient();

    public DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mensaje"] != "" && Session["Mensaje"]!=null)
        {
            lblMensaje.Text = Session["Mensaje"].ToString();
            sMensaje.Visible = true;
            Session["Mensaje"] = "";
        }
        else
        {
            sMensaje.Visible = false;
            Session["Mensaje"] = "";
        }
        if (!Page.IsPostBack)
        {
            ConsultarDatos();
        }
    }

    public void ConsultarDatos()
    {
        ds = WSClient.Consultar();
        Grid.DataSource = ds;
        Grid.DataBind();
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }

    protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        Grid.SelectedIndex = -1;
        Grid.CurrentPageIndex = e.NewPageIndex;
        Pagina.Text = "Página "+(Grid.CurrentPageIndex+1).ToString();
        ConsultarDatos();
    }
    protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Grid.EditItemIndex = e.Item.ItemIndex;
        ConsultarDatos();
    }
    protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
    {
        Grid.EditItemIndex = -1;
        ConsultarDatos();
    }
    protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        MsgBox("Registro eliminado", this.Page, this);
    }
    protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Grid.EditItemIndex = -1;
        ConsultarDatos();
    }

    private void DescargarDocumento(String ruta)
    {
        String sArchivo;
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "csv";
        sArchivo = Path.GetFileName(ruta).ToString();
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + sArchivo);
        HttpContext.Current.Response.TransmitFile(ruta);
        HttpContext.Current.Response.End();
    }

    private void GenerarArchivo(DataSet Datos)
    {
        string nombreArchivo = "C:\\Temp/Archivo.csv";

        using (FileStream flujoArchivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            using (StreamWriter Escritor = new StreamWriter(flujoArchivo))
            {
                for (int I = 0; I < Datos.Tables[0].Columns.Count; I++)
                {
                    Escritor.Write(Grid.Columns[I].HeaderText + ";");
                }
                Escritor.WriteLine();
                foreach (DataRow Registro in Datos.Tables[0].Rows)
                {
                    for(int I=0; I<Datos.Tables[0].Columns.Count; I++)
                    {
                        Escritor.Write(Registro[I] + ";");
                    }
                    Escritor.WriteLine();
                }
            }
        }
    }

    protected void Adicionar_Click(object sender, EventArgs e)
    {
        Response.Redirect("UsuarioGestiona.aspx?accion=Adicionar",false);
    }

    protected void Modificar_Click(object sender, EventArgs e)
    {
        if (Grid.SelectedIndex != -1)
        {
            Session["ID"] = Grid.DataKeys[Grid.SelectedIndex];
            Session["Nombre"] = Grid.SelectedItem.Cells[0].Text;
            Session["Fecha"] = Grid.SelectedItem.Cells[1].Text;
            Session["Sexo"] = Grid.SelectedItem.Cells[2].Text;

            Response.Redirect("UsuarioGestiona.aspx?accion=Modificar", false);
        }
        else
        {
            //MsgBox("Esta funcion no se puede ejecutar si no se ha seleccionado ningun Usuario", this.Page, this);
        }
    }

    protected void Eliminar_Click(object sender, EventArgs e)
    {
        if (Grid.SelectedIndex != -1)
        {
            Session["ID"] = Grid.DataKeys[Grid.SelectedIndex];
            Session["Nombre"] = Grid.SelectedItem.Cells[0].Text;
            Session["Fecha"] = Grid.SelectedItem.Cells[1].Text;
            Session["Sexo"] = Grid.SelectedItem.Cells[2].Text;

            Response.Redirect("UsuarioGestiona.aspx?accion=Eliminar");
        }
        else
        {
            //MsgBox("Esta funcion no se puede ejecutar si no se ha seleccionado ningun Usuario", this.Page, this);
        }
    }

    protected void Descargar_Click(object sender, EventArgs e)
    {
        ConsultarDatos();
        GenerarArchivo(ds);
        DescargarDocumento("C:\\Temp/Archivo.csv");
    }
}
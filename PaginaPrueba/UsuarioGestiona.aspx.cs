using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioCRUD;

public partial class UsuarioGestiona : System.Web.UI.Page
{
    public ServiceClient WSCliente;
    public TUsuario fUsuario;
    public string sAccion;
    protected void Page_Load(object sender, EventArgs e)
    {
        sAccion = Request.QueryString["accion"];
        if (!Page.IsPostBack)
        {
            if(sAccion == "Modificar" || sAccion == "Eliminar")
            {

                Nombre.Text = Session["Nombre"].ToString();
                Fecha.SelectedDate = Convert.ToDateTime(Session["Fecha"].ToString());
                Fecha.VisibleDate = Convert.ToDateTime(Session["Fecha"].ToString());
                Sexo.SelectedValue = Session["Sexo"].ToString();
            }
            else
            {
                Nombre.Text = "";
                Fecha.SelectedDate = DateTime.Today;
                Fecha.VisibleDate = DateTime.Today;
                Sexo.SelectedIndex = 0;
            }
        }
    }

    protected void Confimar_Click(object sender, EventArgs e)
    {
        WSCliente = new ServiceClient();
        fUsuario = new TUsuario();
        fUsuario.Nombre = Nombre.Text;
        fUsuario.Fecha = Fecha.SelectedDate;
        fUsuario.Sexo = Sexo.SelectedValue.ToString().First();
        string sRespuesta = "";
        if (sAccion == "Adicionar")
        {
            fUsuario.ID = 0;
            sRespuesta = WSCliente.Adicionar(fUsuario);
        }
        if (sAccion == "Modificar")
        {
            fUsuario.ID = Convert.ToInt32(Session["ID"].ToString());
            sRespuesta = WSCliente.Modificar(fUsuario);
        }
        if (sAccion == "Eliminar")
        {
            fUsuario.ID = Convert.ToInt32(Session["ID"].ToString());
            sRespuesta = WSCliente.Eliminar(fUsuario.ID);
        }
        Session["Mensaje"]=sRespuesta;
        Response.Redirect("Usuario.aspx");
    }

    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }
}
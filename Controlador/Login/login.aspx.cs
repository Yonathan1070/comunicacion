using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vista_Login_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == "" || txtClave.Text == "")
        {
            lblMensaje.Text = "Hay Campos Vacios.";
        }
        else
        {
            EUser user = new EUser();
            DAOUsersConsultar daoUserConsultar = new DAOUsersConsultar();
            
            user.Usuario = txtUserName.Text;
            user.Clave = txtClave.Text;

            DataTable logUser = daoUserConsultar.login(user);

            if (logUser.Rows.Count > 0)
            {
                Session["usuario"] = txtUserName.Text;
                Session["clave"] = txtClave.Text;
                Response.Redirect("../Usuario/Inicio.aspx");
            }
            else
            {
                lblMensaje.Text = "El Usuario No se Encuentra Registrado";
            }
        }
    }
    protected void linkRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registrar.aspx");
    }
}
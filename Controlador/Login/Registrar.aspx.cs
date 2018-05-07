using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vista_Login_Registrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        if (txtDocumento.Text == "" &&
            txtNombre.Text == "" &&
            txtApellido.Text == "" &&
            txtUserName.Text == "" &&
            txtClave.Text == "")
        {
            lblMensaje.Text = "Hay Campos Vacios!";
        }
        else
        {
            EUser user = new EUser();
            DAOUsersInsertar daoUserInsertar = new DAOUsersInsertar();
            DAOUsersConsultar daoUserConsultar = new DAOUsersConsultar();
            user.Documento = txtDocumento.Text;
            DataTable consulta = daoUserConsultar.consultarUsuario(user);
            if (consulta.Rows.Count > 0)
            {
                lblMensaje.Text = "El Usuario " + txtNombre.Text + " " + txtApellido.Text + " ya se encuentra Registrado";
            }
            else
            {
                user.Documento = txtDocumento.Text;
                user.Nombres = txtNombre.Text;
                user.Apellidos = txtApellido.Text;
                user.Usuario = txtUserName.Text;
                user.Clave = txtClave.Text;

                daoUserInsertar.registrarUsuario(user);
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void linkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}
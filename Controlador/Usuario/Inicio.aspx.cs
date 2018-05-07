using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Vista_Usuario_Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null && Session["clave"] == null)
        {
            Response.Redirect("../Login/login.aspx");
        }
        else
        {
            EUser user = new EUser();
            DAOUsersConsultar daoUserConsultar = new DAOUsersConsultar();

            user.Usuario = Session["usuario"].ToString();
            user.Clave = Session["clave"].ToString();
            DataTable usuario = daoUserConsultar.login(user);

            if (lblUsername.Text == "" && usuario.Rows.Count > 0)
            {
                lblUsername.Text = usuario.Rows[0]["nombres_persona"].ToString() + " " + usuario.Rows[0]["apellidos_persona"].ToString();
                lblDocumento.Text = usuario.Rows[0]["documento_persona"].ToString();
            }
        }
    }
    protected void btnPublicar_Click(object sender, EventArgs e)
    {
        if (FUImagen.HasFile == false && txtComentario.Text == "")
        {
            lblMensaje.Text = "Seleccione una Imagen o Realice un Comentario";
            lblMensaje.Visible = true;
        }
        else if ((FUImagen.HasFile == false && txtComentario.Text != "") ||
            (FUImagen.HasFile == true && txtComentario.Text == "") ||
            (FUImagen.HasFile == true && txtComentario.Text != ""))
        {
            EUser user = new EUser();
            DAOUsersInsertar daoUserInsertar = new DAOUsersInsertar();

            user.Documento = lblDocumento.Text;
            user.Comentario = txtComentario.Text;
            user.Foto = cargarFoto();
            user.Fecha = DateTime.Now;

            daoUserInsertar.registrarFoto(user);
            //Response.Write("<script>alert('Foto de Perfil Se Actualizó';window.location.href='../../vista/UsuarioL/InicioUsuario.aspx'</script>");
            Response.Redirect("Inicio.aspx");
        }
    }
    protected String cargarFoto()
    {
        String url = "";
        ClientScriptManager cm = this.ClientScript;
        string nombreArchivo = System.IO.Path.GetFileName(FUImagen.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FUImagen.PostedFile.FileName);

        string saveLocation = Server.MapPath("~\\Fotos") + "\\" + nombreArchivo;
        url = "~\\Fotos" + "\\" + nombreArchivo;
        if (!(extension.Equals(".jpg") || extension.Equals(".jpge") || extension.Equals(".png")))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Tipo de archivo no valido');</script>");
        }

        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo en el servidor con ese nombre');</script>");
        }

        try
        {
            FUImagen.PostedFile.SaveAs(saveLocation);
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo ha sido cargado');</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Error: ');</script>");
        }
        return url;
    }
    protected void linkPerfil_Click(object sender, EventArgs e)
    {

    }
    protected void linkCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["usuario"] = null;
        Session["clave"] = null;
        Response.Redirect("../Login/login.aspx");
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "comentarFoto")
        {
            TextBox txt = (TextBox)(e.Item.FindControl("txtComentarioFoto"));
            if (txt.Text == "")
            {
                lblMensaje.Text = "Debe realizar un Comentario.";
            }
            else
            {
                EUser user = new EUser();
                DAOUsersInsertar daoUserInsertar = new DAOUsersInsertar();


                user.Comentario = txt.Text;
                user.IdFoto = e.CommandArgument.ToString();
                user.Fecha = DateTime.Now;
                user.Documento = lblDocumento.Text;

                daoUserInsertar.registrarComentario(user);
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}
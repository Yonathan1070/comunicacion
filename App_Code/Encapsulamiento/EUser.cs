using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EUser
/// </summary>
public class EUser
{
	public EUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //Encapsulamiento Registro
    private String documento;

    public String Documento
    {
        get { return documento; }
        set { documento = value; }
    }

    private String nombres;

    public String Nombres
    {
        get { return nombres; }
        set { nombres = value; }
    }

    private String apellidos;

    public String Apellidos
    {
        get { return apellidos; }
        set { apellidos = value; }
    }

    //Encapsulamiento Logueo
    private String usuario;

    public String Usuario
    {
        get { return usuario; }
        set { usuario = value; }
    }

    private String clave;

    public String Clave
    {
        get { return clave; }
        set { clave = value; }
    }

    //Encapsulamiento Subir Foto
    private String foto;

    public String Foto
    {
        get { return foto; }
        set { foto = value; }
    }

    private String comentario;

    public String Comentario
    {
        get { return comentario; }
        set { comentario = value; }
    }

    private DateTime fecha;

    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }

    //Encapsulamiento Comnetario
    private String idFoto;

    public String IdFoto
    {
        get { return idFoto; }
        set { idFoto = value; }
    }
}
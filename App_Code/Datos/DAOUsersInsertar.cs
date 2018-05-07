using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOUsersInsertar
/// </summary>
public class DAOUsersInsertar
{
	public DAOUsersInsertar()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //Registrar Usuario
    public DataTable registrarUsuario(EUser user)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_insertar_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            dataAdapter.SelectCommand.Parameters.Add("_documento", NpgsqlDbType.Varchar).Value = user.Documento;
            dataAdapter.SelectCommand.Parameters.Add("_nombres", NpgsqlDbType.Varchar).Value = user.Nombres;
            dataAdapter.SelectCommand.Parameters.Add("_apellidos", NpgsqlDbType.Varchar).Value = user.Apellidos;
            dataAdapter.SelectCommand.Parameters.Add("_usuario", NpgsqlDbType.Varchar).Value = user.Usuario;
            dataAdapter.SelectCommand.Parameters.Add("_clave", NpgsqlDbType.Varchar).Value = user.Clave;

            conectar.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conectar != null)
            {
                conectar.Close();
            }
        }
        return Usuario;
    }

    //Registrar Fotos
    public DataTable registrarFoto(EUser user)
    {
        DataTable Foto = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("fotos.f_insertar_foto", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            dataAdapter.SelectCommand.Parameters.Add("_documento", NpgsqlDbType.Varchar).Value = user.Documento;
            dataAdapter.SelectCommand.Parameters.Add("_comentario", NpgsqlDbType.Text).Value = user.Comentario;
            dataAdapter.SelectCommand.Parameters.Add("_dir", NpgsqlDbType.Text).Value = user.Foto;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Timestamp).Value = user.Fecha;

            conectar.Open();
            dataAdapter.Fill(Foto);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conectar != null)
            {
                conectar.Close();
            }
        }
        return Foto;
    }

    //Registrar Comentarios
    public DataTable registrarComentario(EUser user)
    {
        DataTable comentario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("comentarios.f_insertar_comentario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            dataAdapter.SelectCommand.Parameters.Add("_comentario", NpgsqlDbType.Text).Value = user.Comentario;
            dataAdapter.SelectCommand.Parameters.Add("_id_foto", NpgsqlDbType.Bigint).Value = user.IdFoto;
            dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Timestamp).Value = user.Fecha;
            dataAdapter.SelectCommand.Parameters.Add("_usuario", NpgsqlDbType.Varchar).Value = user.Documento;

            conectar.Open();
            dataAdapter.Fill(comentario);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conectar != null)
            {
                conectar.Close();
            }
        }
        return comentario;
    }
}
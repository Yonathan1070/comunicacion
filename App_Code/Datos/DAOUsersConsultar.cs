using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAOUsersConsultar
/// </summary>
public class DAOUsersConsultar
{
	public DAOUsersConsultar()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //Consultar Usuario
    public DataTable consultarUsuario(EUser user)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_consultar_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            dataAdapter.SelectCommand.Parameters.Add("_documento", NpgsqlDbType.Varchar).Value = user.Documento;

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

    //Login
    public DataTable login(EUser user)
    {
        DataTable Usuario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuarios.f_login_usuario", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

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

    //Consultar Fotos
    public DataTable fotos()
    {
        DataTable Fotos = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("fotos.f_consultar_fotos", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conectar.Open();
            dataAdapter.Fill(Fotos);
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
        return Fotos;
    }

    //Consulta Comentarios
    public DataTable comentariosFoto(String user)
    {
        DataTable comentario = new DataTable();
        NpgsqlConnection conectar = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

        try
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("comentarios.f_consultar_comentarios", conectar);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            Int32 id = Int32.Parse(user);
            dataAdapter.SelectCommand.Parameters.Add("_id_foto", NpgsqlDbType.Bigint).Value = id;

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EjemploCRUD.Models
{
    public class EstudianteModel
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public bool agregarEstudiante(Estudiante estudiante)
        {
            try
            {
                SqlCommand com = new SqlCommand("insertarEstudiante", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@carnet", estudiante.Carnet);
                com.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                com.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                com.Parameters.AddWithValue("@sexo", estudiante.Sexo);
                com.Parameters.AddWithValue("@edad", estudiante.Edad);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool modificarEstudiante(Estudiante estudiante)
        {
            try
            {
                SqlCommand com = new SqlCommand("modificarEstudiante", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", estudiante.ID1);
                com.Parameters.AddWithValue("@carnet", estudiante.Carnet);
                com.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                com.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                com.Parameters.AddWithValue("@sexo", estudiante.Sexo);
                com.Parameters.AddWithValue("@edad", estudiante.Edad);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarEstudiante(Estudiante estudiante)
        {
            try
            {
                SqlCommand com = new SqlCommand("eliminarEstudiante", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", estudiante.ID1);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataSet mostrarEstudiantes()
        {
            try
            {
                SqlCommand com = new SqlCommand("mostrarEstudiantes", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }

        public DataSet mostrarEstudiante(int id)
        {
            SqlCommand com = new SqlCommand("mostrarEstudiante", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
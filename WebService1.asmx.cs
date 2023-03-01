using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSconexion.Modelo;

namespace WSconexion
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet ConsultarEstudiantes()
        {
            string cadenaDeConexion = "Data Source=.; Initial catalog=WEBII; User id=UserUniversity; Password=Cali1930**@";
            using (SqlConnection cn = new SqlConnection(cadenaDeConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Estudiantes", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public Estudiante ConsultarEstudiantesId(string ID)
        {
            string cadenaDeConexion1 = "Data Source=.; Initial catalog=WEBII; User id=UserUniversity; Password=Cali1930**@";
            using (SqlConnection cn = new SqlConnection(cadenaDeConexion1))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select ID from Estudiante where ID = '" + ID + "'", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Estudiante estudiante = new Estudiante();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    estudiante.ID = dr["ID"].ToString();

                    estudiante.Nombre = dr["Nombre"].ToString();
                    estudiante.Apellido = dr["Apellido"].ToString();
                    estudiante.Email = dr["Email"].ToString();
                    estudiante.Direccion = dr["Direccion"].ToString();
                    estudiante.Telefono = dr["Telefono"].ToString();
                    estudiante.Carrera = dr["Carrera"].ToString();
                }
                return estudiante;
            }
        }
        [WebMethod]
        public DataSet ConsultarCarrera(string id)
        {
            string cadenaDeConexion = "Data Source=.; Initial catalog=University; User id=UserUniversity; Password=Cali1930**@";
            using (SqlConnection cn = new SqlConnection(cadenaDeConexion))
            {
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select CourseID, Title, Credits from Course where CourseID = '" + id + "'", cn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }

        }

        [WebMethod]

        public void InsertarEstudiante(string Nombre, string Apellido, string Email, string Direccion, string Telefono, string Carrera)
        {
            string cadenaDeConexion = "Data Source=.; Initial catalog=WEBII; User id=UserUniversity; Password=Cali1930**@";
            using (SqlConnection cn = new SqlConnection(cadenaDeConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "INSERT INTO student (Nombre, Apellido, Email, direccion, Telefono, Carrera) VALUES (@Nombre, @Apellido, @Email, @Direccion, @Telefono, @Carrera)";

                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Carrera", Carrera);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        [WebMethod]
        public Student EliminarEstudiantes(string id)

        {
            String cadenaDeConexion = "Data Source=.; Initial catalog=WEBII; User id=UserUniversity; Password=Cali1930**@";
            using (SqlConnection cn = new SqlConnection(cadenaDeConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("Delete from Student where ID = '" + id + "'", cn);

                DataSet ds = new DataSet();
                da.Fill(ds);
                Student student = new Student();

                return student;
            }


        }
        [WebMethod]
        public void ActualizarEstudiantes(string ID, string Nombre, string Apellido, string Email, string Direccion, string 
            Telefono, string Celular, string Carrera)
        {
            String cadenaDeConexion = "Data Source=.; Initial catalog=WEBII; User id=UserUniversity; Password=Cali1930**@";
            using (SqlConnection cn = new SqlConnection(cadenaDeConexion))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE estudiante SET  Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Direccion=@Direccion, Telefono=@Telefono, Celular=@Celular, Carrera=@Carrera  WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Carrera", Carrera);
                    cmd.ExecuteNonQuery();
                }
               
            }
            
        }
        
    }
}
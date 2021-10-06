using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiResSqlServer
{
    public class StorageSQL
    {
        public List<Alumnos> ListadeAlumnos;
        public List<Alumnos> Consulta(int Matricula)
        {
            var dt = new DataTable();
            var connect = new SqlConnection("data source=DIANASLAPTOP\\DIANASERVER; Initial Catalog=Información2021; user ID=sa; Password=Dianastaystoned1;");
            var cmd = new SqlCommand("EXEC ConsultarRegistro '" + Matricula + "'", connect);
            try
            {
                ListadeAlumnos = new List<Alumnos>();
                connect.Open();
                 var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();
                Alumnos alumno = new Alumnos();
                alumno.Matricula = int.Parse((dt.Rows[0]["Matricula"]).ToString());
                alumno.Nombre = (dt.Rows[0]["Nombre"]).ToString();
                alumno.Carrera = (dt.Rows[0]["Carrera"]).ToString();
                alumno.Semestre = (dt.Rows[0]["Semestre"]).ToString();
                alumno.Saldo = double.Parse((dt.Rows[0]["Saldo"]).ToString());
                ListadeAlumnos.Add(alumno);
                return ListadeAlumnos;
            }
            catch (Exception ex)
            {
                connect.Close();
                return ListadeAlumnos;
            }
        }
        public bool Almacenar(string Nombre, string Carrera, string Semestre, double Saldo)
        {
            var connect = new SqlConnection("data source=DIANASLAPTOP\\DIANASERVER; Initial Catalog=Información2021; user ID=sa; Password=Dianastaystoned1");
            var query = new SqlCommand("EXEC Guardar '" + Nombre + "','" + Carrera + "','" + Semestre + "','" + Saldo + "'", connect);
            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception)
            {
                connect.Close();
                return false;
            }
        }
    }
}

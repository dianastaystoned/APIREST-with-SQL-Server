using Microsoft.AspNetCore.Mvc;

namespace ApiResSqlServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : Controller
    {
        [HttpGet("ConsultarSQLServer")]
        public JsonResult Consultar(int Matricula)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.Consulta(Matricula);
            return Json(Lista);
        }
        [HttpGet("AlmacenarSQLServer")]
        public string Almacenar(string Nombre, string Carrera, string Semestre, double Saldo)
        {
            var Almacena = new StorageSQL();
            bool resultado = Almacena.Almacenar(Nombre, Carrera, Semestre, Saldo);
            if (resultado == true)
            {
                return "Almacenado en SQL Server desde .NET 5";
            }
            else
            {
                return "Error: Datos no almacenados";
            }
        }
    }
}

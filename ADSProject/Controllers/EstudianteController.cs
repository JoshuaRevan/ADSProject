using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ADSProject.Controllers
{
    [Route("api/estudiante/")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public EstudianteController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;

        }
    
    
        [HttpPost("agregarEstudiante")]

        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                int contador = this.estudiante.AgregarEstudiante(estudiante);
                if (contador == 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Exito insertado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                } else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });

            }
            catch (Exception)
            {
                throw;

            }

        }
        [HttpPost("ActualizarEstudiante/{idEstudiante}")]
        
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante) 
        {
            try
            {
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);
                if (contador > 0) 
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado coon exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch(Exception) 
            { 
                throw; 
            
            }
        
        
        
        }

        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro elininado con exito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + "|| " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("ObtenerEstudiantesPorID/{idEstudiante}")]

        public ActionResult<Estudiante> ObtenerEstudiante (int idEstuadiante) 
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantesPorID(idEstuadiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch
            {

                throw;
            }
        }
        [HttpGet("ObtenerEstudiante")]

        public ActionResult<List<Estudiante>> ObtenerEstudiante()
        {
            try 
            {
                List<Estudiante> lstEstudiante = this.estudiante.ObtenerTodosLosEstudiantes();

                return Ok(lstEstudiante);   
            }
            catch 
            {
                throw;
            }
        }
    }

}

using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/materia")]
    public class MateriasController : ControllerBase
    {
        private readonly IMateria materia;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public MateriasController(IMateria materia)
        {
            this.materia = materia;
        }


        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materia materia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.materia.AgregarMateria(materia);
                if (contador == 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Exito insertado con exito";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
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

        [HttpPut("ActualizarMateria/{IdMateria}")]
        public ActionResult<string> ActualizarEstudiante(int IdMateria, [FromBody] Materia materia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.materia.ActualizarMateria(IdMateria, materia);
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
            catch (Exception)
            {
                throw;

            }



        }

        [HttpDelete("EliminarMateria/{IdMateria}")]
        public ActionResult<string> EliminarMateria(int IdMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(IdMateria);
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

        [HttpGet("ObtenerMateriasporId/{IdMateria}")]
        public ActionResult<Materia> ObtenerMateriasporId(int IdMateria)
        {
            try
            {
                Materia materia = this.materia.ObtenerMateriasporId(IdMateria);
                if (materia != null)
                {
                    return Ok(materia);
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

        [HttpGet("ObtenerMaterias")]
        public ActionResult<List<Materia>> ObtenerTodosLasMaterias()
        {
            try
            {
                List<Materia> lstMateria = this.materia.ObtenerTodosLasMaterias();

                return Ok(lstMateria);
            }
            catch
            {
                throw;
            }
        }
    }
}

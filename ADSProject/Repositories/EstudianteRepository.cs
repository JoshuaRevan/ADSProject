using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        /*private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
            new Estudiante{ IdEstudiante = 1, NombresEstudiantes = "Juan Carlos",
            ApellidosEstudiante = "Perez Sosa", CodigoEstudiante = "PS24I04002",
            CorreoEstudiante = "PS24I04002@usonsonate.edu.sv"

            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;

        public EstudianteRepository(ApplicationDbContext applicationDbContext) 
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                applicationDbContext.Entry(item).CurrentValues.SetValues(estudiante);

                applicationDbContext.SaveChanges();

                return idEstudiante;
            }
            catch (Exception) 
            {
                throw;
            }
        }


        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                /*/if (lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                }
                lstEstudiantes.Add(estudiante);*/
                applicationDbContext.Estudiantes.Add(estudiante);
                applicationDbContext.SaveChanges();

                return estudiante.IdEstudiante;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool EliminarEstudiante(int IdEstudiante)
        {
            try
            {
                // ontenemos el indice del objeto a eliminar
                /*int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == IdEstudiante);
                // procedemos a eliminar el registro
                lstEstudiantes.RemoveAt(indice);*/
                var item = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == IdEstudiante);

                applicationDbContext.Estudiantes.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante ObtenerEstudiantesPorID(int IdEstudiante)
        {
            try 
            {
                //Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == IdEstudiante);
                var estudiante = applicationDbContext.Estudiantes.SingleOrDefault(x => x.IdEstudiante == IdEstudiante);

                return estudiante;
            }
            catch 
            {
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try 
            {
                return applicationDbContext.Estudiantes.ToList();
            
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}

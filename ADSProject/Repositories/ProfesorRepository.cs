using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository: IProfesor
    {
        /* private List<Profesor> lstProfesor = new List<Profesor>
         {
             new Profesor
             {
                 IdProfesor = 1, NombresProfesor="Édgar Ricardo ", ApellidosProfesor="Arjona Morales", 
                 Email = "Ricardo.Arjona0203@gmail.com"
             }
         };*/
        private readonly ApplicationDbContext apllicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.apllicationDbContext = applicationDbContext;
        }
        public int ActualizarProfesor(int IdProfesor, Profesor profesor)
        {
            try
            {
                /*int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == IdProfesor);
                lstProfesor[indice] = profesor;*/
                var item = apllicationDbContext.profesores.SingleOrDefault(x => x.IdProfesor == IdProfesor);

                apllicationDbContext.Entry(item).CurrentValues.SetValues(profesor);

                apllicationDbContext.SaveChanges();

                return IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
               /* if (lstProfesor.Count > 0) 
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor =
               lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(profesor);*/

                apllicationDbContext.profesores.Add(profesor);
                apllicationDbContext.SaveChanges() ;

                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public List<Profesor> ObtenertodasLosProfesores()
        {
            try
            {
               // return lstProfesor;
               return apllicationDbContext.profesores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int IdProfesor)
        {
            try
            {
                /*int Indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == IdProfesor);
                lstProfesor.RemoveAt(Indice);*/
                var item = apllicationDbContext.profesores.SingleOrDefault(x => x.IdProfesor == IdProfesor);

                apllicationDbContext.profesores.Remove(item);

                apllicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Profesor ObtenerProfesoresPorId(int IdProfesor)
        {
            try
            {
                // Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == IdProfesor);
                var profesor = apllicationDbContext.profesores.SingleOrDefault(x => x.IdProfesor == IdProfesor);

                return profesor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

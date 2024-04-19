using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository: IProfesor
    {
        private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor
            {
                IdProfesor = 1, NombresProfesor="Édgar Ricardo ", ApellidosProfesor="Arjona Morales", 
                Email = "Ricardo.Arjona0203@gmail.com"
            }
        };
        public int ActualizarProfesor(int IdProfesor, Profesor profesor)
        {
            try
            {
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == IdProfesor);
                lstProfesor[indice] = profesor;

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
                if (lstProfesor.Count > 0) 
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor =
               lstProfesor.Last().IdProfesor + 1;
                }
                lstProfesor.Add(profesor);
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
                return lstProfesor;
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
                int Indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == IdProfesor);
                lstProfesor.RemoveAt(Indice);
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
                Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == IdProfesor);

                return profesor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

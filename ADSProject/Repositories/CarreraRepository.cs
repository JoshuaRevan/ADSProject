using ADSProject.Interfaces;
using ADSProject.Models;


namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera
            {
                IdCarrera = 1,Codigo="Ciencias01",Nombre="Ciencias y Medio Ambiente"
            }
        };
        public int ActualizarCarrera(int IdCarrera, Carrera carrera)
        {
            try
            {
                int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);
                lstCarrera[indice] = carrera;

                return IdCarrera;
            }
            catch (Exception) 
            {
                throw;
            }
        }
        public int AgregarCarrera(Carrera carrera)
        {
            try 
            {
                if (lstCarrera.Count > 0) ;
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera =
               lstCarrera.Last().IdCarrera + 1;
                }
                lstCarrera.Add(carrera);
                return carrera.IdCarrera;
            }
            catch (Exception)
            {
                throw;
            }
            

        }

        public List<Carrera> ObtenertodasLasCarreras()
        {
            try
            {
                return lstCarrera;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public bool EliminarCarrera(int IdCarrera)
        {
            try
            {
                int Indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);
                lstCarrera.RemoveAt(Indice);
                return true;

            }
            catch(Exception)  
            {
                throw;  
            }
        }

        public Carrera ObtenerCarreraPorId(int IdCarrera) 
        {
            try
            {
                Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == IdCarrera);

                return carrera;
            }
            catch (Exception) 
            {
                throw;
            }
        }   
    }
}

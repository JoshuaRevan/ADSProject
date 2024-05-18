using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;


namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera
            {
                IdCarrera = 1,Codigo="Ciencias01",Nombre="Ciencias y Medio Ambiente"
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext= applicationDbContext;
        }
        public int ActualizarCarrera(int IdCarrera, Carrera carrera)
        {
            try
            {
               // int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);
                //lstCarrera[indice] = carrera;

                var item = applicationDbContext.carreras.SingleOrDefault(x => x.IdCarrera == IdCarrera); 

                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);

                applicationDbContext.SaveChanges();

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
               /* if (lstCarrera.Count > 0) 
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera =
               lstCarrera.Last().IdCarrera + 1;
                }
                lstCarrera.Add(carrera);*/
               applicationDbContext.carreras.Add(carrera);
                applicationDbContext.SaveChanges();

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
                return applicationDbContext.carreras.ToList();
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
                /* int Indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);
                 lstCarrera.RemoveAt(Indice);*/
                var item = applicationDbContext.carreras.SingleOrDefault(x => x.IdCarrera == IdCarrera);

                applicationDbContext.carreras.Remove(item);

                applicationDbContext.SaveChanges();
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
                // Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == IdCarrera);

                var carrera = applicationDbContext.carreras.SingleOrDefault(x => x.IdCarrera == IdCarrera);

                return carrera;
            }
            catch (Exception) 
            {
                throw;
            }
        }   
    }
}

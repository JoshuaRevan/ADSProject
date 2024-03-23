using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface ICarrera
    {
        public int AgregarCarrera(Carrera carrera);

        public int ActualizarCarrera(int IdCarrera, Carrera carrera);

        public bool EliminarCarrera(int IdCarrera);

        public List<Carrera> ObtenertodasLasCarreras();

        public Carrera ObtenerCarreraPorId(int IdCarrera);
    }
}

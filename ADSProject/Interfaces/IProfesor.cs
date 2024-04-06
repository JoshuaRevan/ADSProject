using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IProfesor
    {
        public int AgregarProfesor(Profesor profesor);

        public int ActualizarProfesor(int IdProfesor, Profesor profesor);

        public bool EliminarProfesor(int IdProfesor);

        public List<Profesor> ObtenertodasLosProfesores();

        public Profesor ObtenerProfesoresPorId(int IdProfesor);
    }
}

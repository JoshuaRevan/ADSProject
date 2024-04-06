using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IMateria
    {
        public int AgregarMateria(Materia materia);

        public int ActualizarMateria(int IdMateria, Materia materia);

        public bool EliminarMateria(int IdMateria);

        public List<Materia> ObtenerTodosLasMaterias();

        public Materia ObtenerMateriasporId(int IdMateria);
    }
}

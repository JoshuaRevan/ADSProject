using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMateria = new List<Materia>
        {
            new Materia{ IdMateria = 1, Nombremateria = "Lenguaje"

            }
        };

        public int ActualizarMateria(int IdMateria, Materia materia)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == IdMateria);

                lstMateria[indice] = materia;

                return IdMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (lstMateria.Count > 0)
                {
                    materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }
                lstMateria.Add(materia);
                return materia.IdMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool EliminarMateria(int IdMateria)
        {
            try
            {
                // ontenemos el indice del objeto a eliminar
                int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == IdMateria);
                // procedemos a eliminar el registro
                lstMateria.RemoveAt(indice);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Materia ObtenerMateriasporId(int IdMateria)
        {
            try
            {
                Materia materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == IdMateria);

                return materia;
            }
            catch
            {
                throw;
            }
        }

        public List<Materia> ObtenerTodosLasMaterias()
        {
            try
            {
                return lstMateria;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

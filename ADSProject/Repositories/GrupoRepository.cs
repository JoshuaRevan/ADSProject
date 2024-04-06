using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository:IGrupo
    {
        private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo
            {
                IdGrupo = 1,IdCarrera=1 ,IdMateria= 1,IdProfesor= 1 ,Ciclo= 1 ,Anio= 1
            }
        };
        public int ActualizarGrupo(int IdGrupo, Grupo grupo)
        {
            try
            {
                int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == IdGrupo);
                lstGrupo[indice] = grupo;

                return IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                if (lstGrupo.Count > 0) ;
                {
                    grupo.IdGrupo = lstGrupo.Last().IdGrupo =
               lstGrupo.Last().IdGrupo + 1;
                }
                lstGrupo.Add(grupo);
                return grupo.IdGrupo;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public List<Grupo> ObtenertodasLosGrupos()
        {
            try
            {
                return lstGrupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarGrupo(int IdGrupo)
        {
            try
            {
                int Indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == IdGrupo);
                lstGrupo.RemoveAt(Indice);
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Grupo ObtenerGrupoPorId(int IdGrupo)
        {
            try
            {
                Grupo grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == IdGrupo);

                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

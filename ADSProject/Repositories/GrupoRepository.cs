using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
       /* private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo
            {
                IdGrupo = 1,IdCarrera=1 ,IdMateria= 1,IdProfesor= 1 ,Ciclo= 1 ,Anio= 1
            }
        };*/
       private readonly ApplicationDbContext applicationDbContext;

        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarGrupo(int IdGrupo, Grupo grupo)
        {
            try
            {
                //int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == IdGrupo);
                //lstGrupo[indice] = grupo;
                var item = applicationDbContext.grupos.SingleOrDefault(x => x.IdGrupo == IdGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupo);

                applicationDbContext.SaveChanges();

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
                /* if (lstGrupo.Count > 0) 
                 {
                     grupo.IdGrupo = lstGrupo.Last().IdGrupo =
                lstGrupo.Last().IdGrupo + 1;
                 }
                 lstGrupo.Add(grupo);*/
                applicationDbContext.grupos.Add(grupo);
                applicationDbContext.SaveChanges ();

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
                return applicationDbContext.grupos.ToList();
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
                // int Indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == IdGrupo);
                //lstGrupo.RemoveAt(Indice);

                var item = applicationDbContext.grupos.SingleOrDefault(x => x.IdGrupo == IdGrupo);

                applicationDbContext.grupos.Remove(item);
                applicationDbContext.SaveChanges();

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
                // Grupo grupo = lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == IdGrupo);
                var grupo = applicationDbContext.grupos.SingleOrDefault(x => x.IdGrupo == IdGrupo);

                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

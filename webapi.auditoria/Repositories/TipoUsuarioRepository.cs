using webapi.auditoria.Contexts;
using webapi.auditoria.Domain;
using webapi.auditoria.Interfaces;

namespace webapi.auditoria.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly AuditoriaContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new AuditoriaContext();
        }

        //==================================================================

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================

        public void Deletar(Guid id)
        {
            TipoUsuario tipoUsuario = ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            ctx.TipoUsuario.Remove(tipoUsuario);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> tipoUsuarios = ctx.TipoUsuario.ToList();

            return tipoUsuarios;
        }
    }
}

using webapi.auditoria.Domain;

namespace webapi.auditoria.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);

        List<TipoUsuario> Listar();

        void Deletar(Guid id);

    }
}

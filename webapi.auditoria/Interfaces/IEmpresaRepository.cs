using webapi.auditoria.Domain;

namespace webapi.auditoria.Interfaces
{
    public interface IEmpresaRepository
    {
        void Cadastrar(Empresa empresa);

        List<Empresa> Listar();

        void Atualizar(Guid id, Empresa empresa);

        void Deletar(Guid id);
    }
}

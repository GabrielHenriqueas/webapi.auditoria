using webapi.auditoria.Contexts;
using webapi.auditoria.Domain;
using webapi.auditoria.Interfaces;

namespace webapi.auditoria.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AuditoriaContext ctx;

        public EmpresaRepository()
        {
            ctx = new AuditoriaContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Empresa empresa)
        {
            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(x => x.IdEmpresa == id)!;

            if (empresaBuscada != null)
            {
                empresaBuscada.NomeFantasia = empresa.NomeFantasia;
                empresaBuscada.CNPJ = empresa.CNPJ;
                empresaBuscada.RazaoSocial = empresa.RazaoSocial;
                empresaBuscada.Endereco = empresa.Endereco;
               
            }

            ctx.Empresa.Update(empresaBuscada!);

            ctx.SaveChanges();
        }

        //==================================================================

        public void Cadastrar(Empresa empresa)
        {
            try
            {
                ctx.Empresa.Add(empresa);

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
            Empresa empresa = ctx.Empresa.FirstOrDefault(x => x.IdEmpresa == id)!;

            ctx.Empresa.Remove(empresa);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Empresa> Listar()
        {
            List<Empresa> empresas = ctx.Empresa.ToList();

            return empresas;
        }
    }
}

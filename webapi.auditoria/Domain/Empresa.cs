using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.auditoria.Domain
{
    [Table(nameof(Empresa))]
    public class Empresa
    {
        [Key]
        public Guid IdEmpresa { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome Fantasia é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "CNPJ é obrigatório!")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Razão Social é obrigatório!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Endereço é obrigatório!")]
        public string? Endereco { get; set; }

    }
}

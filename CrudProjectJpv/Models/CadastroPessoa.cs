using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudProjectJpv.Models
{
    [Table("CadastroPessoa")]
    public class CadastroPessoa
    {
        [Column("id")]
        [Display(Name = "id")]
        public int id { get; set; }

        [Column("nomeCompleto")]
        [Display(Name = "nomeCompleto")]
        public string nomeCompleto { get; set; }

        [Column("dataNascimento")]
        [Display(Name = "dataNascimento")]
        public int dataNascimento { get; set; }

        [Column("valorRenda")]
        [Display(Name = "valorRenda")]
        public decimal valorRenda { get; set; }

        [Column("cpf")]
        [Display(Name = "cpf")]
        public int cpf { get; set; }
    }
}

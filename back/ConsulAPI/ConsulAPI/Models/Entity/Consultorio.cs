using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulAPI.Models
{
    [Table("consultorio", Schema = "base_corporativa")]
    public class Consultorio
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }
        public ICollection<MedicoConsultorio> MedicosConsultorios { get; set; }

    }
}

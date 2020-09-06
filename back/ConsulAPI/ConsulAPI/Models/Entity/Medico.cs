using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulAPI.Models
{
    [Table("medico", Schema = "base_corporativa")]
    public class Medico
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("crm")]
        public string Crm { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        public ICollection<MedicoConsultorio> MedicosConsultorios { get; set; }


    }
}

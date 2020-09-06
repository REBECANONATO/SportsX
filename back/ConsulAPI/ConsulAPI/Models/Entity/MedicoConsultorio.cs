using DocumentFormat.OpenXml.CustomXmlSchemaReferences;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulAPI.Models
{
    [Table("rel_medicos_consultorios", Schema = "base_corporativa")]
    public class MedicoConsultorio
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        public int MedicosId { get; set; }
        public int ConsultoriosId { get; set; }
        public Medico Medico { get; set; }
        public Consultorio Consultorio { get; set; }

    }
}

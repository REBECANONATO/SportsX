using ConsulAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsulAPI.Models
{
    [Table("cliente", Schema = "base_corporativa")]
    public class Cliente
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome_razao_social")]
        public string NomeRazaoSocial { get; set; }

        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("classificacao")]
        public int Classificacao { get; set; }

        public static implicit operator Cliente(ClienteDto v)
        {
            throw new NotImplementedException();
        }
    }
}

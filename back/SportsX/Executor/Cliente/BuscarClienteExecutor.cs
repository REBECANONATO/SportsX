using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Models.Model;
using ConsulAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class BuscarClienteExecutor : IBuscarClienteExecutor
    {
        private readonly IClienteRepositorio<Cliente> _repositorioGenerico;

        public BuscarClienteExecutor(IClienteRepositorio<Cliente> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task<IEnumerable<ClienteDto>> IBuscarClienteExecutor.Executor(int? id)
        {
            var resposta = new List<ClienteDto>();

            if (id != null)
            {
                var cliente = await _repositorioGenerico.SelecionarPorId((int)id);

                resposta.Add(new ClienteDto
                {
                    Id = cliente.Id,
                    NomeRazaoSocial = cliente.NomeRazaoSocial,
                    CpfCnpj = cliente.CpfCnpj,
                    Cep = cliente.Cep,
                    Email = cliente.Email,
                    Classificacao = cliente.Classificacao,
                    Telefone = cliente.Telefone
                });

            }
            else
            {
                var clientes = await _repositorioGenerico.SelecionarTodos();

                foreach (var cliente in clientes)
                {
                    resposta.Add(new ClienteDto
                    {
                        Id = cliente.Id,
                        NomeRazaoSocial = cliente.NomeRazaoSocial,
                        CpfCnpj = cliente.CpfCnpj,
                        Cep = cliente.Cep,
                        Email = cliente.Email,
                        Classificacao = cliente.Classificacao,
                        Telefone = cliente.Telefone
                    });
                }
            }

            return resposta;
        }
    }
}

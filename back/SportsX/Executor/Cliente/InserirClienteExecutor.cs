using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Repositorio;
using System;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class InserirClienteExecutor : IInserirClienteExecutor
    {
        private readonly IClienteRepositorio<Cliente> _repositorioGenerico;

        public InserirClienteExecutor(IClienteRepositorio<Cliente> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task<Cliente> IInserirClienteExecutor.Executor(ClienteCreateDto cliente)
        {
            try
            {
                Cliente clienteNew = await _repositorioGenerico.Inserir(new Cliente
                {
                    NomeRazaoSocial = cliente.NomeRazaoSocial,
                    CpfCnpj = cliente.CpfCnpj,
                    Cep = cliente.Cep,
                    Email = cliente.Email,
                    Classificacao = cliente.Classificacao,
                    Telefone = cliente.Telefone
                });
                return clienteNew;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}

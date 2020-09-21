using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Repositorio;
using System;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class AtualizarClienteExecutor : IAtualizarClienteExecutor
    {
        private readonly IClienteRepositorio<Cliente> _repositorioGenerico;

        public AtualizarClienteExecutor(IClienteRepositorio<Cliente> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task IAtualizarClienteExecutor.Executor(ClienteCreateDto cliente)
        {
            try
            {
                //var consultorios = await _repositorioGenerico.SelecionarPorId(consultorio.Id);

                //if ((consultorios != null))
                //{
                    await _repositorioGenerico.Atualizar(new Cliente
                    {
                        Id = cliente.Id,
                        NomeRazaoSocial = cliente.NomeRazaoSocial,
                        CpfCnpj = cliente.CpfCnpj,
                        Cep = cliente.Cep,
                        Email = cliente.Email,
                        Classificacao = cliente.Classificacao,
                        Telefone = cliente.Telefone
                    });
                //}
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}

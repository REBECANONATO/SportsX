using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Repositorio;
using System;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class InserirConsultorioExecutor : IInserirConsultorioExecutor
    {
        private readonly IConsultorioRepositorio<Consultorio> _repositorioGenerico;

        public InserirConsultorioExecutor(IConsultorioRepositorio<Consultorio> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task IInserirConsultorioExecutor.Executor(ConsultorioDto consultorio)
        {
            try
            {
                await _repositorioGenerico.Inserir(new Consultorio
                {
                    Nome = consultorio.Nome,
                    Endereco = consultorio.Endereco,
                    Telefone = consultorio.Telefone
                });

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}

using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Repositorio;
using System;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class AtualizaConsultorioExecutor : IAtualizaConsultorioExecutor
    {
        private readonly IConsultorioRepositorio<Consultorio> _repositorioGenerico;

        public AtualizaConsultorioExecutor(IConsultorioRepositorio<Consultorio> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task IAtualizaConsultorioExecutor.Executor(ConsultorioDto consultorio)
        {
            try
            {
                //var consultorios = await _repositorioGenerico.SelecionarPorId(consultorio.Id);

                //if ((consultorios != null))
                //{
                    await _repositorioGenerico.Atualizar(new Consultorio
                    {
                        Id = consultorio.Id,
                        Nome = consultorio.Nome,
                        Endereco = consultorio.Endereco,
                        Telefone = consultorio.Telefone,
                        MedicosConsultorios = null
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

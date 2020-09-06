using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Repositorio;
using System;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class DeletarConsultorioExecutor : IDeletarConsultorioExecutor
    {
        private readonly IConsultorioRepositorio<Consultorio> _repositorioGenerico;

        public DeletarConsultorioExecutor(IConsultorioRepositorio<Consultorio> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task IDeletarConsultorioExecutor.Executor(int id)
        {
            try
            {
                await _repositorioGenerico.Excluir(id);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}

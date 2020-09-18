using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Repositorio;
using System;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class DeletarClienteExecutor : IDeletarClienteExecutor
    {
        private readonly IClienteRepositorio<Cliente> _repositorioGenerico;

        public DeletarClienteExecutor(IClienteRepositorio<Cliente> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

        async Task IDeletarClienteExecutor.Executor(int id)
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

using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IInserirClienteExecutor
    {
        public Task<Cliente> Executor(ClienteCreateDto cliente);
    }
}

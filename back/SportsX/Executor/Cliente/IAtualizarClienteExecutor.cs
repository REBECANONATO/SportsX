using ConsulAPI.Models.DTO;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IAtualizarClienteExecutor
    {
        public Task Executor(ClienteDto cliente);
    }
}

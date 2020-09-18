using ConsulAPI.Models.DTO;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IDeletarClienteExecutor
    {
        public Task Executor(int id);
    }
}

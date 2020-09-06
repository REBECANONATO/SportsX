using ConsulAPI.Models.DTO;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IDeletarConsultorioExecutor
    {
        public Task Executor(int id);
    }
}

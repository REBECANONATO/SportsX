using ConsulAPI.Models.DTO;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IInserirConsultorioExecutor
    {
        public Task Executor(ConsultorioDto consultorio);
    }
}

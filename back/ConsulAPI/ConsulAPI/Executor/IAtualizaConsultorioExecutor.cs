using ConsulAPI.Models.DTO;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IAtualizaConsultorioExecutor
    {
        public Task Executor(ConsultorioDto consultorio);
    }
}

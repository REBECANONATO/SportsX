using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IBuscarConsultorioExecutor
    {
        public Task<IEnumerable<ConsultorioDto>> Executor(int? id);
    }
}

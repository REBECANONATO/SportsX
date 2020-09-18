using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public interface IBuscarClienteExecutor
    {
        public Task<IEnumerable<ClienteDto>> Executor(int? id);
    }
}

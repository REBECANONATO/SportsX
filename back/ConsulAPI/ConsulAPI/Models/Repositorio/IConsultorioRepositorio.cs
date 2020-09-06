using ConsulAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Repositorio
{
    public interface IConsultorioRepositorio<Consultorio>
    {
        public Task<List<Consultorio>> SelecionarTodos();
        public Task<Consultorio> SelecionarPorId(int id);
        public Task Inserir(Consultorio entidade);
        public Task Atualizar(Consultorio entidade);
        public Task Excluir(int id);
    }
}

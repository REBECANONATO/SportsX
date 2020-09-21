using ConsulAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Repositorio
{
    public interface IClienteRepositorio<Cliente>
    {
        public Task<List<Cliente>> SelecionarTodos();
        public Task<Cliente> SelecionarPorId(int id);
        public Task<Cliente> Inserir(Cliente entidade);
        public Task Atualizar(Cliente entidade);
        public Task Excluir(int id);
    }
}

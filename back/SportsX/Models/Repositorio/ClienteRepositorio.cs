using ConsulAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio<Cliente>
    {
        private readonly Context _context;

        public ClienteRepositorio(Context context)
        {
            _context = context;
        }

        public async Task Atualizar(Cliente entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var consultorio = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(consultorio);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Cliente entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> SelecionarPorId(int id)
        {
            return await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Cliente>> SelecionarTodos()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
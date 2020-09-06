using ConsulAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Repositorio
{
    public class ConsultorioRepositorio : IConsultorioRepositorio<Consultorio>
    {
        private readonly Context _context;

        public ConsultorioRepositorio(Context context)
        {
            _context = context;
        }

        public async Task Atualizar(Consultorio entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var consultorio = await _context.Consultorio.FindAsync(id);
            _context.Consultorio.Remove(consultorio);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Consultorio entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<Consultorio> SelecionarPorId(int id)
        {
            return await _context.Consultorio
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Consultorio>> SelecionarTodos()
        {
            return await _context.Consultorio.ToListAsync();
        }
    }
}
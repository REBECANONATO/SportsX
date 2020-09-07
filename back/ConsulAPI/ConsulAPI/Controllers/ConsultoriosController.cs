using ConsulAPI.Executor;
using ConsulAPI.Models.DTO;
using ConsulAPI.Models.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Consultorios")]
    public class ConsultoriosController : Controller
    {
        private readonly IAtualizaConsultorioExecutor _atualizaConsultorioExecutor;
        private readonly IBuscarConsultorioExecutor _buscarConsultorioExecutor;
        private readonly IInserirConsultorioExecutor _inserirConsultorioExecutor;
        private readonly IDeletarConsultorioExecutor _deletarConsultorioExecutor;

        public ConsultoriosController(IAtualizaConsultorioExecutor atualizaConsultorioExecutor,
            IBuscarConsultorioExecutor buscarConsultorioExecutor, IInserirConsultorioExecutor inserirConsultorioExecutor, IDeletarConsultorioExecutor deletarConsultorioExecutor)
        {
            _atualizaConsultorioExecutor = atualizaConsultorioExecutor;
            _buscarConsultorioExecutor = buscarConsultorioExecutor;
            _inserirConsultorioExecutor = inserirConsultorioExecutor;
            _deletarConsultorioExecutor = deletarConsultorioExecutor;
        }

        // GET: Consultorios
        [EnableCors("PolicyNames.AllowOrigins")]
        public async Task<List<ConsultorioDto>> Index()
        {
            return (await _buscarConsultorioExecutor.Executor(null)).ToList();
        }

        // GET: Consultorios/Details/5
        [EnableCors("PolicyNames.AllowOrigins")]
        public async Task<List<ConsultorioDto>> Details(int? id)
        {

            return (await _buscarConsultorioExecutor.Executor(id)).ToList();
        }

        // POST: Consultorios/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ConsultorioModel consultorio)
        {
            if (ModelState.IsValid)
            {
                await _inserirConsultorioExecutor.Executor(new ConsultorioDto
                {
                    Endereco = consultorio.Endereco,
                    Nome = consultorio.Nome,
                    Telefone = consultorio.Telefone
                });

                return Ok();
            }
            return NotFound();
        }

        // POST: Consultorios/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] ConsultorioModel consultorio)
        {
            try
            {
                if (id != 0)
                {
                    await _atualizaConsultorioExecutor.Executor(new ConsultorioDto
                    {
                        Id = id,
                        Endereco = consultorio.Endereco,
                        Nome = consultorio.Nome,
                        Telefone = consultorio.Telefone
                    });

                    return Ok();
                }
                return NotFound(consultorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: Consultorios/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _deletarConsultorioExecutor.Executor(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

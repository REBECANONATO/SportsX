using ConsulAPI.Executor;
using ConsulAPI.Models;
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
    [System.Web.Http.RoutePrefix("api/Clientes")]
    public class ClientesController : Controller
    {
        private readonly IAtualizarClienteExecutor _atualizaClienteExecutor;
        private readonly IBuscarClienteExecutor _buscarClienteExecutor;
        private readonly IInserirClienteExecutor _inserirClienteExecutor;
        private readonly IDeletarClienteExecutor _deletarClienteExecutor;

        public ClientesController(IAtualizarClienteExecutor atualizaClienteExecutor,
            IBuscarClienteExecutor buscarClienteExecutor, IInserirClienteExecutor inserirClienteExecutor, IDeletarClienteExecutor deletarClienteExecutor)
        {
            _atualizaClienteExecutor = atualizaClienteExecutor;
            _buscarClienteExecutor = buscarClienteExecutor;
            _inserirClienteExecutor = inserirClienteExecutor;
            _deletarClienteExecutor = deletarClienteExecutor;
        }

        // GET: Clientes
        [EnableCors("PolicyNames.AllowOrigins")]
        public async Task<List<ClienteDto>> Index()
        {
            return (await _buscarClienteExecutor.Executor(null)).ToList();
        }

        // GET: Clientes/Details/5
        [EnableCors("PolicyNames.AllowOrigins")]
        public async Task<List<ClienteDto>> Details(int? id)
        {

            return (await _buscarClienteExecutor.Executor(id)).ToList();
        }

        // POST: Clientes/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente clienteNew = await _inserirClienteExecutor.Executor(new ClienteCreateDto
                {
                    NomeRazaoSocial = cliente.NomeRazaoSocial,
                    CpfCnpj = cliente.CpfCnpj,
                    Cep = cliente.Cep,
                    Email = cliente.Email,
                    Classificacao = cliente.Classificacao,
                    Telefone = cliente.Telefone
                });

                return Ok(clienteNew);
            }
            return NotFound();
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] ClienteModel cliente)
        {
            try
            {
                if (id != 0)
                {
                    await _atualizaClienteExecutor.Executor(new ClienteCreateDto
                    {
                        Id = id,
                        NomeRazaoSocial = cliente.NomeRazaoSocial,
                        CpfCnpj = cliente.CpfCnpj,
                        Cep = cliente.Cep,
                        Email = cliente.Email,
                        Classificacao = cliente.Classificacao,
                        Telefone = cliente.Telefone
                    });

                    return Ok();
                }
                return NotFound(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _deletarClienteExecutor.Executor(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

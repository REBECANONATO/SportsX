using ConsulAPI.Models;
using ConsulAPI.Models.DTO;
using ConsulAPI.Models.Model;
using ConsulAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsulAPI.Executor
{
    public class BuscarConsultorioExecutor : IBuscarConsultorioExecutor
    {
        private readonly IConsultorioRepositorio<Consultorio> _repositorioGenerico;

        public BuscarConsultorioExecutor(IConsultorioRepositorio<Consultorio> repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }

       async Task<IEnumerable<ConsultorioDto>> IBuscarConsultorioExecutor.Executor(int? id)
        {
            var resposta = new List<ConsultorioDto>();

            if (id != null)
            {
               var consultorio = await _repositorioGenerico.SelecionarPorId((int)id);

                resposta.Add(new ConsultorioDto
                {
                    Id = consultorio.Id,
                    Nome = consultorio.Nome,
                    Endereco = consultorio.Endereco,
                    Telefone = consultorio.Telefone
                });

            }
            else
            {
                var consultorios = await _repositorioGenerico.SelecionarTodos();

                foreach (var consultorio in consultorios)
                {
                    resposta.Add(new ConsultorioDto
                    {
                        Id = consultorio.Id,
                        Nome = consultorio.Nome,
                        Endereco = consultorio.Endereco,
                        Telefone = consultorio.Telefone
                    });
                }
            }

            return resposta;
        }
    }
}

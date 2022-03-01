using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Aplicacao;
using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestrantesController : ControllerBase
    {
        private readonly IPalestranteService _service;

        public PalestrantesController(IPalestranteService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var entidades = await _service.GetAllPalestrantesAsync(true);
                return entidades == null ? NotFound("Nenhum registro encontrado.") : Ok(entidades);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado. Erro: {ex.Message}");
            }
        }

        [HttpGet("/nome/{texto}")]
        public async Task<IActionResult> Get(string texto)
        {
            try
            {
                var entidades = await _service.GetAllPalestrantesByNomeAsync(texto, true);
                return entidades == null ? NotFound("Nenhum registro encontrado.") : Ok(entidades);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entidade = await _service.GetPalestranteByIdAsync(id, true);
                return entidade == null ? NotFound("Nenhum registro encontrado.") : Ok(entidade);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
            try
            {
                var entidade = await _service.AddPalestrantes(model);
                return entidade == null ? BadRequest("Não foi possivel realizar a operação.") : Ok(entidade);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Palestrante model)
        {
            try
            {
                var entidade = await _service.UpdatePalestrantes(id, model);
                return entidade == null ? BadRequest("Não foi possivel realizar a operação.") : Ok(entidade);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _service.RemovePalestrantes(id) ?
                    Ok("Registro removido com sucesso.") :
                    BadRequest("Não foi possivel realizar a operação.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado. Erro: {ex.Message}");
            }
        }
    }
}

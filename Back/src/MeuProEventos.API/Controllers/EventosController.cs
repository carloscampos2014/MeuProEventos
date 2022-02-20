using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProEventos.API.Data;
using MeuProEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeuProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventosController : ControllerBase
  {
    private readonly DataContext _context;

    public EventosController(DataContext context) => _context = context;

    [HttpGet]
    public IEnumerable<Evento> Get() => _context.Eventos;

    [HttpGet("{id}")]
    public Evento Get(int id) => _context.Eventos.FirstOrDefault(f => f.EventoId == id);

    [HttpPost]
    public string Post() => "Exemplo de Evento POST";

    [HttpPut("{id}")]
    public string Put(int id) => $"Exemplo de Evento PUT -> {id}";

    [HttpDelete("{id}")]
    public string Delete(int id) => $"Exemplo de Evento DELETE -> {id}";
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeuProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new Evento[]{};

        public EventoController()
        {
            _eventos.Append(new Evento(){
            EventoId = 1,
            Tema = "Teste de Evento",
            Local = "Guarulhos/SP",
            Lote = "1",
            QtdPessoas = 500,
            DataEvento = DateTime.Now.AddDays(5).ToLongDateString(),
            ImagemURL = "foto.jpg"
            });

            _eventos.Append(new Evento(){
            EventoId = 2,
            Tema = "Teste de Evento",
            Local = "Guarulhos/SP",
            Lote = "1",
            QtdPessoas = 500,
            DataEvento = DateTime.Now.AddDays(5).ToLongDateString(),
            ImagemURL = "foto.jpg"
            });
        }

        [HttpGet]
        public IEnumerable<Evento> Get() => _eventos;

        [HttpGet("{id}")]
        public Evento Get(int id) => _eventos.FirstOrDefault(f=> f.EventoId == id);

        [HttpPost]
        public string Post() => "Exemplo de Evento POST";

        [HttpPut("{id}")]
        public string Put(int id) => $"Exemplo de Evento PUT -> {id}";

        [HttpDelete("{id}")]
        public string Delete(int id) => $"Exemplo de Evento DELETE -> {id}";
    }
}

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProEventos.API.Controllers
{
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;
    using ProEventos.Domain.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IList<EventosVO> _events;
        private readonly ILogger<EventosController> _logger;

        public EventosController(ILogger<EventosController> logger)
        {
            _logger = logger;
            _events = new List<EventosVO>()
                {
                new EventosVO()
                {
                    EventoId = 1,
                    Tema = "Curso de Angular + .Net 5 + SqLite",
                    Local = "Guarulhos/SP",
                    Data = DateTime.Now,
                    QtdPessoas = 50,
                    Lote = "1",
                    ImageUrl = "curso_Angular_Net5_SqLite.png"
                },
                new EventosVO()
                {
                    EventoId = 2,
                    Tema = "Curso de Angular + .Net 6 + SqLite",
                    Local = "Guarulhos/SP",
                    Data = DateTime.Now.AddMonths(1),
                    QtdPessoas = 50,
                    Lote = "1",
                    ImageUrl = "curso_Angular_Net6_SqLite.png"
                },
            };
        }

        // GET: api/<EventosController>
        [HttpGet]
        public IEnumerable<EventosVO> Get()
        {
            return _events;
        }

        // GET api/<EventosController>/5
        [HttpGet("{id}")]
        public EventosVO Get(int id)
        {
            return _events.FirstOrDefault(f => f.EventoId == id) ?? new EventosVO();
        }

        // POST api/<EventosController>
        [HttpPost]
        public void Post([FromBody] EventosVO model)
        {
            _events.Add(model);
        }

        // PUT api/<EventosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EventosVO model)
        {
            var evento = _events.FirstOrDefault(f => f.EventoId == id);
            if (evento != null)
            {
                evento = model;
            }
            else
            {
                _logger.Log(LogLevel.Debug, $"Evento {id} não encontrado");
            }
        }

        // DELETE api/<EventosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var evento = _events.FirstOrDefault(f => f.EventoId == id);
            if (evento != null)
            {
                _events.Remove(evento);
            }
            else
            {
                _logger.Log(LogLevel.Debug, $"Evento {id} não encontrado");
            }
        }
    }
}

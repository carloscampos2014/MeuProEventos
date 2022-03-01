using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplicacao
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);

        Task<Evento> UpdateEventos(int id, Evento model);

        Task<bool> RemoveEventos(int id);

        Task<List<Evento>> GetAllEventosAsync(bool incluirPalestrantes = false);

        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false);

        Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrantes = false);
    }
}

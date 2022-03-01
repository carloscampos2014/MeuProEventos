using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistencia
{
    public interface IEventoPersistencia
    {
        Task<List<Evento>> GetAllEventosAsync(bool incluirPalestrantes = false);

        Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false);

        Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrantes = false);
    }
}

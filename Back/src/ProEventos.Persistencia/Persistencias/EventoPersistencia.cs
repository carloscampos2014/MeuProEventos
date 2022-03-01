using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistencia
{
    public class EventoPersistencia : IEventoPersistencia
    {
        private readonly ProEventosContext _contexto;

        public EventoPersistencia(ProEventosContext contexto) 
        {
            _contexto = contexto;
        }

        public async Task<List<Evento>> GetAllEventosAsync(bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _contexto.Eventos.AsNoTracking()
                .Include(i => i.Lote)
                .Include(i => i.RedesSociais);

            if (incluirPalestrantes)
                query = query.Include(i => i.PalestrantesEventos)
                    .ThenInclude(ti => ti.Palestrante);

            query = query.OrderBy(o => o.Id);

            return await query.ToListAsync();

        }

        public async Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _contexto.Eventos.AsNoTracking()
                .Include(i => i.Lote)
                .Include(i => i.RedesSociais)
                .Where(w => w.Tema.ToLower().Contains(tema.ToLower()));

            if (incluirPalestrantes)
                query = query.Include(i => i.PalestrantesEventos)
                    .ThenInclude(ti => ti.Palestrante);

            query = query.OrderBy(o => o.Id);

            return await query.ToListAsync();

        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _contexto.Eventos.AsNoTracking()
                .Include(i => i.Lote)
                .Include(i => i.RedesSociais);

            if (incluirPalestrantes)
                query = query.Include(i => i.PalestrantesEventos)
                    .ThenInclude(ti => ti.Palestrante);

            return await query.FirstOrDefaultAsync(f=> f.Id == id);
        }
    }
}

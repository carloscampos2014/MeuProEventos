using Microsoft.EntityFrameworkCore;
using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistencia
{
    public class PalestrantePersistencia : IPalestrantePersistencia
    {
        private readonly ProEventosContext _contexto;

        public PalestrantePersistencia(ProEventosContext contexto) => _contexto = contexto;

        public async Task<List<Palestrante>> GetAllPalestrantesAsync(bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _contexto.Palestrantes.AsNoTracking()
                .Include(i => i.RedesSociais);

            if (incluirEventos)
                query = query.Include(i => i.PalestrantesEventos)
                    .ThenInclude(ti => ti.Evento);

            query = query.OrderBy(o => o.Id);

            return await query.ToListAsync();

        }

        public async Task<List<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _contexto.Palestrantes.AsNoTracking()
                .Include(i => i.RedesSociais)
                .Where(w => w.Nome.ToLower().Contains(nome.ToLower()));

            if (incluirEventos)
                query = query.Include(i => i.PalestrantesEventos)
                    .ThenInclude(ti => ti.Evento);

            query = query.OrderBy(o => o.Id);

            return await query.ToListAsync();

        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool incluirEventos = false)
        {
            IQueryable<Palestrante> query = _contexto.Palestrantes.AsNoTracking()
                .Include(i => i.RedesSociais);

            if (incluirEventos)
                query = query.Include(i => i.PalestrantesEventos)
                    .ThenInclude(ti => ti.Evento);

            return await query.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}

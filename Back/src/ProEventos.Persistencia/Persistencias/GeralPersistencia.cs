using Microsoft.EntityFrameworkCore;
using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistencia
{
    public class GeralPersistencia : IGeralPersistencia
    {
        private readonly ProEventosContext _contexto;

        public GeralPersistencia(ProEventosContext contexto) => _contexto = contexto;

        public void Add<T>(T entidade) where T: class => _contexto.Add(entidade);

        public void Update<T>(T entidade) where T : class => _contexto.Update(entidade);

        public void Remove<T>(T entidade) where T : class => _contexto.Remove(entidade);

        public void RemoveRange<T>(List<T> entidades) where T : class => _contexto.RemoveRange(entidades);

        public async Task<bool> SaveChangesAsync() => await _contexto.SaveChangesAsync() > 0;
    }
}

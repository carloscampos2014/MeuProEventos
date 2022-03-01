using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistencia
{
    public interface IGeralPersistencia
    {
        void Add<T>(T entidade) where T : class;

        void Update<T>(T entidade) where T : class;

        void Remove<T>(T entidade) where T : class;

        void RemoveRange<T>(List<T> entidades) where T : class;

        Task<bool> SaveChangesAsync();
    }
}

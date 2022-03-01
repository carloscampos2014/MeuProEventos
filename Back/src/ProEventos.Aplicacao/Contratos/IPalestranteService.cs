using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplicacao
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrantes(Palestrante model);

        Task<Palestrante> UpdatePalestrantes(int id, Palestrante model);

        Task<bool> RemovePalestrantes(int id);

        Task<List<Palestrante>> GetAllPalestrantesAsync(bool incluirEventos = false);

        Task<List<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos = false);

        Task<Palestrante> GetPalestranteByIdAsync(int id, bool incluirEventos = false);
    }
}

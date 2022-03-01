using ProEventos.Dominio;
using ProEventos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplicacao
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IPalestrantePersistencia _persistencia;

        public PalestranteService(IGeralPersistencia geralPersistencia, IPalestrantePersistencia persistencia)
        {
            _geralPersistencia = geralPersistencia;
            _persistencia = persistencia;
        }

        public async Task<Palestrante> AddPalestrantes(Palestrante model)
        {
            try
            {
                _geralPersistencia.Add<Palestrante>(model);
                if (await _geralPersistencia.SaveChangesAsync())
                {
                    return await GetPalestranteByIdAsync(model.Id);
                }
                throw new Exception("Ocorreu Algum Erro Inesperado!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> UpdatePalestrantes(int id, Palestrante model)
        {
            try
            {
                var palestrante = await GetPalestranteByIdAsync(id);
                if (palestrante == null) throw new Exception("Registro não Encontrado!");

                model.Id = palestrante.Id;

                _geralPersistencia.Update<Palestrante>(model);
                if (await _geralPersistencia.SaveChangesAsync())
                {
                    return await GetPalestranteByIdAsync(model.Id);
                }
                throw new Exception("Ocorreu Algum Erro Inesperado!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemovePalestrantes(int id)
        {
            try
            {
                var palestrante = await GetPalestranteByIdAsync(id);
                if (palestrante == null) throw new Exception("Registro não Encontrado!");

                _geralPersistencia.Remove<Palestrante>(palestrante);

                return await _geralPersistencia.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Palestrante>> GetAllPalestrantesAsync(bool incluirEventos = false)
        {
            try
            {
                return await _persistencia.GetAllPalestrantesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Palestrante>> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos = false)
        {
            try
            {
                return await _persistencia.GetAllPalestrantesByNomeAsync(nome, incluirEventos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int id, bool incluirEventos = false)
        {
            try
            {
                return await _persistencia.GetPalestranteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

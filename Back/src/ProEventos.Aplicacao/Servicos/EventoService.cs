using ProEventos.Dominio;
using ProEventos.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplicacao
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IEventoPersistencia _persistencia;

        public EventoService(IGeralPersistencia geralPersistencia, IEventoPersistencia persistencia)
        {
            _geralPersistencia = geralPersistencia;
            _persistencia = persistencia;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistencia.Add<Evento>(model);
                if (await _geralPersistencia.SaveChangesAsync())
                {
                    return await GetEventoByIdAsync(model.Id);
                }
                throw new Exception("Ocorreu Algum Erro Inesperado!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEventos(int id, Evento model)
        {
            try
            {
                var evento = await GetEventoByIdAsync(id);
                if (evento == null) throw new Exception("Registro não Encontrado!");

                model.Id = evento.Id;

                _geralPersistencia.Update<Evento>(model);
                if (await _geralPersistencia.SaveChangesAsync())
                {
                    return await GetEventoByIdAsync(model.Id);
                }
                throw new Exception("Ocorreu Algum Erro Inesperado!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveEventos(int id)
        {
            try
            {
                var evento = await GetEventoByIdAsync(id);
                if (evento == null) throw new Exception("Registro não Encontrado!");

                _geralPersistencia.Remove<Evento>(evento);

                return await _geralPersistencia.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Evento>> GetAllEventosAsync(bool incluirPalestrantes = false)
        {
            try
            {
                return await _persistencia.GetAllEventosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Evento>> GetAllEventosByTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            try
            {
                return await _persistencia.GetAllEventosByTemaAsync(tema, incluirPalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int id, bool incluirPalestrantes = false)
        {
            try
            {
                return await _persistencia.GetEventoByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProEventos.Dominio
{
    public class Evento
    {
        public int Id { get; set; }

        public string Tema { get; set; }
        
        public string Local { get; set; }

        public DateTime? Data { get; set; }

        public int LimiteParticipantes { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string ImagemURL { get; set; }

        public List<Lote> Lote { get; set; }

        public List<RedeSocial> RedesSociais { get; set; }

        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}

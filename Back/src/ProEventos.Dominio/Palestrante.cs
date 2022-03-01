using System.Collections.Generic;

namespace ProEventos.Dominio
{
    public class Palestrante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobre { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string ImagemURL { get; set; }

        public List<RedeSocial> RedesSociais { get; set; }

        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}

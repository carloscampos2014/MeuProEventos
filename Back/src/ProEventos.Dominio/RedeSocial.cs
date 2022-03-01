namespace ProEventos.Dominio
{
    public class RedeSocial
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string URL { get; set; }

        public int? EventoId { get; set; }

        public Evento Evento { get; set; }

        public int? PalestranteId { get; set; }

        public Palestrante Palestrante { get; set; }
    }
}
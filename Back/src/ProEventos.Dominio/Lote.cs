using System;

namespace ProEventos.Dominio
{
    public class Lote
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int Quantidade { get; set; }

        public int? EventoId { get; set; }

        public Evento Evento { get; set; }
    }
}
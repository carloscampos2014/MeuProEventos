// Ignore Spelling: Qtd

namespace ProEventos.Domain.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EventosVO
    {
        public int EventoId { get; set; }

        public string Local { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public string Tema { get; set; } = string.Empty;

        public int QtdPessoas { get; set; }

        public string Lote { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}

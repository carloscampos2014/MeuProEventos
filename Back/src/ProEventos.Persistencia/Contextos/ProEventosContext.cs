using Microsoft.EntityFrameworkCore;
using ProEventos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistencia
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {
        }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<RedeSocial> RedesSociais { get; set; }

        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(k => new { k.EventoId, k.PalestranteId });

            modelBuilder.Entity<Evento>()
                .HasMany(m => m.RedesSociais)
                .WithOne(o => o.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(m => m.RedesSociais)
                .WithOne(o => o.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

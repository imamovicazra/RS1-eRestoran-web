using eRestoran.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eRestoran.Database
{
    public partial class eRestoranContext : 
        IdentityDbContext<Korisnik, Uloga, int, KorisnikClaim, KorisnikUloga, KorisnikLogin, UlogaClaim, KorisnikToken>
    {
        public eRestoranContext(DbContextOptions<eRestoranContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Jelo> Jela { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<StatusDostave> StatusiDostave { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Namirnica> Namirnice { get; set; }
        public DbSet<KorisnikNamirnica> KorisnikNamirnice { get; set; }
        public DbSet<Like> Likes { get; set; }
       
        public DbSet<KorpaStavka> KorpaStavke { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<NarudzbaDetalji> NarudzbaDetalji { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<NacinPlacanja> NaciniPlacanja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KorisnikNamirnica>(entity =>
            {
                entity.HasKey(k => new { k.KorisnikID, k.NamirnicaID });
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(k => new { k.KorisnikID, k.JeloID });
            });


            modelBuilder.Entity<KorisnikUloga>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Uloga)
                    .WithMany(r => r.KorisnikUloge)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.Korisnik)
                    .WithMany(r => r.KorisnikUloge)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

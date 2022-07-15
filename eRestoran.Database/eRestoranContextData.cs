using eRestoran.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace eRestoran.Database
{
    public partial class eRestoranContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uloga>()
                .HasData
                (
                    new Uloga { Id = 1, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                    new Uloga { Id = 2, Name = "Uposlenik", NormalizedName = "UPOSLENIK" },
                    new Uloga { Id = 3, Name = "Korisnik", NormalizedName = "KORISNIK" }
                );

            PasswordHasher<Korisnik> ph = new PasswordHasher<Korisnik>();

            var admin = new Korisnik()
            {
                Id = 1,
                Ime = "Admin",
                Prezime = "Admin",
                Email = "admin@restoran.com",
                NormalizedEmail = "admin@restoran.com".ToUpper(),
                UserName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = ph.HashPassword(admin, "Abc123!");

            var uposlenik = new Korisnik()
            {
                Id = 2,
                Ime = "Uposlenik",
                Prezime = "Uposlenik",
                Email = "uposlenik@restoran.com",
                NormalizedEmail = "uposlenik@restoran.com".ToUpper(),
                UserName = "Uposlenik",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            uposlenik.PasswordHash = ph.HashPassword(uposlenik, "Abc123!");

            var korisnik = new Korisnik()
            {
                Id = 3,
                Ime = "Korisnik",
                Prezime = "Korisnik",
                Email = "korisnik@restoran.com",
                NormalizedEmail = "korisnik@restoran.com".ToUpper(),
                UserName = "Korisnik",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            korisnik.PasswordHash = ph.HashPassword(korisnik, "Abc123!");

            modelBuilder.Entity<Korisnik>()
                .HasData(admin, uposlenik, korisnik);

            modelBuilder.Entity<KorisnikUloga>()
                .HasData
                (
                    new KorisnikUloga { UserId = 1, RoleId = 1},
                    new KorisnikUloga { UserId = 2, RoleId = 2},
                    new KorisnikUloga { UserId = 3, RoleId = 3}
                );

            modelBuilder.Entity<Namirnica>()
                .HasData
                (
                    new Namirnica { ID = 1, Naziv = "Ulje", Kolicina = 20, CijenaPoKomadu = 0.90, JedinicaMjere = "kilogram" },
                    new Namirnica { ID = 2, Naziv = "Brašno", Kolicina = 100, CijenaPoKomadu = 1.00, JedinicaMjere = "kilogram" },
                    new Namirnica { ID = 3, Naziv = "So", Kolicina = 20, CijenaPoKomadu = 0.90, JedinicaMjere = "kilogram" }
                );


            modelBuilder.Entity<Kategorija>()
                .HasData
                (
                    new Kategorija { ID = 1, Naziv = "Pizza", Opis = "Različite vrste pizza spremljene sa pažljivo odabranim i kvalitetnim namirnicama, pečene na tradicionalan način" },
                    new Kategorija { ID = 2, Naziv = "Supe", Opis = "Supe od svježeg povrća, idealne su kao predjelo"},
                    new Kategorija { ID = 3, Naziv = "Ribe", Opis = "Bogat izvor vitamina, minerala, bjelančevina, kao i omega 3 masnih kiselina"},
                    new Kategorija { ID = 4, Naziv = "Salate", Opis = "Napravljene od svježih sastojaka, super zdrave i idealan obrok za svaki dio dana"},
                    new Kategorija { ID = 5, Naziv = "Pića", Opis = "Razne vrste gaziranih i negaziranih pića, kao i toplih napitaka"}
                );

            modelBuilder.Entity<StatusDostave>()
                .HasData
                (
                    new StatusDostave { ID = 1, Status = "Narudžba prihvaćena"},
                    new StatusDostave { ID = 2, Status = "Narudžba odbijena"},
                    new StatusDostave { ID = 3, Status = "Narudžba u obradi"}
                );

            modelBuilder.Entity<Jelo>()
                .HasData
                (
                    new Jelo 
                    { 
                        ID = 1, 
                        Naziv = "Pizza Margherita", 
                        Cijena = 6.00, 
                        Opis = "Paradajz sos, origano i sir",
                        KategorijaID = 1,
                        Slika = "Images\\jela\\margherita.jpg",
                        Favorit=true
                    },
                    new Jelo
                    {
                        ID = 2,
                        Naziv = "Pizza Funghi",
                        Cijena = 7.00,
                        Opis = "Paradajz sos, origano, sir i gljive",
                        KategorijaID = 1,
                        Slika = "Images\\jela\\funghi.jpg",
                        Favorit=false
                    },
                    new Jelo
                    {
                        ID = 3,
                        Naziv = "Pizza Vegeteriana",
                        Cijena = 8.00,
                        Opis = "Paradajz sos, svježi paradajz, paprika, origano, sir, tikvice, gljive",
                        KategorijaID = 1,
                        Slika = "images\\jela\\vegeteriana.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 4,
                        Naziv = "Krem supa od paradajza",
                        Cijena = 4.00,
                        Opis = "Svježe pripremana krem supa od paradajza sa mozzarelom i rižom",
                        KategorijaID = 2,
                        Slika = "images\\jela\\supa_paradajz.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 5,
                        Naziv = "Krem supa od tikve",
                        Cijena = 5.00,
                        Opis = "Svježe pripremana krem supa od tikve",
                        KategorijaID = 2,
                        Slika = "images\\jela\\supa_tikva.jpg",
                        Favorit = true
                    },
                    new Jelo
                    {
                        ID = 6,
                        Naziv = "Losos verdura sa žara",
                        Cijena = 25.00,
                        Opis = "File lososa, tikvice, krompir, paprika, patlidžan, maslinovo ulje",
                        KategorijaID = 3,
                        Slika = "images\\jela\\losos_zar.jpg",
                        Favorit = true
                    },
                    new Jelo
                    {
                        ID = 7,
                        Naziv = "Losos sa žara sa špinatom",
                        Cijena = 25.00,
                        Opis = "File lososa, tikvice, krompir, špinat, paprika, patlidžan",
                        KategorijaID = 3,
                        Slika = "images\\jela\\losos_zar_spinat.jpg"
                    },
                    new Jelo
                    {
                        ID = 8,
                        Naziv = "Pileća salata",
                        Cijena = 8.00,
                        Opis = "Pileći file, paradajz, rotkvica, rukola, zelena salata, krastavac, pecivo",
                        KategorijaID = 4,
                        Slika = "images\\jela\\pileća_salata.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 9,
                        Naziv = "Tuna salata",
                        Cijena = 8.00,
                        Opis = "Komadići tune, paradajz, rotkvica, rukola, zelena salata, krastavac, maslinovo ulje, aceto balsamico, pecivo",
                        KategorijaID = 4,
                        Slika = "images\\jela\\tuna_salata.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 13,
                        Naziv = "Mozzarella salata",
                        Cijena = 8.00,
                        Opis = "Mozzarela, paradajz, rotkvica, rukola, zelena salata, masline, aceto balsamico, pecivo. ",
                        KategorijaID = 4,
                        Slika = "images\\jela\\mozzarella_salata.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 14,
                        Naziv = "Pizza Tonno",
                        Cijena = 8.00,
                        Opis = "Paradajz sos, origano, sir, luk, tunjevina, crne masline. ",
                        KategorijaID = 1,
                        Slika = "images\\jela\\tonno.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 10,
                        Naziv = "Macchiato",
                        Cijena = 2.50,
                        Opis = "Kombinacija toplog mlijeka, pjene od mlijeka i espresso kafe",
                        KategorijaID = 5,
                        Slika = "images\\jela\\macchiato.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 11,
                        Naziv = "Coca Cola",
                        Cijena = 3.00,
                        Opis = "Classic ili Zero, opcionalno poslužena sa ledom i limunom",
                        KategorijaID = 5,
                        Slika = "images\\jela\\coca_cola.jpg",
                        Favorit = false
                    },
                    new Jelo
                    {
                        ID = 12,
                        Naziv = "Prirodni sokovi",
                        Cijena = 3.00,
                        Opis = "Prirodno cijeđeni sokovi sa okusima naranče, jagode, višnje, jabuke, breskve, ananasa...",
                        KategorijaID = 5,
                        Slika = "images\\jela\\prirodni_sokovi.jpg",
                        Favorit = false
                     }
                );

            modelBuilder.Entity<Narudzba>()
                .HasData
                (
                    new Narudzba
                    {
                        ID = 1,
                        Adresa = "Adresa 1",
                        KorisnikID = 3,
                        UposlenikID = 2,
                        Telefon = "0601111111",
                        DatumNarudzbe = DateTime.Now,
                        StatusDostaveID = 1
                    },
                    new Narudzba
                    {
                        ID = 2,
                        Adresa = "Adresa 2",
                        KorisnikID = 3,
                        UposlenikID = 2,
                        Telefon = "0602222222",
                        DatumNarudzbe = DateTime.Now,
                        StatusDostaveID = 2
                    },
                    new Narudzba
                    {
                        ID = 3,
                        Adresa = "Adresa 3",
                        KorisnikID = 3,
                        UposlenikID = 2,
                        Telefon = "0603333333",
                        DatumNarudzbe = DateTime.Now,
                        StatusDostaveID = 3
                    }
                );

        }
    }
}

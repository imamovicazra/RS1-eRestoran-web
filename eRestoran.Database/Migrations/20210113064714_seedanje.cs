using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eRestoran.Database.Migrations
{
    public partial class seedanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NaciniPlacanja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojKartice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaciniPlacanja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Namirnice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    CijenaPoKomadu = table.Column<double>(type: "float", nullable: false),
                    JedinicaMjere = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namirnice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusiDostave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusiDostave", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlogaId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaID = table.Column<int>(type: "int", nullable: false),
                    Favorit = table.Column<bool>(type: "bit", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jela_Kategorije_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorije",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikNamirnice",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    NamirnicaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikNamirnice", x => new { x.KorisnikID, x.NamirnicaID });
                    table.ForeignKey(
                        name: "FK_KorisnikNamirnice_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikNamirnice_Namirnice_NamirnicaID",
                        column: x => x.NamirnicaID,
                        principalTable: "Namirnice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    UposlenikID = table.Column<int>(type: "int", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    StatusDostaveID = table.Column<int>(type: "int", nullable: false),
                    NacinPlacanjaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Narudzbe_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzbe_AspNetUsers_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbe_NaciniPlacanja_NacinPlacanjaID",
                        column: x => x.NacinPlacanjaID,
                        principalTable: "NaciniPlacanja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzbe_StatusiDostave_StatusDostaveID",
                        column: x => x.StatusDostaveID,
                        principalTable: "StatusiDostave",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Invalidated = table.Column<bool>(type: "bit", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumVrijemeEvidencije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVrijemeRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UposlenikID = table.Column<int>(type: "int", nullable: true),
                    BrojMjesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervacije_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_AspNetUsers_UposlenikID",
                        column: x => x.UposlenikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorpaStavke",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JeloID = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    KorpaID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorpaStavke", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KorpaStavke_Jela_JeloID",
                        column: x => x.JeloID,
                        principalTable: "Jela",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    JeloID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.KorisnikID, x.JeloID });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Jela_JeloID",
                        column: x => x.JeloID,
                        principalTable: "Jela",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaDetalji",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaID = table.Column<int>(type: "int", nullable: false),
                    JeloID = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaDetalji", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NarudzbaDetalji_Jela_JeloID",
                        column: x => x.JeloID,
                        principalTable: "Jela",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaDetalji_Narudzbe_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzbe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 3, "6bd97c65-2284-4855-8a33-747e7a86c03e", "Korisnik", "KORISNIK" },
                    { 1, "ccd5cddc-0a4a-4258-810e-5ae8442c717c", "Administrator", "ADMINISTRATOR" },
                    { 2, "db842a85-6ae8-482a-beb9-3e5271973189", "Uposlenik", "UPOSLENIK" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GradID", "Ime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prezime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 3, 0, "a64314f5-959e-40c3-86ac-268ff395eb24", "korisnik@restoran.com", false, null, "Korisnik", false, null, "KORISNIK@RESTORAN.COM", null, "AQAAAAEAACcQAAAAEN1rjx97Nm8gJof/WpSfZkzDZF30QmwFVtqdgY/MbaoJWK7xtyu2eW1AVPGwJugjMA==", null, false, "Korisnik", "4e0259c9-feca-49e0-a21c-b32a72e89a95", false, "Korisnik" },
                    { 2, 0, "7eb443ff-e768-4a78-aa27-a7cf94afe13a", "uposlenik@restoran.com", false, null, "Uposlenik", false, null, "UPOSLENIK@RESTORAN.COM", null, "AQAAAAEAACcQAAAAEKC4ICj4yWv1C5LXItZ0AnMJS7Uca87UAj+hfUvsTX4XU/cvDQiHqhFNXRnDE124Bw==", null, false, "Uposlenik", "40c929e8-2d1e-432b-9bfb-9cb7c576db97", false, "Uposlenik" },
                    { 1, 0, "01f95c66-bfc5-4152-8cdd-34b7bb72c4da", "admin@restoran.com", false, null, "Admin", false, null, "ADMIN@RESTORAN.COM", null, "AQAAAAEAACcQAAAAEBccacVlcWqW5XCtSQ0H1/ekuR0j5wn+eazbhmcDRYhnhCxGl8oNe1y/d9xGGd3xxw==", null, false, "Admin", "59454710-9d4e-454b-b8eb-54d50b292a62", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "ID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Pizza", "Različite vrste pizza spremljene sa pažljivo odabranim i kvalitetnim namirnicama, pečene na tradicionalan način" },
                    { 4, "Salate", "Napravljene od svježih sastojaka, super zdrave i idealan obrok za svaki dio dana" },
                    { 3, "Ribe", "Bogat izvor vitamina, minerala, bjelančevina, kao i omega 3 masnih kiselina" },
                    { 2, "Supe", "Supe od svježeg povrća, idealne su kao predjelo" },
                    { 5, "Pića", "Razne vrste gaziranih i negaziranih pića, kao i toplih napitaka" }
                });

            migrationBuilder.InsertData(
                table: "Namirnice",
                columns: new[] { "ID", "CijenaPoKomadu", "JedinicaMjere", "Kolicina", "Naziv" },
                values: new object[,]
                {
                    { 2, 1.0, "kilogram", 100, "Brašno" },
                    { 3, 0.90000000000000002, "kilogram", 20, "So" },
                    { 1, 0.90000000000000002, "kilogram", 20, "Ulje" }
                });

            migrationBuilder.InsertData(
                table: "StatusiDostave",
                columns: new[] { "ID", "Status" },
                values: new object[,]
                {
                    { 1, "Narudžba prihvaćena" },
                    { 2, "Narudžba odbijena" },
                    { 3, "Narudžba u obradi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Jela",
                columns: new[] { "ID", "Cijena", "Favorit", "KategorijaID", "Naziv", "Opis", "Slika" },
                values: new object[,]
                {
                    { 12, 3.0, false, 5, "Prirodni sokovi", "Prirodno cijeđeni sokovi sa okusima naranče, jagode, višnje, jabuke, breskve, ananasa...", "images\\jela\\prirodni_sokovi.jpg" },
                    { 11, 3.0, false, 5, "Coca Cola", "Classic ili Zero, opcionalno poslužena sa ledom i limunom", "images\\jela\\coca_cola.jpg" },
                    { 10, 2.5, false, 5, "Macchiato", "Kombinacija toplog mlijeka, pjene od mlijeka i espresso kafe", "images\\jela\\macchiato.jpg" },
                    { 13, 8.0, false, 4, "Mozzarella salata", "Mozzarela, paradajz, rotkvica, rukola, zelena salata, masline, aceto balsamico, pecivo. ", "images\\jela\\mozzarella_salata.jpg" },
                    { 8, 8.0, false, 4, "Pileća salata", "Pileći file, paradajz, rotkvica, rukola, zelena salata, krastavac, pecivo", "images\\jela\\pileća_salata.jpg" },
                    { 9, 8.0, false, 4, "Tuna salata", "Komadići tune, paradajz, rotkvica, rukola, zelena salata, krastavac, maslinovo ulje, aceto balsamico, pecivo", "images\\jela\\tuna_salata.jpg" },
                    { 6, 25.0, true, 3, "Losos verdura sa žara", "File lososa, tikvice, krompir, paprika, patlidžan, maslinovo ulje", "images\\jela\\losos_zar.jpg" },
                    { 5, 5.0, true, 2, "Krem supa od tikve", "Svježe pripremana krem supa od tikve", "images\\jela\\supa_tikva.jpg" },
                    { 4, 4.0, false, 2, "Krem supa od paradajza", "Svježe pripremana krem supa od paradajza sa mozzarelom i rižom", "images\\jela\\supa_paradajz.jpg" },
                    { 14, 8.0, false, 1, "Pizza Tonno", "Paradajz sos, origano, sir, luk, tunjevina, crne masline. ", "images\\jela\\tonno.jpg" },
                    { 3, 8.0, false, 1, "Pizza Vegeteriana", "Paradajz sos, svježi paradajz, paprika, origano, sir, tikvice, gljive", "images\\jela\\vegeteriana.jpg" },
                    { 2, 7.0, false, 1, "Pizza Funghi", "Paradajz sos, origano, sir i gljive", "Images\\jela\\funghi.jpg" },
                    { 7, 25.0, false, 3, "Losos sa žara sa špinatom", "File lososa, tikvice, krompir, špinat, paprika, patlidžan", "images\\jela\\losos_zar_spinat.jpg" },
                    { 1, 6.0, true, 1, "Pizza Margherita", "Paradajz sos, origano i sir", "Images\\jela\\margherita.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Narudzbe",
                columns: new[] { "ID", "Adresa", "DatumNarudzbe", "KorisnikID", "NacinPlacanjaID", "StatusDostaveID", "Telefon", "UposlenikID" },
                values: new object[,]
                {
                    { 1, "Adresa 1", new DateTime(2021, 1, 13, 7, 47, 14, 87, DateTimeKind.Local).AddTicks(5039), 3, null, 1, "0601111111", 2 },
                    { 2, "Adresa 2", new DateTime(2021, 1, 13, 7, 47, 14, 89, DateTimeKind.Local).AddTicks(7026), 3, null, 2, "0602222222", 2 },
                    { 3, "Adresa 3", new DateTime(2021, 1, 13, 7, 47, 14, 89, DateTimeKind.Local).AddTicks(7074), 3, null, 3, "0603333333", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_UlogaId",
                table: "AspNetRoleClaims",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_KorisnikId",
                table: "AspNetUserClaims",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_KorisnikId",
                table: "AspNetUserLogins",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GradID",
                table: "AspNetUsers",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_KorisnikId",
                table: "AspNetUserTokens",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Jela_KategorijaID",
                table: "Jela",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikNamirnice_NamirnicaID",
                table: "KorisnikNamirnice",
                column: "NamirnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorpaStavke_JeloID",
                table: "KorpaStavke",
                column: "JeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_JeloID",
                table: "Likes",
                column: "JeloID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaDetalji_JeloID",
                table: "NarudzbaDetalji",
                column: "JeloID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaDetalji_NarudzbaID",
                table: "NarudzbaDetalji",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_KorisnikID",
                table: "Narudzbe",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_NacinPlacanjaID",
                table: "Narudzbe",
                column: "NacinPlacanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_StatusDostaveID",
                table: "Narudzbe",
                column: "StatusDostaveID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_UposlenikID",
                table: "Narudzbe",
                column: "UposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_KorisnikID",
                table: "RefreshTokens",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikID",
                table: "Rezervacije",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_UposlenikID",
                table: "Rezervacije",
                column: "UposlenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KorisnikNamirnice");

            migrationBuilder.DropTable(
                name: "KorpaStavke");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "NarudzbaDetalji");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Namirnice");

            migrationBuilder.DropTable(
                name: "Jela");

            migrationBuilder.DropTable(
                name: "Narudzbe");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "NaciniPlacanja");

            migrationBuilder.DropTable(
                name: "StatusiDostave");

            migrationBuilder.DropTable(
                name: "Gradovi");
        }
    }
}

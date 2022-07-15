using eRestoran.Database;
using eRestoran.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using eRestoran.Services;
using Microsoft.OpenApi.Models;
using eRestoran.Shared.Settings;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.WebApi.Filters;
using Microsoft.AspNetCore.Identity;
using eRestoran.LocalizationService;
using eRestoran.EmailService;

namespace eRestoran.WebApi
{
    public class Startup
    {
        

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<eRestoranContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("eRestoranDatabase")));
            services.AddIdentity<Korisnik, Uloga>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<eRestoranContext>();


            // eRestoran.Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJeloService, JeloService>();
            services.AddScoped<ICrudService<GradResponse, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>, GradService>();
            services.AddScoped<ICrudService<KategorijaResponse, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest>, KategorijaService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<ICrudService<KorpaStavkaResponse, KorpaStavkaSearchRequest, KorpaStavkaUpsertRequest,KorpaStavkaUpsertRequest>, KorpaStavkaService>();
            services.AddScoped<IBaseService<UlogaResponse, object>, UlogaService>();
            services.AddScoped<IKorpaStavkaService, KorpaStavkaService>();
            services.AddScoped<ICrudService<NamirnicaResponse, NamirnicaSearchRequest, NamirnicaUpsertRequest, NamirnicaUpsertRequest>, NamirnicaService>();
            services.AddScoped<IBaseService<StatusDostaveResponse, object>, StatusDostaveService>();
            services.AddScoped<IRezervacijaService, RezervacijaService>();
            services.AddScoped<IAnalyticsService, AnalyticsService>();

            services.AddScoped<IdentityErrorDescriber, IdentityErrorDescriberBA>();

            // AutoMapper
            services.AddAutoMapper(typeof(Mappings.KorisnikProfile));
            services.AddAutoMapper(typeof(Mappings.JeloProfile));
            services.AddAutoMapper(typeof(Mappings.GradProfile));
            services.AddAutoMapper(typeof(Mappings.UlogaProfil));
            services.AddAutoMapper(typeof(Mappings.KategorijaProfile));
            services.AddAutoMapper(typeof(Mappings.KorpaProfile));
            services.AddAutoMapper(typeof(Mappings.NamirnicaProfile));
            services.AddAutoMapper(typeof(Mappings.NarudzbaProfile));
            services.AddAutoMapper(typeof(Mappings.RezervacijaProfile));
            

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eRestoran API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("eRestoranCors",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthorization();
            services.AddControllers(x => x.Filters.Add<ErrorFilter>());
            services.AddHttpContextAccessor();
            var emailConfig = Configuration.GetSection("EmailConfiguration")
              .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("eRestoranCors");

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eRestoran API");
                c.RoutePrefix = "";
            });
        }
    }
}

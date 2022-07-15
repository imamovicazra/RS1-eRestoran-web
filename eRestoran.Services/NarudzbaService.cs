using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.EmailService;
namespace eRestoran.Services
{
    public class NarudzbaService : 
        BaseService<NarudzbaResponse, NarudzbaSearchRequest, Narudzba>,
        INarudzbaService
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public NarudzbaService(eRestoranContext context, IMapper mapper,IEmailSender emailSender) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _emailSender = emailSender;
        }

       

        public async override Task<PagedResponse<NarudzbaResponse>> Get(NarudzbaSearchRequest search, PaginationQuery pagination)
        {
            var query = _context.Set<Narudzba>()
                .Include(s => s.StatusDostave)
                .Include(k => k.Korisnik)
                .AsNoTracking()
                .OrderByDescending(i => i.DatumNarudzbe)
                .AsQueryable();

            query = ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var pagedResponse = await GetPagedResponse(_mapper.Map<List<NarudzbaResponse>>(list), search, pagination);
            return pagedResponse;
        }

        public override async Task<NarudzbaResponse> GetById(int id)
        {
            var entity = await _context.Set<Narudzba>()
                .Include(s => s.StatusDostave)
                .Include(k => k.Korisnik)
                .Include(u => u.Uposlenik)
                .AsNoTracking()
                .SingleOrDefaultAsync(i => i.ID == id);

            return _mapper.Map<NarudzbaResponse>(entity);
        }

        public async Task<List<NarudzbaDetaljiResponse>> GetDetalji(int id)
        {
            var list = await _context.NarudzbaDetalji
                .Include(i => i.Jelo)
                .Where(i => i.NarudzbaID == id)
                .ToListAsync();

            return _mapper.Map<List<NarudzbaDetaljiResponse>>(list);
        }

        public async Task<NarudzbaResponse> Insert(int korisnikID, NarudzbaInsertRequest request)
        {
            var nacinPlacanja = new NacinPlacanja() { Naziv = "Pouzećem" };
            _context.NaciniPlacanja.Add(nacinPlacanja);
            await _context.SaveChangesAsync();

            var entity = _mapper.Map<Narudzba>(request);

            entity.KorisnikID = korisnikID;
            entity.NacinPlacanjaID = nacinPlacanja.ID;

            _context.Set<Narudzba>().Add(entity);
            await _context.SaveChangesAsync();

            foreach (var detalj in request.NarudzbaDetalji)
            {
                detalj.NarudzbaID = entity.ID;
            }
            var detalji = _mapper.Map<List<NarudzbaDetalji>>(request.NarudzbaDetalji);
            _context.NarudzbaDetalji.AddRange(detalji);
            await _context.SaveChangesAsync();

            double suma = 0;
            var message = "Poštovana/i, " + _context.Users.Find(entity.KorisnikID).Ime + " " + _context.Users.Find(entity.KorisnikID).Prezime +
                ", uspješno ste naručili vaša jela: \n";
            message += "\n";
            foreach (var x in detalji)
            {
                message += _context.Jela.Find(x.JeloID).Naziv + "\t" + " - "+x.Cijena + " KM" + "(" + x.Kolicina + " kom), \n";
                suma += x.Kolicina * x.Cijena;
            }

            message += "Ukupna cijena narudžbe: " + suma + " KM \n";
            message += "Lijep pozdrav!";
            
                
            await _emailSender.SendEmailAsync(new string[] { entity.Korisnik.Email }, "Potvrda narudžbe", message);

            return _mapper.Map<NarudzbaResponse>(entity);
        }

        public async Task<NarudzbaResponse> UpdateStatusDostave(int id, int korisnikID, int statusID)
        {
            var entity = await _context.Set<Narudzba>().FindAsync(id);

            _context.Set<Narudzba>().Attach(entity);
            _context.Set<Narudzba>().Update(entity);

            entity.StatusDostaveID = statusID;
            entity.UposlenikID = korisnikID;
          

            await _context.SaveChangesAsync();

            return _mapper.Map<NarudzbaResponse>(entity);

        }

        protected override IQueryable<Narudzba> ApplyFilter(IQueryable<Narudzba> query, NarudzbaSearchRequest search)
        {
            if(search != null)
            {
                if(!string.IsNullOrEmpty(search.Adresa))
                {
                    query = query.Where(i => i.Adresa.ToLower().Contains(search.Adresa.ToLower()));
                }
            }

            return query;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Set<Narudzba>().FindAsync(id);

            try
            {
                _context.Set<Narudzba>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<NarudzbaResponse> Update(int id, NarudzbaUpdateRequest request)
        {

            var entity = _context.Set<Narudzba>().Find(id);
            if (!string.IsNullOrEmpty(request.Adresa))
                entity.Adresa = request.Adresa;
            if (request.Telefon != null)
                entity.Telefon = request.Telefon;
            
            _context.Set<Narudzba>().Attach(entity);
            _context.Set<Narudzba>().Update(entity);

            await _context.SaveChangesAsync();

            var nacinPlacanja = _context.Set<NacinPlacanja>().Find(entity.NacinPlacanjaID);

            if (request.NazivPlacanja == "Karticom")
            {
                nacinPlacanja.Naziv = request.NazivPlacanja;
                nacinPlacanja.BrojKartice = request.BrojKartice;
                nacinPlacanja.CVV = request.CVV;
            }

            await _context.SaveChangesAsync();


            return _mapper.Map<NarudzbaResponse>(entity);
        }
    }
}

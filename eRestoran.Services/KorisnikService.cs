using AutoMapper;
using eRestoran.Contracts.Requests;
using eRestoran.Contracts.Responses;
using eRestoran.Database;
using eRestoran.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eRestoran.Services
{
    public class KorisnikService : 
        CrudService<KorisnikResponse, KorisnikSearchRequest, Korisnik, object, KorisnikUpdateRequest>, 
        IKorisnikService
    {
        private readonly eRestoranContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Korisnik> _userManager;
        public KorisnikService(eRestoranContext context, IMapper mapper, UserManager<Korisnik> userManager) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        public async Task<IdentityResult> ChangePassword(int ID, ChangePasswordRequest request)
        {
            var entity = await _context.Set<Korisnik>().FindAsync(ID);
            var user = await _userManager.FindByEmailAsync(entity.Email);

            return await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        }

        public override async Task<PagedResponse<KorisnikResponse>> Get(KorisnikSearchRequest search, PaginationQuery pagination)
        {
            var query = _context.Set<Korisnik>()
                .Include(i => i.KorisnikUloge)
                .ThenInclude(i => i.Uloga)
                .AsNoTracking()
                .AsQueryable();

            query = ApplyFilter(query, search);

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            var list = await query.ToListAsync();
            var response = _mapper.Map<List<KorisnikResponse>>(list);
            for (int i = 0; i < list.Count(); i++)
            {
                response[i].Uloge = _mapper.Map<List<UlogaResponse>>(list[i].KorisnikUloge.Select(i => i.Uloga).ToList());
            }

            var pagedResponse = await GetPagedResponse(response, search, pagination);
            return pagedResponse;
        }

        public override async Task<KorisnikResponse> GetById(int id)
        {
            var entity = await _context.Set<Korisnik>()
                .Include(i => i.KorisnikUloge)
                .ThenInclude(i => i.Uloga)
                .Where(i => i.Id == id)
                .SingleOrDefaultAsync();

            var response = _mapper.Map<KorisnikResponse>(entity);
            response.Uloge = _mapper.Map<List<UlogaResponse>>(entity.KorisnikUloge.Select(i => i.Uloga).ToList());
            return response;
        }

        public async Task<List<JeloResponse>> GetLajkanaJela(int id)
        {
            var x = await _context.Likes.Include(i=>i.Jelo).Include(j=>j.Jelo.Kategorija).Where(i => i.KorisnikID == id).Select(i => i.Jelo).ToListAsync();
            return _mapper.Map<List<JeloResponse>>(x);
        }

        public override async Task<KorisnikResponse> Update(int id, KorisnikUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.AddToRolesAsync(user, request.NoveUloge);
            await _userManager.RemoveFromRolesAsync(user, request.ObrisaneUloge);

            
            return _mapper.Map<KorisnikResponse>(user);
        }

        public async Task<KorisnikResponse> UpdateLicneInformacije(int ID, KorisnikUpdateInfoRequest request)
        {
            var entity = await _context.Set<Korisnik>().FindAsync(ID);

            var user = await _userManager.FindByEmailAsync(entity.Email);
            
            if(!string.IsNullOrEmpty(request.Ime) && user.Ime != request.Ime)
            {
                user.Ime = request.Ime;
            }

            if (!string.IsNullOrEmpty(request.Prezime) && user.Prezime != request.Prezime)
            {
                user.Prezime = request.Prezime;
            }

            if (!string.IsNullOrEmpty(request.Email) && user.Email != request.Email)
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, request.Email);
                await _userManager.ChangeEmailAsync(user, request.Email, token);
            }

            if (request.GradID != null && user.GradID != request.GradID)
            {
                user.GradID = request.GradID;
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<KorisnikResponse>(entity);
        }

        protected override IQueryable<Korisnik> ApplyFilter(IQueryable<Korisnik> query, KorisnikSearchRequest search)
        {

            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Ime))
                {
                    query = query.Where(i => i.Ime.Contains(search.Ime));
                }

                if (!string.IsNullOrEmpty(search.Prezime))
                {
                    query = query.Where(i => i.Prezime.ToLower().StartsWith(search.Prezime.ToLower()));
                }

                if (!string.IsNullOrEmpty(search.Email))
                {
                    query = query.Where(i => i.NormalizedEmail.StartsWith(search.Ime.ToUpper()));
                }

                if (search.Uloge?.Count() > 0)
                {
                    query = query.Where(i => i.KorisnikUloge.Any(j => search.Uloge.Contains(j.Uloga.Name)));
                }
            }

            return query;
        }
    }
}

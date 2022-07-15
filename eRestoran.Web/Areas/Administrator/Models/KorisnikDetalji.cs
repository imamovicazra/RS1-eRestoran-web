using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace eRestoran.Web.Areas.Administrator.Models
{
    public class KorisnikDetalji
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        [DisplayName("Grad")]
        public int? GradID { get; set; }
        public IList<SelectListItem> Gradovi { get; set; }
        public IList<int> TrenutneUloge { get; set; }
        public IList<KorisnikUlogaCheckListItem> SveUloge { get; set; } = new List<KorisnikUlogaCheckListItem>();
    }
}

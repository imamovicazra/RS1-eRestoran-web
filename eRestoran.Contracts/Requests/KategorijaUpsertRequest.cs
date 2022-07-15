using System;
using System.Collections.Generic;
using System.Text;

namespace eRestoran.Contracts.Requests
{
    public class KategorijaUpsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}

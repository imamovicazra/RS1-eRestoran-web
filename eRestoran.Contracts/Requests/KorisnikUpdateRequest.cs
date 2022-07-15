using System.Collections.Generic;

namespace eRestoran.Contracts.Requests
{
    public class KorisnikUpdateRequest
    {
        public IList<string> NoveUloge { get; set; }
        public IList<string> ObrisaneUloge { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace eRestoran.Web.Helpers
{
    public class ImageHelper
    {
        public static async Task<string> Upload(IFormFile file, string folder, string fileName)
        {
            var putanja = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\{folder}\\", fileName);
            using (var fajlSteam = new FileStream(putanja, FileMode.Create))
            {
                await file.CopyToAsync(fajlSteam);
            }

            return $"images\\{folder}\\" + fileName;
        }
    }
}

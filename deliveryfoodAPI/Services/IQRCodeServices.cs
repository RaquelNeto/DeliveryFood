using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace deliveryFoodAPI.Services
{
    public interface IQRCodeServices
    {
        Task<string> Create(string requestUrl);
    }

    public class QRCodeService : IQRCodeServices
    {
        public string QRcodeURL { get; set; }
  
      
        public async Task<string> Create(string requestUrl)
        {
            HttpClient client = new HttpClient();
            string createURL = QRcodeURL.Replace("dataURL", requestUrl);
            HttpResponseMessage response = await client.GetAsync(createURL);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return createURL;
        }
    }
}

using ForustaSpotify.Common.Constants;
using ForustaSpotify.Data.Models.SpotifyResponse;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.BL.Clients.SpotifyRequest
{
    public class SpotifyRequestClient : ISpotifyRequestClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SpotifyRequestClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> GetData<TResponse>(string url)
            where TResponse : class, ISpotifyResponseModel
        {
            using (HttpClient client = new HttpClient())
            {
                var accessToken = _httpContextAccessor
                    .HttpContext.Request.Cookies[SpotifyWebFields.AccessToken];

                // access Spotify Web API with
                // Authorization: Bearer accessToken
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await client.GetAsync(url);

                var readedContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(readedContent);
            }
        }
    }
}

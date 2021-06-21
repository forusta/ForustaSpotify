using ForustaSpotify.BL.Clients.Interfaces;
using ForustaSpotify.BL.Repositories.Interfaces;
using ForustaSpotify.Common.Constants;
using ForustaSpotify.Data.Models.SpotifyAuth;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ForustaSpotify.BL.Clients
{
    public class SpotifyAuthClient : ISpotifyAuthClient
    {
        private readonly IRepository _repository;

        SpotifyAuthModel spotifyAuth = new SpotifyAuthModel();

        public SpotifyAuthClient(IRepository repository)
        {
            _repository = repository;
        }

        public string BuildAuthQuery(string redirectUrl)
        {
            var queryBuilder = new QueryBuilder();

            queryBuilder.Add("response_type", "code");
            //TODO: Get this data from Database
            queryBuilder.Add("client_id", spotifyAuth.clientID);
            queryBuilder.Add("scope", "user-read-private user-read-email");
            queryBuilder.Add("redirect_uri", redirectUrl);

            return SpotifyUrls.AuthUrl + queryBuilder.ToQueryString().ToString();
        }

        public async Task<SpotifyAuthTokenModel> Auth(string inputCode)
        {
            if (string.IsNullOrWhiteSpace(inputCode))
            {
                return new SpotifyAuthTokenModel();
            }

            var responseString = await GetSpotifyResponse(inputCode);

            return JsonConvert.DeserializeObject<SpotifyAuthTokenModel>(responseString);
        }

        private async Task<string> GetSpotifyResponse(string inputCode)
        {
            string responseString = "";
            using (HttpClient client = new HttpClient())
            {
                // set basic authorization:
                // Spotify accepts format: Authorization: Basic *<base64 encoded client_id:client_secret>*
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        //TODO: Get this data from Database
                        ASCIIEncoding.ASCII.GetBytes(spotifyAuth.clientID + ":" + spotifyAuth.clientSecret))
                    );

                FormUrlEncodedContent formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("code", inputCode),
                    //new KeyValuePair<string, string>("redirect_uri", redirectUrl),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                });

                var response = await client.PostAsync(SpotifyUrls.AccountApiTokenUrl, formContent);

                var responseContent = response.Content;
                responseString = await responseContent.ReadAsStringAsync();
            }

            return responseString;
        }
    }
}

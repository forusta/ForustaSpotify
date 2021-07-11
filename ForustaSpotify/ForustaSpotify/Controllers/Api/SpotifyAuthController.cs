using ForustaSpotify.BL.Clients.Interfaces;
using ForustaSpotify.Common.Constants;
using ForustaSpotify.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForustaSpotify.Api.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SpotifyAuthController : Controller
    {
        private readonly ISpotifyAuthClient _spotifyAuthService;

        public SpotifyAuthController(ISpotifyAuthClient spotifyAuthService)
        {
            _spotifyAuthService = spotifyAuthService;
        }

        [HttpGet]
        [Route("auth")]
        public async Task<IActionResult> Auth()
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var redirectUrl = Url.Action(nameof(AuthCallback), controllerName, null, HttpContext.Request.Scheme);

            var queryString = _spotifyAuthService.BuildAuthQuery(redirectUrl);

            return Json(queryString);
        }

        [Route("/callback")]
        public async Task<IActionResult> AuthCallback(string code)
        {
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;
            var redirectUrl = Url.Action(nameof(AuthCallback), controllerName, null, HttpContext.Request.Scheme);

            var authTokenModel = await _spotifyAuthService.Auth(code, redirectUrl);

            var cookies = HttpContext.Response.Cookies;

            cookies.Append(SpotifyWebFields.AccessToken, authTokenModel.AccessToken);
            cookies.Append(SpotifyWebFields.TokenType, authTokenModel.TokenType);
            cookies.Append(SpotifyWebFields.RefreshToken, authTokenModel.RefreshToken);
            cookies.Append(SpotifyWebFields.ExpiresIn, authTokenModel.ExpiresIn.ToString());
            cookies.Append(SpotifyWebFields.Scope, authTokenModel.Scope);

            return Json(authTokenModel);
        }
    }
}

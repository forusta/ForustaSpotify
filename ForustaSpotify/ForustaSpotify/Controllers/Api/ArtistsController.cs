using ForustaSpotify.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForustaSpotify.Api.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ArtistsController : Controller
    {
        private readonly IArtistReadService _artistReadService;

        public ArtistsController(IArtistReadService artistReadService)
        {
            _artistReadService = artistReadService;
        }

        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var responseData = await _artistReadService.GetArtist(id);
            return Json(responseData);
        }

        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            var artists = await _artistReadService.SearchArtists(name);
            return Json(artists);
        }
    }
}

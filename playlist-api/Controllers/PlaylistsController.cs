using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace playlist_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistsController : ControllerBase
    {

        private readonly ILogger<PlaylistsController> _logger;
        public PlaylistsController(ILogger<PlaylistsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<Playlist> Get()
        {
            yield return new Playlist
            {
                id = 1,
                title = "Test List",
                description = "listy list",
                genre = "Music",
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now
            };
        }
    }
}

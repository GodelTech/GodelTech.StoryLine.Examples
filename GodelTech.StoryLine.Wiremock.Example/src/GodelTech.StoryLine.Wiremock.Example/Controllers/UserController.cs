using System;
using GodelTech.StoryLine.Wiremock.Example.Services;
using GodelTech.StoryLine.Wiremock.Example.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GodelTech.StoryLine.Wiremock.Example.Controllers
{
    [Route("v1/users")]
    public class UserController : Controller
    {
        private const string UseDetailsRoute = "UserDetails";

        private readonly IUserResource _userResource;

        public UserController(IUserResource userResource)
        {
            _userResource = userResource ?? throw new ArgumentNullException(nameof(userResource));
        }

        [HttpGet]
        public IActionResult GetAll(int skip = 0, int take = 10)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip));
            if (take <= 0)
                throw new ArgumentOutOfRangeException(nameof(take));

            return Ok(_userResource.GetAll(skip, take));
        }

        [HttpGet("{id}", Name = UseDetailsRoute)]
        public IActionResult GetUser(long id)
        {
            var user = _userResource.GetUser(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var createdUser = _userResource.Create(user);

            return Created(Url.RouteUrl(UseDetailsRoute, new { id = createdUser.Id }), createdUser);
        }
    }
}

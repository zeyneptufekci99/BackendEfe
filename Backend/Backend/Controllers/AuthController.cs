using Backend.Application.CQRS.Commands;
using Backend.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _meditor;

        public AuthController(IMediator meditor)
        {
            _meditor = meditor;
        }
        //api/Auth post
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] CheckUserQuery query)
        {
            var UserDto = await _meditor.Send(query);

            if(UserDto == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }

            TokenGenerator tokenGenerator = new TokenGenerator();
            var token = tokenGenerator.GenerateJwt(UserDto);
            return Created("",token);
        }


        /// <summary>
        ///  DONT USE
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetUserInfo()
        {
           var name = User.Claims?.FirstOrDefault(x => x.Type == "Name")?.Value;
            return Ok(name);
        }
    }
}

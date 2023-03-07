using DTO.AuthenticationDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.AuthenticationRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticationController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthenRequest request)
        {
            var user = await _authRepository.Login(request);
            return user == null ? NotFound() : Ok(user);
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authRepository.Register(request));
        }
    }
}

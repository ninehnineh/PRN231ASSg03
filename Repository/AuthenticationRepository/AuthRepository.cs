using BusinessObject.Entities;
using DataAccess.Authen;
using DataAccess.Response;
using DTO.AuthenticationDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AuthenticationRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationDAO _authenticationDAO;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public AuthRepository(UserManager<AspNetUsers> userManager,
               IOptions<JwtSettings> jwtSettings,
            SignInManager<AspNetUsers> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _signInManager = signInManager;
            _configuration = configuration;
            _authenticationDAO = new AuthenticationDAO(_userManager, _jwtSettings, _signInManager,_configuration);
        }
        public async Task<BaseResponse<AuthenResponse>> Login(AuthenRequest request)
        {
            return await _authenticationDAO.Login(request);
        }

        public async Task<BaseResponse<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return await _authenticationDAO.Register(request);
        }
    }
}

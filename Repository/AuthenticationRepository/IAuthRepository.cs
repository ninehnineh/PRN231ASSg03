using DataAccess.Response;
using DTO.AuthenticationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AuthenticationRepository
{
    public interface IAuthRepository
    {
        Task<BaseResponse<AuthenResponse>> Login(AuthenRequest request);
        Task<BaseResponse<RegistrationResponse>> Register(RegistrationRequest request);
    }
}

using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Dto.User.Login;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CardPortal.Application.Command.User
{
    public record LoginCommand(LoginDto login) : IRequest<ServiceResponse<TokenDto>>;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResponse<TokenDto>>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(
            IUserRepository UserRepository, 
            IMapper mapper,
            IConfiguration configuration
            )
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<TokenDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Service Response - Init
                ServiceResponse<TokenDto> serviceResponse = new ServiceResponse<TokenDto>();

                // Login - From User Write Dto - Map
                var Login = _mapper.Map<Login>(request.login);

                // Login - Check
                var loginCheck = await _UserRepository.Login(Login);

                if (loginCheck.StatusCode == HttpStatusCode.OK)
                {
                    // Token - Get
                    var token = GetToken();

                    // Update User Last Login Time
                    //var userId = await UpdateUserLastLoginTime(loginDto: request.login);

                    // Service Response - Status Code
                    serviceResponse.StatusCode = HttpStatusCode.OK;

                    // Token - Init
                    serviceResponse.SetData(new TokenDto());
                    // Token - Set
                    serviceResponse.Data.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    serviceResponse.Data.Expiration = token.ValidTo;
                    serviceResponse.Data.UserId = loginCheck.Data;
                }
                else
                {
                    // Service Response
                    serviceResponse.StatusCode = HttpStatusCode.Unauthorized;
                    serviceResponse.SetData(new TokenDto());
                    serviceResponse.Data.Token = string.Empty;
                    loginCheck.Errors.ForEach(error => serviceResponse.Errors.Add(error));
                }

                return serviceResponse;
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TokenDto>(
                    HttpStatusCode.InternalServerError,
                    new TokenDto(),
                    new List<string>() { GenericError.GenericErrorMessage, ex.Message });
            }
        }

        // Token - Get
        private JwtSecurityToken GetToken()
        {
            // Auth Key - From Config
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            // Token
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        // User - Update Last Login Time
        private async Task<int> UpdateUserLastLoginTime(LoginDto loginDto)
        {
            // Login - From Lgoin Dto - Map
            var Login = _mapper.Map<Login>(loginDto);
            // User - Login - Update Last Login Time
            var result = await _UserRepository.Login(login: Login);
            // User Id - Get
            return result.Data;
        }
    }
}

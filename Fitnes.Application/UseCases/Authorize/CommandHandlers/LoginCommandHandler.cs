using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Authorize.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.UseCases.Authorize.CommandHandlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAppDbContext context;
        private readonly IHashService hashService;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        public LoginCommandHandler(IAppDbContext context, IHashService hashService, IMapper mapper, ITokenService tokenService)
        {
            this.context = context;
            this.hashService = hashService;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }
        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users.Include(x => x.Chat).ThenInclude(x => x.Messages).FirstOrDefaultAsync(x => x.Email == request.EmailOrPhone || x.Phone == request.EmailOrPhone, cancellationToken);
            if (user == null || user.PasswordHash != hashService.GetHash(request.Password))
            {
                throw new Exception("Login exception");
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

            return new LoginViewModel
            {
                User = mapper.Map<UserViewModel>(user),
                AccessToken = tokenService.GetAccessToken(claims.ToArray())
            };
        }
    }
}

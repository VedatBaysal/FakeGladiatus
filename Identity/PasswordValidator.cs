using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeGladiatus.Application.Services.Interfaaces;
using IdentityModel;

namespace Identity
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;
        public PasswordValidator(IUserService  userService)
        {
            _userService = userService;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _userService.CheckForLogin(context.UserName,context.Password);
            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
            return Task.FromResult(0);
        }
    }
}

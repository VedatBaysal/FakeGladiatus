using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity
{
    public class ProfileService : IdentityServer4.Services.IProfileService
    {
        private readonly IUserService _userService; 
        public ProfileService(IUserService userService)
        {
            _userService = userService;
        }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            User u = _userService.GetUser(Convert.ToInt32(context.Subject.Claims.FirstOrDefault(x=>x.Type=="sub").Value));
            context.IssuedClaims.Add(new Claim(ClaimTypes.Email,u.Email));
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}

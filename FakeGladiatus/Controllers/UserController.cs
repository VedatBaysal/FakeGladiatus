using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using FakeGladiatus.Shared.Models.Character;
using FakeGladiatus.Shared.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeGladiatus.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]UserLoginModel userLogin)
        {
            UserLoginSuccess user = new UserLoginSuccess();
            var checkForLogin = _userService.CheckForLogin(userLogin.UserName, userLogin.Password);
            if (checkForLogin != null)
            {

                user.Id = checkForLogin.Id;
                user.NickName = checkForLogin.NickName;
                return Ok(user);
            }
            else
            {
                return BadRequest("Yanlış bilgi");
            }
        }
        [HttpPost("character")]
        public IActionResult GenerateCharacter([FromBody]CharacterGenerateModel characterModel)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                var models = _mapper.Map<Character>(characterModel);
                return Ok(_userService.GenerateCharacter(Convert.ToInt32(userId), models));
            }
            return BadRequest();
            //Character c = new Character
            //{
            //    Agility = Convert.ToInt32(characterModel.Agility),
            //    Defense = Convert.ToInt32(characterModel.Defence),
            //    Hp = Convert.ToInt32(characterModel.Hp),
            //    Intelligence = Convert.ToInt32(characterModel.Intelligence),
            //    Name = characterModel.Name,
            //    Power = Convert.ToInt32(characterModel.Power)
            //};

            //return Ok(_userService.GenerateCharacter(Convert.ToInt32(characterModel.UserId), c));
        }
        [HttpGet("characters")]
        public IActionResult GetCharacters()
       
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                var email = claimsIdentity.FindFirst(ClaimTypes.Email).Value;
                IEnumerable<Character> u = _userService.GetCharacters(Convert.ToInt32(userId));
                IEnumerable<CharacterReadModel> models = _mapper.Map<IEnumerable<CharacterReadModel>>(u);

                return Ok(models);
            } return BadRequest();
            //List<CharacterReadModel> characterReadModels = new List<CharacterReadModel>();
            //foreach (var item in u)
            //{
            //    CharacterReadModel crm = new CharacterReadModel
            //    {
            //        Agility = item.Agility,
            //        Defense = item.Defense,
            //        Hp = item.Hp,
            //        Id = item.Id,
            //        Intelligence = item.Intelligence,
            //        Name = item.Name,
            //        Power = item.Power
            //    };
            //    characterReadModels.Add(crm);
            //}
            //return Ok(characterReadModels);
        }
        [HttpGet("nickname")]
        public IActionResult GetNickName()
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                string nickName = _userService.GetNickName(Convert.ToInt32(userId));
                return Ok(nickName);

            }
            return BadRequest();
        }

        [HttpGet("auth")]
        public IActionResult TestValidator()
        {
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using FakeGladiatus.Shared.Models.Character;
using FakeGladiatus.Shared.Models.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeGladiatus.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
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
            Character c = new Character
            {
                Agility = Convert.ToInt32(characterModel.Agility),
                Defense = Convert.ToInt32(characterModel.Defence),
                Hp = Convert.ToInt32(characterModel.Hp),
                Intelligence = Convert.ToInt32(characterModel.Intelligence),
                Name = characterModel.Name,
                Power = Convert.ToInt32(characterModel.Power)
            };

            return Ok(_userService.GenerateCharacter(Convert.ToInt32(characterModel.UserId), c));
        }
        [HttpGet("{id}")]
        public IActionResult GetCharacters(string id)
        {
            var u = _userService.GetCharacters(Convert.ToInt32(id));
            List<CharacterReadModel> characterReadModels = new List<CharacterReadModel>();
            foreach (var item in u)
            {
                CharacterReadModel crm = new CharacterReadModel
                {
                    Agility = item.Agility,
                    Defense = item.Defense,
                    Hp = item.Hp,
                    Id = item.Id,
                    Intelligence = item.Intelligence,
                    Name = item.Name,
                    Power = item.Power
                };
                characterReadModels.Add(crm);
            }
            return Ok(characterReadModels);
        }

    }
}

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
        private readonly INotificationService _notificationService;
        private readonly IAttackSystemService _attackSystemService;
        public UserController(IUserService userService, IMapper mapper, IAttackSystemService attackSystemService,INotificationService notificationService)
        {
            _userService = userService;
            _mapper = mapper;
            _attackSystemService = attackSystemService;
            _notificationService = notificationService;
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
        }
        [HttpGet("characters")]
        public IActionResult GetCharacters()
       
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                IEnumerable<CharacterReadModel> models = GetCharacters(Convert.ToInt32(userId));
                return Ok(models);
            }
            return BadRequest();
        }
        [HttpGet("{id}/characters")]
        public IActionResult GetUsersCharacters(int id)
        {
            return Ok(GetCharacters(id));
        }

        private IEnumerable<CharacterReadModel> GetCharacters(int userId)
        {
            User user = _userService.GetUser(Convert.ToInt32(userId));
            IEnumerable<CharacterReadModel> models = _mapper.Map<IEnumerable<CharacterReadModel>>(user.Characters);
            if (user.SelectedCharacter != null)
            {
                CharacterReadModel selectedChar = models.FirstOrDefault(x => x.Id == user.SelectedCharacter.Id);
                selectedChar.IsActive = true;
            }

            return models;
        }

        [HttpGet("character/{id}/change")]
        public IActionResult ChangeCharacter(int id)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _userService.ChangeCurrentCharacter(Convert.ToInt32(userId),id);

                return Ok();
            }
            return BadRequest();
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
        [HttpGet("getenemies")]
        public IActionResult GetTargetUsers()
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                IEnumerable<User> targetUsers = _userService.GetUsers().Where(x => x.Id != Convert.ToInt32(userId));
                IEnumerable<EnemyUserReadModel> models = _mapper.Map<IEnumerable<EnemyUserReadModel>>(targetUsers);
                return Ok(models);
            }

            return BadRequest();
        }
        [HttpPost("FightCharacters")]
        public IActionResult FightCharacters([FromBody] FightCharacterCreateModel fightCharacterCreateModel)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                int userId = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                int AttackerCharId = fightCharacterCreateModel.AttackerCharId;
                int TargetUserId = fightCharacterCreateModel.TargetUserId;
                int TargetCharId = fightCharacterCreateModel.TargetCharId;
                var (attacker,target) = _attackSystemService.StartFight(userId, AttackerCharId, TargetUserId, TargetCharId);
                FightResultReadModel model = new FightResultReadModel
                {
                    attackerChar = _mapper.Map<CharacterReadModel>(attacker),
                    targetChar = _mapper.Map<CharacterReadModel>(target)
                };
                _notificationService.CreateNatificationForFight(userId, AttackerCharId, TargetUserId, TargetCharId, DateTime.Now.ToString("yyyy/MM/dd"));
                return Ok(model);
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

using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Repositories;
using FakeGladiatus.Application.Services.Interfaaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FakeGladiatus.Application.Services
{
    public class UserService : IUserService
    {
        public static Dictionary<int, User> ActiveUsers = new Dictionary<int, User>();
        private readonly IRepository<UserDbEntity> _repository;
        public UserService(IRepository<UserDbEntity> repository)
        {
            _repository = repository;
        }
        public User CheckForLogin(string userName, string password)
        {
            User u = new User();
            var existUser = _repository.GetAll().FirstOrDefault(x => x.UserName == userName && x.Password == password);
            u.NickName = existUser.NickName;
            u.Id = existUser.Id;
            return u;
        }
        public Character GenerateCharacter(int id, Character character)
        {
            var u = _repository.GetById(id);
            CharacterDbEntity characterDbEntity = new CharacterDbEntity
            {
                Id = character.Id,
                Power = character.Power,
                Intelligence = character.Intelligence,
                Hp = character.Hp,
                Defense = character.Defense,
                Agility = character.Agility,
                Name = character.Name,
                Level = 1,
                Exp = 0

            };
            ActiveUsers[id].Characters.Add(character);
            u.Characters ??= new List<CharacterDbEntity>();
            u.Characters.Add(characterDbEntity);
            _repository.Update(u);
            return character;
        }
        public IEnumerable<Character> GetCharacters(int userId)
        {
            UserDbEntity u = _repository.GetAll().Include(x => x.Characters).FirstOrDefault(x => x.Id == userId);

            foreach (var characterDb in u.Characters)
            {
                yield return new Character
                {
                    Agility = characterDb.Agility,
                    Defense = characterDb.Defense,
                    Hp = characterDb.Hp,
                    Id = characterDb.Id,
                    Intelligence = characterDb.Intelligence,
                    Name = characterDb.Name,
                    Power = characterDb.Power,
                    Level = characterDb.Level,
                    Exp = characterDb.Exp

                };
            }
        }
        public string GetNickName(int userId)
        {
            var u = GetUser(userId);
            if (ActiveUsers.ContainsKey(u.Id) == false)
            {
                ActiveUsers.Add(u.Id, u);
            }
            return u.NickName;
        }
        public User GetUser(int userId)
        {
            if (ActiveUsers.ContainsKey(userId) == true)
            {
                return ActiveUsers[userId];
            }
            UserDbEntity uDbEntity = _repository.GetAll().Include(x => x.Characters).FirstOrDefault(x => x.Id == userId);
            User u = new User
            {
                Id = uDbEntity.Id,
                NickName = uDbEntity.NickName,
                UserName = uDbEntity.UserName,
                Email = uDbEntity.Email,

            };
            u.Characters = uDbEntity.Characters.Select(x => new Character { Agility = x.Agility, Defense = x.Agility, Exp = x.Exp, Hp = x.Hp, Id = x.Id, Intelligence = x.Intelligence, Level = x.Level, Name = x.Name, Power = x.Power, User = u }).ToList();

            return u;
        }
        public void ChangeCurrentCharacter(int userId, int charId)
        {
            if (ActiveUsers.ContainsKey(userId) == false)
            {
                ActiveUsers.Add(userId, GetUser(userId));
            }
            var currentUser = ActiveUsers[userId];
            currentUser.SelectedCharacter = currentUser.Characters.FirstOrDefault(x=>x.Id == charId);
        }
    }
}

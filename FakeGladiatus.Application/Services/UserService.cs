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
                Name = character.Name

            };
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
                    Power = characterDb.Power
                };
            }
        }
    }
}

using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Services.Interfaaces
{
    public interface IUserService
    {
        public User CheckForLogin(string userName, string password);
        public Character GenerateCharacter(int id, Character character);
        public IEnumerable<Character> GetCharacters(int userId);
        public string GetNickName(int userId);
        public User GetUser(int userId);
    }
}

using FakeGladiatus.Application.Entities.DbEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities.DbEntities
{
    public class UserDbEntity : IDbEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<CharacterDbEntity> Characters { get; set; }
    }
}

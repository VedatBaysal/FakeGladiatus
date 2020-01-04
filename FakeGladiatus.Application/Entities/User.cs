using FakeGladiatus.Application.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Shared.Models.User
{
    public class UserLoginSuccess
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities
{
   public class Notification
    {
        public int Id { get; set; }
        public User AttackerUser { get; set; }
        public Character AttackerChar { get; set; }
        public User TargetUser { get; set; }
        public Character TargetChar { get; set; }
        public DateTime FightTime { get; set; }
        public bool IsRead { get; set; }

    }
}

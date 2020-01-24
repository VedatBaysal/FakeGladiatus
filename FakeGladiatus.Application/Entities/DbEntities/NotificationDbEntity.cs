using FakeGladiatus.Application.Entities.DbEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities.DbEntities
{
   public class NotificationDbEntity : IDbEntity
    {
        public int Id { get; set; }
        public UserDbEntity AttackerUser { get; set; }
        public CharacterDbEntity AttackerChar { get; set; }
        public UserDbEntity TargetUser { get; set; }
        public CharacterDbEntity TargetChar { get; set; }
        public DateTime FightTime { get; set; }
        public bool IsRead { get; set; }

    }
}

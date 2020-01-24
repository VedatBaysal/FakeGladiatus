using FakeGladiatus.Shared.Models.Character;
using FakeGladiatus.Shared.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Shared.Models.Notification
{
    public class NotificationReadModel
    {
        public int NotificationId { get; set; }
        public EnemyUserReadModel AttackerUser { get; set; }
        public CharacterReadModel AttackerChar { get; set; }
        public CharacterReadModel TargetChar { get; set; }
        public DateTime FightTime { get; set; }
    }
}

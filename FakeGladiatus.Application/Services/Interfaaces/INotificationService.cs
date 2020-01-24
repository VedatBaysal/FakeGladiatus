using FakeGladiatus.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Services.Interfaaces
{
    public interface INotificationService
    {
        public void CreateNatificationForFight(int AttackerUserId, int AttackerCharId, int TargetUserId, int TargetCharId, string fightTime);
        public IEnumerable<Notification> GetNotification(int userId);
    }
}

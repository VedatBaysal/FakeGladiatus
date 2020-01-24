using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Manager;
using FakeGladiatus.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Services.Interfaaces
{
    public interface IAttackSystemService
    {
        public (Character attacker, Character defender) StartFight(int userId, int selectedCharId, int targetUserId, int selectedTargetCharId);
    }
}

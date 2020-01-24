using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Manager;
using FakeGladiatus.Application.Repositories;
using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using FakeGladiatus.Application.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeGladiatus.Application.Services
{
    public class AttackSystemService : IAttackSystemService
    {
        private readonly IRepository<UserDbEntity> _userRepository;
        private readonly FightManager _fightManager;

        public AttackSystemService(IRepository<UserDbEntity> userRepository, FightManager fightManager)
        {
            _userRepository = userRepository;
            _fightManager = fightManager;
        }
        public (Character attacker, Character defender) StartFight(int userId, int selectedCharId, int targetUserId, int selectedTargetCharId)
        {
            UserDbEntity u = _userRepository.GetAll().Include(x => x.Characters).FirstOrDefault(x => x.Id == userId);
            CharacterDbEntity uc = u.Characters.FirstOrDefault(x => x.Id == selectedCharId);
            UserDbEntity tu = _userRepository.GetAll().Include(x => x.Characters).FirstOrDefault(x => x.Id == targetUserId);
            CharacterDbEntity tuc = tu.Characters.FirstOrDefault(x => x.Id == selectedTargetCharId);

            FightResult result = _fightManager.Fight(uc, tuc);


            _userRepository.Update(result.TargetChar.User);
            Character attackerChar = uc.Build();
            Character targetChar = tuc.Build();

            return (attackerChar, targetChar);

        }
    }
}

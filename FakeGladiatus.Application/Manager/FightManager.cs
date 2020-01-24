using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Manager
{
   public class FightManager
    {
        public FightResult Fight(CharacterDbEntity attackerChar, CharacterDbEntity targetChar)
        {
            int attackerCharDamage = attackerChar.Power;
            int targetCharHp = targetChar.Hp;
            int targetCharDefense = targetChar.Defense;
            targetChar.Hp = targetCharHp - Math.Max(0,attackerCharDamage - targetCharDefense);
            return new FightResult(attackerChar, targetChar);
            
        }
    }
}

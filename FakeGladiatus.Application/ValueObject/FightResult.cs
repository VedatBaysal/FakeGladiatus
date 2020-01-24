using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.ValueObject
{
    public class FightResult
    {
        public CharacterDbEntity AttackerChar { get; set; }

        public CharacterDbEntity TargetChar { get; set; }
        public FightResult(CharacterDbEntity attackerChar, CharacterDbEntity targetChar)
        {
            AttackerChar = attackerChar;
            TargetChar = targetChar;
        }
    }
}

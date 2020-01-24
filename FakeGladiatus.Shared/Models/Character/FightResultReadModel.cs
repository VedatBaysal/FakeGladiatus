using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Shared.Models.Character
{
    public class FightResultReadModel
    {
        public CharacterReadModel attackerChar { get; set; }
        public CharacterReadModel targetChar { get; set; }
    }
}

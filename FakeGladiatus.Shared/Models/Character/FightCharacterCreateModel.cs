using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Shared.Models.Character
{
    public class FightCharacterCreateModel
    {
        public int AttackerCharId { get; set; }
        public int TargetUserId { get; set; }

        public int TargetCharId { get; set; }
    }
}

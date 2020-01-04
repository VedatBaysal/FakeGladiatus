using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Shared.Models.Character
{
    public class CharacterGenerateModel
    {
        public string UserId { get; set; }
        public string Name { get; set; } 
        public string Hp { get; set; }
        public string Power { get; set; }
        public string Defence { get; set; }
        public string Agility { get; set; }

        public string Intelligence { get; set; }
    }
}

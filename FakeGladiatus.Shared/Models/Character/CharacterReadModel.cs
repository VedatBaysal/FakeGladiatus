using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Shared.Models.Character
{
    public class CharacterReadModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; } 
        public int Power { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Intelligence { get; set; } 
        public bool IsActive { get; set; }

    }
}

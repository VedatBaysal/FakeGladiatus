using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public int CharacterGainExp(int monsterExp)
        {
            Exp += monsterExp;
            return Exp;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FakeGladiatus.Application.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; } = "Musti";
        public int Hp { get; set; } = 100;
        public int Power { get; set; } = 5;
        public int Defense { get; set; } = 0;
        public int Agility { get; set; } = 0;

        public int Intelligence { get; set; } = 0;


    }
}

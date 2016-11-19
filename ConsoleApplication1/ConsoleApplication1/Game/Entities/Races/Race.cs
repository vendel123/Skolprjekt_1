using ConsoleApplication1.Game.Entities.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Game.Entities.Races {
    public class Race {
        public Race() {
            this.Spells = new List<Spell>();
        }
        public Race(string name) : this() {
            this.Name = name;
        }
        public Race(string name, int energy, int health, int attack, List<Spell> spells) : this(name) {
            this.Energy = energy;
            this.Health = health;
            this.Attack = attack;
            this.Spells = spells.ToList();
        }
        //public Race(string name, int energy, int health, params int[] spellCooldowns) : this(name) {
        //    this.Energy = energy;
        //   this.Health = health;
        //    this.SpellCooldowns = spellCooldowns.ToList();
        //}
        public string Name {
            get;
            set;
        }
        public int Energy {
            get;
            set;
        }
        public int Health {
            get;
            set;
        }
        public int Attack {
            get;
            set;
        }
        public List<Spell> Spells {
            get;
            set;
        }

    }
}

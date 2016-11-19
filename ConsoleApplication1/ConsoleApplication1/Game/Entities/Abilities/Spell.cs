using ConsoleApplication1.Game.Entities.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Game.Entities.Abilities {

    public enum SpellTrigger {
        Casted,
        PasiveOnAttacked,
        PassiveOnAttacking,
        PassiveRoundStart
    }
    public class Spell {
        public string Description {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }
        public int Cooldown {
            get;
            set;
        }
        public int EnergyCost {
            get;
            set;
        }
        public SpellTrigger TriggerType { get; set; }
        public Action<Race, Race, int> Action { get; set; }

        public override string ToString() {
            if (EnergyCost >= 0) {
                if(Cooldown >= 0) {
                    return $"{Name}: {Description}";
                }

                return $"{Name}: {Description} [{Cooldown}]";
            }
            else {
                if (Cooldown >= 0) {
                    return $"{Name}: {Description} (Costs {EnergyCost} Energy)";
                }
                return $"{Name}: {Description} (Costs {EnergyCost} Energy) [{Cooldown}]";
            }


    }
    }
    
}

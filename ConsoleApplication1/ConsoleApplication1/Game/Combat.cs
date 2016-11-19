using ConsoleApplication1.Game.Entities.Races;
using ConsoleApplication1.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Game {
    public class Combat : IState {
        public Combat() { }
        public Combat(Race race) {
            this.race = race;
        }
        private VConsole console;
        private Race race;

        public void Draw() {
   
        }

        public void Setup() {
            console = new VConsole();
        }

        public void Update() {
       
        }
    }
}

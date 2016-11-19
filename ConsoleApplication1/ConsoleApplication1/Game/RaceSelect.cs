using ConsoleApplication1.Game.Entities.Abilities;
using ConsoleApplication1.Game.Entities.Races;
using ConsoleApplication1.Utility;
using ConsoleApplication6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Game {
    public class RaceSelect : IState {
        private List<Race> races;
        private VConsole console;
        public void Setup() {

            console = new VConsole();
            var ork = new Race();
            ork.Name = "Ork";
            ork.Health = 250;
            ork.Energy = 100;
            ork.Attack = 60;

            ork.Spells.Add(new Spell() {
                Name = "Slam",
                Description = "deal your Attack damage + a random number betwen 30 and 60",
                Cooldown = 2,
                EnergyCost = 20,
                TriggerType= SpellTrigger.Casted,
                Action = (Race caster, Race target, int cost) => {
                    if (caster.Energy >= cost) {
                        caster.Energy -= cost;
                        target.Health -= caster.Attack + (new Random().Next(30) + 30);
                    }
                }              
            });
            ork.Spells.Add(new Spell() { Name = "Feel no pain", Description = "heal yourself for 80 HP", Cooldown = 1, EnergyCost = 50 });
            ork.Spells.Add(new Spell() { Name = "Freash meat", Description = "Deal 30-50 damage and heal for the same amount ", Cooldown = 2, EnergyCost = 40 });


            //Elf stats stored as ints

            var elf = new Race();
            elf.Name = "Elf";
            elf.Health = 170;
            elf.Energy = 200;
            elf.Attack = 40;

            ork.Spells.Add(new Spell() { Name = "Blessing of light", Description = "Heal yourself for 10 health each turn", Cooldown = 0, EnergyCost = 0 });
            ork.Spells.Add(new Spell() { Name = "Blessing of might", Description = "gain 20 permanent attack damage ", Cooldown = 4, EnergyCost = 50 });
            ork.Spells.Add(new Spell() { Name = "Heal", Description = " Restore 80 Health ", Cooldown = 2, EnergyCost = 50 });




            //Undead stats stored as ints
            var undead = new Race();
            undead.Name = "Undead";
            undead.Health = 150;
            undead.Energy = 150;
            undead.Attack = 40;

            undead.Spells.Add(new Spell() { Name = "Curse", Description = "Deal 80 damage to your oponent and 20 to yourself", Cooldown = 1, EnergyCost = 60 });
            undead.Spells.Add(new Spell() { Name = "Pleague", Description = "deal 30 damage to yourself and gain 100 energy ", Cooldown = 0, EnergyCost = 0 });
            undead.Spells.Add(new Spell() { Name = "Drain", Description = "Deal your attack damage and heal yourself for the amount of damage dealt", Cooldown = 2, EnergyCost = 50 });


            races = new List<Race>() { ork, elf, undead };



          
        }

        public void Update() {
            var input = console.ReadLine().ToUpper();
            var choice = races.FirstOrDefault(n => n.Name.ToUpper() == input);
            if (choice == null) {
                if (input == "INFO") {
                    console.WriteLine("Burklax", ConsoleColor.Yellow, ConsoleColor.DarkRed);
                } else {
                    Environment.Exit(0);
                }
            } else {
                console.Clear(); //Clears the screen
                console.WriteLine(choice.Name, ConsoleColor.DarkGreen);
                console.WriteLine($@"Stats: 
Hp: {choice.Health}
Attack: {choice.Attack}
Energy: {choice.Energy}

Spells:");
                foreach (var spell in choice.Spells)
                    console.WriteLine(spell.ToString());


                console.Render();//future proof for off screen buffering
                console.ReadKey();
                console.Clear();
                Program.GameState = new Combat(choice);
                Program.GameState.Setup();
            }

        }

        public void Draw() {
            console.WriteLine($@"You have been choosen to enter Hallow's arena.
In here you and another hero will fight to the death.
You may take controll over an avatar for the battle.
your oponent has choosen a Human Paladain using devine magic to smite down his foes.
you may take controll of one of three avatars.");

            console.WriteLine("you may coose a wood Elf Priest specialiced in self sustain and buffs", ConsoleColor.Blue);
            console.WriteLine("Or you could choose a mighty Ork Warrior witch powerfull attacks and a high healthpool", ConsoleColor.DarkGreen);
            console.WriteLine("Or you could even choose a mighty Undead Warlock who unleashes powerfull spells but at a high cost", ConsoleColor.DarkCyan);



            console.WriteLine("Do you choose the Ork, the Elf or the Undead. For more info type Info"); //intro end
            console.Render();//future proof for off screen buffering

        }

 



    }
    
}

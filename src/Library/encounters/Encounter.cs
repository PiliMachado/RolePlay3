using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Encounter: IEncounter
    {
        private List<Character> villians { get; set; }
        private List<Character> heroes { get; set; }

        public Encounter(List<Character> players)
        {
            this.villians = new List<Character>(players.FindAll(c => c is IEnemy));
            this.heroes = new List<Character>(players.FindAll(c => c is IHero));
        }


        public void RemoveDeadCharacters()
        {
            foreach(Character character in new List<Character>(this.heroes))
                if(character.Health <= 0) this.heroes.Remove(character);
            
            foreach(Character character in new List<Character>(this.villians))
                if(character.Health <= 0) this.villians.Remove(character);
        }
        public void DoEncounter()
        {
            if(villians.Count <= 0 || heroes.Count <= 0)
            {
                Console.WriteLine("Missing characters to start encounter.");
                return;
            }
            while(villians.Count > 0 && heroes.Count > 0) // No sale del loop hasta que al menos uno de los dos lados quede vacio.
            {
                this.RemoveDeadCharacters();
                int index = 0;
                foreach(Character villian in this.villians) // Recorremos la lista de villanos.
                {
                    Character heroe = this.heroes[index];
                    heroe.ReceiveAttack(villian.AttackValue);
                    index++;
                    if(index >= this.heroes.Count) index = 0;
                }

                this.RemoveDeadCharacters();

                foreach(Character hero in this.heroes)
                {
                    foreach(Character villain in this.villians) // Los heroes atacan a todos los enemigos una vez.
                    {
                        villain.ReceiveAttack(hero.AttackValue);
                        if(villain.Health <= 0) hero.VictoryPoints += villain.VictoryPoints;
                        
                    }
                    if(hero.VictoryPoints >= 5 && hero.Health > 0) // Si los VP son mayores o iguales a 5 entonces el heroe se cura.
                    {
                        hero.Cure();
                    }
                }
            }
            
            if(this.heroes.Count > 0) // Dependiendo de que lista ya no tenga mas characters se declarara vencedor a los heroes o villanos.
            {
                Console.WriteLine("The heroes won!");
            }
            else
            {
                Console.WriteLine("The villians won!");
            }
        
        }
    }
}
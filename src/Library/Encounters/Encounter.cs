using System;
using System.Collections.Generic;

namespace RoleplayGame
{
    public class Encounter: IEncounter
    {
        public List<Character> Villians { get; private set; } = new List<Character>();
        public List<Character> Heroes { get; private set; } = new List<Character>();

        public Encounter(List<Character> players)
        {
            this.Villians = new List<Character>(players.FindAll(c => c is IEnemy));
            this.Heroes = new List<Character>(players.FindAll(c => c is IHero));
        }


        public void RemoveDeadCharacters()
        {
            foreach(Character character in new List<Character>(this.Heroes))
                if(character.Health <= 0) this.Heroes.Remove(character);
            
            foreach(Character character in new List<Character>(this.Villians))
                if(character.Health <= 0) this.Villians.Remove(character);
        }
        public void DoEncounter()
        {
            if(Villians.Count <= 0 || Heroes.Count <= 0)
            {
                Console.WriteLine("Missing characters to start encounter.");
                return;
            }
            while(Villians.Count > 0 && Heroes.Count > 0) // No sale del loop hasta que al menos uno de los dos lados quede vacio.
            {
                this.RemoveDeadCharacters();
                int index = 0;
                if(Villians.Count <= Heroes.Count)
                {
                    foreach(Character villian in this.Villians) // Recorremos la lista de villanos.
                    {
                        Character heroe = this.Heroes[index];
                        heroe.ReceiveAttack(villian.AttackValue);
                        index++;    
                        if(index >= this.Heroes.Count) index = 0;
                    }
                }
                else
                {
                    int counter = 0;
                    foreach(Character villian in this.Villians) // Recorremos la lista de villanos.
                    {
                        Character heroe = this.Heroes[index];
                        heroe.ReceiveAttack(villian.AttackValue);
                        if(counter == 1)
                        {
                            index++;
                            counter = 0;
                        }
                        else
                        {
                            counter += 1;
                        }
                        
                        if(index >= this.Heroes.Count) index = 0;
                    }
                }

                this.RemoveDeadCharacters();

                foreach(Character hero in this.Heroes)
                {
                    foreach(Character villain in this.Villians) // Los heroes atacan a todos los enemigos una vez.
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
            
            if(this.Heroes.Count > 0) // Dependiendo de que lista ya no tenga mas characters se declarara vencedor a los heroes o villanos.
            {
                Console.WriteLine("The heroes won!");
            }
            else
            {
                Console.WriteLine("The villains won!");
            }
        
        }
    }
}
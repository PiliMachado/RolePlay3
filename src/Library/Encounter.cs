using System;
using System.Collections.Generic;
namespace RoleplayGame
{
    public class Encounter
    {
        private List<Character> villians { get; set; } = new List<Character>();
        private List<Character> heroes { get; set; } = new List<Character>();
        public bool done { get; set; }
        public Encounter(List<Character> players)
        {
            foreach(Character character in players)
            {
                if(character is IEnemy)
                {
                    this.villians.Add(character);
                }
                else
                {
                    this.heroes.Add(character);
                }
            }
        }
        public void RemoveDeadCharacters()
        {
            List<Character> aliveheroes = new List<Character>();
            List<Character> aliveenemies = new List<Character>();
            foreach(Character character in this.heroes)
            {
                if((character.Health > 0))
                {
                    aliveheroes.Add(character);
                }
            }
            foreach(Character character in this.villians)
            {
                if((character.Health > 0))
                {
                    aliveenemies.Add(character);
                }
            }
            this.heroes = aliveheroes;
            this.villians = aliveenemies;
        }
        public void DoEncounter()
        {
            if(villians.Count > 0 && heroes.Count > 0)
            {
                while(villians.Count > 0 && heroes.Count > 0) // No sale del loop hasta que al menos uno de los dos lados quede vacio.
                {
                    this.RemoveDeadCharacters();
                    int order = this.heroes.Count;
                    int counter = 0;
                    foreach(Character villian in this.villians) // Recorremos la lista de villanos.
                    {
                        if(this.heroes.Count >= this.villians.Count)
                        {
                            if(order > 0) // Verificamos atacar en el orden previsto.
                            {
                                heroes[heroes.Count - order].ReceiveAttack(villian.AttackValue);
                                Console.WriteLine($"{heroes[heroes.Count - order].Name} was attacked");
                                order -= 1;
                            }
                            else if(order == 0) // Para evitar errores de fuera de index.
                            {
                                heroes[0].ReceiveAttack(villian.AttackValue);
                                Console.WriteLine($"{heroes[0].Name} was attacked");
                                order = heroes.Count;
                            }
                        }
                        else
                        {
                            if(order > 0) // Verificamos atacar en el orden previsto.
                            {
                                heroes[heroes.Count - order].ReceiveAttack(villian.AttackValue);
                                Console.WriteLine($"{heroes[heroes.Count - order].Name} was attacked");
                                if(counter == 1)
                                {
                                    order -= 1;
                                    counter = 0;
                                }
                                else
                                {
                                    counter += 1;
                                }
                            }
                            else if(order == 0) // Para evitar errores de fuera de index.
                            {
                                heroes[0].ReceiveAttack(villian.AttackValue);
                                Console.WriteLine($"{heroes[0].Name} was attacked");
                                order = heroes.Count;
                            }
                        }
                    }

                    this.RemoveDeadCharacters();
                    foreach(Character hero in this.heroes)
                    {
                        for(order = 0; order < this.villians.Count; order++) // Los heroes atacan a todos los enemigos una vez.
                        {
                            this.villians[order].ReceiveAttack(hero.AttackValue);
                            if(this.villians[order].Health <= 0)
                            {
                                hero.VictoryPoints += this.villians[order].VictoryPoints;
                            }
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
                    this.done = true;
                }
                else
                {
                    Console.WriteLine("The villians won!");
                    this.done = true;
                }
            }
            else
            {
                Console.WriteLine("Missing characters to start encounter.");
                this.done = false;
            }
        }
    }
}
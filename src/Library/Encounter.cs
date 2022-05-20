using System;
using System.Collections.Generic;
namespace RoleplayGame
{
    public class Encounter
    {
        private List<Character> villians { get; set; }
        private List<Character> heroes { get; set; }
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
            foreach(Character character in this.heroes)
            {
                if(!(character.Health > 0))
                {
                    this.heroes.Remove(character);
                }
            }
            foreach(Character character in this.villians)
            {
                if(!(character.Health > 0))
                {
                    this.villians.Remove(character);
                }
            }
        }
        public void DoEncounter()
        {
            if(villians.Count > 0 && heroes.Count > 0)
            {
                while(villians.Count > 0 && heroes.Count > 0) // No sale del loop hasta que al menos uno de los dos lados quede vacio.
                {
                    this.RemoveDeadCharacters();
                    int order = this.heroes.Count;
                    foreach(Character villian in this.villians) // Recorremos la lista de villanos.
                    {
                        if(order > 0) // Verificamos atacar en el orden previsto.
                        {
                            heroes[heroes.Count - order].ReceiveAttack(villian.AttackValue);
                            order -= 1;
                        }
                        else if(order == 0) // Para evitar errores de fuera de index.
                        {
                            heroes[heroes.Count].ReceiveAttack(villian.AttackValue);
                            order -= 1;
                        }
                        else // Cuando ya se halla pasado por toda la lista, si siguen habiendo villanos se atacara devuelta a los primeros en orden.
                        {
                            order = heroes.Count;
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
                }
                else
                {
                    Console.WriteLine("The villians won!");
                }
            }
            else
            {
                Console.WriteLine("Missing characters to start encounter.");
            }
        }
    }
}
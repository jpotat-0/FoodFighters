using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFighters
{
    class Fighter
    {
        public string name;
        public int health;
        public int strength;
        public int defense;
        public int doubleTurn;
        public bool defended;
        public bool full;
        public Fighter(string a, string b, string c)
        {
            name = a + " " + b + " " + c;
            Random rnd = new Random();
            health = rnd.Next(10, 24);
            strength = rnd.Next(1, 10);
            defense = rnd.Next(1, 8);
            doubleTurn = 0;
            defended = false;
            full = false;
        }

        public void EnemyTurn(Fighter y)
        {
            Random rnd = new Random();
            int choice = rnd.Next(1, 2);
            int damage;
            if (choice == 1)
            {
                if (defended)
                {
                    damage = y.strength - (defense * 2);
                    if (damage >= 0)
                    {
                        health -= damage;
                        defended = false;
                        Console.WriteLine("You were hit for " + damage + " damage. You have " + health + " HP left.");
                    }
                    else
                    {
                        health -= damage;
                        defended = false;
                        Console.WriteLine("You were hit for " + damage + " damage. You have " + health + " HP left.");
                    }
                }
                else
                {
                    damage = y.strength - defense;
                    if (damage >= 0)
                    { 
                        health -= damage;
                        Console.WriteLine("You were hit for " + damage + " damage. You have " + health + " HP left.");
                    }
                    
                }
            }
            else
            {
                y.defended = true;
                Console.WriteLine("The enemy readied their guard. They have 2x defense.");
            }
        }
        public bool Battle(Sandwich x, Fighter y)
        {
            
            bool enemySlain = false;
            while (!enemySlain)
            {
                if (this.health <= 0)
                {
                    return true;
                }
                Console.WriteLine("Your turn. Choose an action.\n1) Attack\n2) Defend\n3) Eat\n4) Surrender");
                bool isNumber = int.TryParse(Console.ReadLine(), out int decision);


                if (decision == 1)
                {
                    for (int i = 0; i <= doubleTurn; i++)
                    {
                        int damage;
                        if (y.defended)
                        {
                            damage = strength - (y.defense * 2);
                            if (damage >= 0)
                            {
                                y.health -= damage;
                                defended = false;
                                Console.WriteLine("You attacked the enemy for " + damage + " damage. They have " + y.health + " HP left.");
                                doubleTurn = 0;
                            } 
                            else
                            {
                                defended = false;
                                Console.WriteLine("You attacked the enemy for " + damage + " damage. They have " + y.health + " HP left.");
                                doubleTurn = 0;
                            }

                        }
                        else
                        {
                            damage = strength - y.defense;
                            if (damage >= 0)
                            {
                                y.health -= damage;
                                Console.WriteLine("You attacked the enemy for " + damage + " damage. They have " + y.health + " HP left.");
                                doubleTurn = 0;
                            } 
                            else
                            {
                                Console.WriteLine("You attacked the enemy for " + damage + " damage. They have " + y.health + " HP left.");
                                doubleTurn = 0;
                            }
                            
                        }
                    
                        if (y.health <= 0)
                        {
                            Console.WriteLine("You have knocked out the enemy! Congratulations!");
                            doubleTurn = 0;
                            return false;
                        }
                    }
                }
                else if (decision == 2)
                {
                    Console.WriteLine("You bolster your defenses. 2x defense until your next turn.");
                   defended = true;
                }
                else if (decision == 3 && !full)
                {
                    x.Consume(this);
                    
                    this.full = true;
                }
                else if (decision == 3 && full)
                {
                    Console.WriteLine("You are too full to eat!");
                }
                else if (decision == 4)
                {
                    return true;
                }
                else if (!isNumber)
                {
                    Console.WriteLine("You goof around and don't do anything.");
                }
                this.EnemyTurn(y);
            } 


            if (enemySlain)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

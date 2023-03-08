using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFighters
{
    class Sandwich
    {
        public string bread;
        public string[] filling;

        public Sandwich(string aBread, string[] aFilling)
        { 
            bread = aBread;
            filling = aFilling;
        }

        public void Consume(Fighter x)
        {
            int healing;
            if (x.health + 12 > 35)
            { 
                healing = 12;
            } 
            else
            {
                healing = 35 - x.health;
            }

            x.health += healing;
            Console.WriteLine("The sandwich restores your energy. You have healed " + healing + " health.");

            for (int i = 0; i <= 2; i++)
            {
                if (this.filling[i] == "meat")
                {
                    x.strength += 5;
                    Console.WriteLine("The meat fills you with strength. Gain 5 strength for the rest of the fight.");
                }
                else if (this.filling[i] == "cheese")
                {
                    x.defense += 5;
                    Console.WriteLine("The cheese bolsters your bones. Gain 5 defense for the rest of the fight.");
                }
                else if (this.filling[i] == "veggies")
                {
                    x.health += 5;
                    Console.WriteLine("The vegetables feel healthy. Gain 5 health for the rest of the fight.");
                }
                else if (this.filling[i] == "peanut butter")
                {
                    Console.WriteLine("THE PB&J FILLS YOU WITH IMMENSE ENERGY!!! YOU MAY ATTACK TWICE DURING YOUR NEXT ATTACK!!!");
                    x.doubleTurn = 1;
                } 
            }
        }
    }
}

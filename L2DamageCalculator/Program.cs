using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2DamageCalculator
{
    class Program
    {

        static double InputString(string text)
        {
            while (true)
            {
                Console.WriteLine(text);
                string inputString = Console.ReadLine();
                double firstNumber;
                try
                {
                    firstNumber = double.Parse(inputString);

                    if(firstNumber<= 2147483648)
                    return firstNumber;
                    else
                        Console.WriteLine("So big mage attack, fkn moder");
                }
                catch (Exception)
                {
                    Console.WriteLine("incorrect input");                    
                }
            }

        }//урон = 91 * "мощность скила" * sqrt (м.атк) / м.деф

        static void DamageCalc(double mAttack,double mDefence,double attMod,double ssMod,double skillPower)
        {
            double result = 91 * skillPower * Math.Sqrt(mAttack * ssMod) / mDefence * attMod;
            Console.WriteLine(new string('_',30));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pure mage damage: {0}",(int)result);
            Console.WriteLine("Blunt damage damage {0} - {1}", (int)result*0.8,(int)result*1.2);
            Console.WriteLine("Sword damage damage {0} - {1}", (int)result * 0.9, (int)result * 1.1);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        static double AttributeMod(double attAttack,double attDefence)
        {
            double mod = ((attAttack-attDefence)+1000)/1000;

            if(mod>=1.25)
            {
                return 1.25;
            }
            else if(mod<=0.75)
            {
                return 0.75;
            }
           return mod;
        }
        static double SpititShotMode()
        {
            double ssMode = 1;
            do
            {
                Console.WriteLine("Enter Spiritshot Mode\nnoSS - Without Spiritshot\nSS - With Spiritshot\nBSS - With Blessed Spiritshot");
                string value = Console.ReadLine().ToLower();


                switch (value)
                {
                    case "noss":
                        ssMode = 1;
                        return ssMode;
                    case "ss":
                        ssMode = 2;
                        return ssMode;
                    case "bss":
                        ssMode = 4;
                        return ssMode;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Incorrect SS Mode");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //ssMode = 0;
                        continue;
                }
            } while (ssMode != 1||ssMode!=2||ssMode!=4) ;
            return ssMode;
            
        }

        static void Main(string[] args)
        {

            double mAttack = InputString("Enter Mage Attack");
            double mDefence = InputString("Enter Mage Defence");
            double skillPower = InputString("Enter Skill Power");
            double attAttack = InputString("Enter Attribute Attack");
            double attDefence = InputString("Enter Attribute defence");

            DamageCalc(mAttack, mDefence, AttributeMod(attAttack, attDefence), SpititShotMode(), skillPower);



            Console.ReadKey();


        }
    }
}

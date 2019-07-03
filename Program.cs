using MinimalisticTelnet;
using System;

namespace TelnetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TelnetConnection tc = new TelnetConnection("", 0);
            Game game = new Game();

            string buffer = "";
            string output = "";
            Console.WriteLine("Case Name");

            while(tc.IsConnected)
            {
                output = "";

                buffer = tc.Read();
                Console.Write(buffer);
                

                switch (game.CurrentSystemState)
                {
                    case Game.SystemState.NAME:
                        
                        output = game.CheckForName(buffer);
                        if (output != "")
                        {
                            game.CurrentSystemState = Game.SystemState.PASS;
                            Console.WriteLine("State Pass");
                        }
                        break;
                    case Game.SystemState.PASS:
                        output = game.CheckForPass(buffer);
                        if (output != "")
                        {
                            game.CurrentSystemState = Game.SystemState.NEUTRAL;
                            Console.WriteLine("Case Neutral");
                        }
                        break;
                    case Game.SystemState.NEUTRAL:
                        
                        break;
                    case Game.SystemState.EXPLORE:
                        Console.WriteLine("Case Explore");
                        break;
                    case Game.SystemState.COMBAT:
                        Console.WriteLine("Case Combat");
                        break;
                    case Game.SystemState.SHOPPING:
                        Console.WriteLine("Case Shopping");
                        break;
                }

                
                if(output != "")
                {
                    tc.WriteLine(output);
                }
                
                
            }
        }



    }
}

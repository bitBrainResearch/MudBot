using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TelnetTest
{

    
    class Game
    {
        public SystemState CurrentSystemState;

        public string name = "";
        public string password = "";

        public Game()
        {
            CurrentSystemState = SystemState.NAME;
        }

        public string CheckForName(string input)
        {
            Regex nameRegex = new Regex(@"Name:");
            
            Match matchName = nameRegex.Match(input);
            
            if (matchName.Success)
            {
                return name;
            } else
            {
                return "";
            }
        }

        public string CheckForPass(string input)
        {
            Regex passRegex = new Regex(@"Password:");
            Match matchPass = passRegex.Match(input);

            if (matchPass.Success)
            {
                return password;
            }
            else
            {
                return "";
            }
        }

        public bool HandleCharacterCreation()
        {

            return false;
        }

        public enum SystemState
        {
            NAME,
            PASS,
            NEUTRAL,
            COMBAT,
            EXPLORE,
            SHOPPING
        }
    }
}

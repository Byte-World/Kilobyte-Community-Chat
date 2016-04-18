using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theThreeElementsGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }



        public class specialAbility
        {
            int ID;
            int abilityDescription;

            public specialAbility()
            {

            }
        }

        public class character
        {
            string characterName;
            string characterImagePath;
            int startingHealth;
            int currentHealth;
            int dmgPerAttack;
            int specialAbilityID;
            Boolean characterAlive;

            public character()
            {
                characterAlive = true;
            }

            public character(string characterNameParam, string characterImagePathParam, int startingHealthParam, int dmgPerAttackParam, int specialAbilityIDParam)
            {
                characterName = characterNameParam;
                characterImagePath = characterNameParam;
                startingHealth = startingHealthParam;
                currentHealth = startingHealthParam;
                dmgPerAttack = dmgPerAttackParam;
                specialAbilityID = specialAbilityIDParam;
                characterAlive = true;
            }

            public void subtractHealth(int healthToSubtract)
            {
                if (healthToSubtract > currentHealth)
                {
                    currentHealth = 0;
                    characterAlive = false;
                }
                else
                {
                    currentHealth = currentHealth - healthToSubtract;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Bruteforce
{
    class Program
    {
        #region Private variables

        private static string password = File.ReadAllText(@"pass.txt");  
        private static string result;

        private static bool isMatched = false;

        private static int charactersToTestLength = 0;
        private static long computedKeys = 0;

        private static char[] charactersToTest =
        {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z','A','B','C','D','E',
        'F','G','H','I','J','K','L','M','N','O','P','Q','R',
        'S','T','U','V','W','X','Y','Z','1','2','3','4','5',
        '6','7','8','9','0','!','$','#','@','-'
    };

        #endregion

        static void Main(string[] args)
        {
            Console.Title = "@BruteForce";
            Console.ForegroundColor = ConsoleColor.Red;
            string title = @"
          ____             _       ______                 
    ____ |  _ \           | |     |  ____|                
   / __ \| |_) |_ __ _   _| |_ ___| |__ ___  _ __ ___ ___ 
  / / _` |  _ <| '__| | | | __/ _ \  __/ _ \| '__/ __/ _ \
 | | (_| | |_) | |  | |_| | ||  __/ | | (_) | | | (_|  __/
  \ \__,_|____/|_|   \__,_|\__\___|_|  \___/|_|  \___\___|
   \____/                                                 
                                                          ";

            Console.WriteLine(title);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ce programme a été codée par Niaso");
            Console.WriteLine("C'est une démonstration d'attaque BruteForce");
            Console.WriteLine("Veuillez l'utiliser a des fins légals");
            Console.WriteLine("");
            Console.WriteLine("Le mot de passe a cracker doit se trouver dans le fichier pass.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            var timeStarted = DateTime.Now;
            Console.WriteLine(">_ Entrez un mot de passe et le programme va essayer de le cracker automatiquement");
            Console.WriteLine("");
            Console.WriteLine(">_ Ce programme a été crée a but éducatif et démonstartif pour démontrer une attaque BrutForce");
            Console.WriteLine("");
            Console.WriteLine("Démarrage de l'attaque BruteForce - {0}", timeStarted.ToString());
            Console.WriteLine("");
            Console.WriteLine("Attaque en cours, Veuillez patienter ...");

            charactersToTestLength = charactersToTest.Length;

            var estimatedPasswordLength = 0;

            while (!isMatched)
            {
                estimatedPasswordLength++;
                startBruteForce(estimatedPasswordLength);
            }
            Console.Clear();
            Console.WriteLine("Attaque terminée ! :");
            Console.WriteLine("");
            Console.WriteLine("Mot de passe résolue à - {0}", DateTime.Now.ToString());
            Console.WriteLine("");
            Console.WriteLine("Temps passée: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
            Console.WriteLine("");
            Console.WriteLine("Tentatives: {0}", computedKeys);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Mot de passe: {0} ", result);
            Console.ForegroundColor = ConsoleColor.Red;

            Console.ReadLine();
        }

        #region Private methods

       
        private static void startBruteForce(int keyLength)
        {
            var keyChars = createCharArray(keyLength, charactersToTest[0]);
            var indexOfLastChar = keyLength - 1;
            createNewKey(0, keyChars, keyLength, indexOfLastChar);
        }

        private static char[] createCharArray(int length, char defaultChar)
        {
            return (from c in new char[length] select defaultChar).ToArray();
        }

        private static void createNewKey(int currentCharPosition, char[] keyChars, int keyLength, int indexOfLastChar)
        {
            var nextCharPosition = currentCharPosition + 1;
            for (int i = 0; i < charactersToTestLength; i++)
                keyChars[currentCharPosition] = charactersToTest[i];

                if (currentCharPosition < indexOfLastChar)
                {
                    createNewKey(nextCharPosition, keyChars, keyLength, indexOfLastChar);
                }
                else
                {
                    computedKeys++;

                    if ((new String(keyChars)) == password)
                    {
                        if (!isMatched)
                        {
                            isMatched = true;
                            result = new String(keyChars);
                        }
                        return;
                    }
                }
            }
        }

        #endregion
    }
}

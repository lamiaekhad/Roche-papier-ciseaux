
using System;
using System.IO;
using System.Linq;


namespace ProjetNumber5
{
    class Program
    {
        string userchoice;
        string ordchoice;
        Random random = new Random();
        bool rejoue = true;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Program program = new Program();
            program.selectChoice();

        }
        private void showMenu()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Veuillez choisir le jeu à jouer:");
            Console.WriteLine("1- Roche/papier/ciseau    2- La devinette    3- Quitter ");
            Console.WriteLine("-----------------------------------------------------------");
        }
        private void validateChoice()
        {
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    playerchoice();
                    break;

                case "2":

                    break;

                case "3":
                    quitter();
                    break;

                default:
                    choixNV();
                    break;
            }

        }
        private void choixNV()
        {
            Console.WriteLine("Veuillez effectuer un choix valide: ");
            Console.WriteLine();
        }
        private void selectChoice()
        {
            int option = 0;
            do
            {
                showMenu();
                validateChoice();

            } while (option > 3 || option < 1);
        }
        private void quitter()
        {
            Console.WriteLine("Press any key to close this window...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void accueilJ1()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Bienvenue dans le jeu roche/papier/ciseau");
            Console.WriteLine("-----------------------------------------------------------");

        }

        private void playerchoice()
        {
            accueilJ1();
            Console.WriteLine("J'ai déja choisis mon élément! A votre tour de choisir l'élément: ");
            userchoice = Console.ReadLine();

              if (userchoice == "roche" || userchoice == "papier" || userchoice == "ciseau" )
              {
                Choixauto();
                rejouer();
              }

              else
              {
                Console.WriteLine("Votre choix est invalide, veuillez le saisir a nouveau:");
                userchoice = Console.ReadLine();

                if (userchoice == "roche" || userchoice == "papier" || userchoice == "ciseau")
                {
                    Choixauto();
                    rejouer();
                }
              }
              return;
            
        }

        private void playerchoice2()
        {
            
            Console.WriteLine("J'ai déja choisis mon élément! A votre tour de choisir l'élément: ");
            userchoice = Console.ReadLine();

            if (userchoice == "roche" || userchoice == "papier" || userchoice == "ciseau")
            {
                Choixauto();
                rejouer();
            }

            else
            {
                Console.WriteLine("Votre choix est invalide, veuillez le saisir a nouveau:");
                userchoice = Console.ReadLine();

                if (userchoice == "roche" || userchoice == "papier" || userchoice == "ciseau")
                {
                    Choixauto();
                    rejouer();
                }
            }
            return;

        }


        private void Choixauto()
        {
            switch (random.Next(1, 4))
            {
                case 1:
                    roche();
                    break;

                case 2:
                    papier();
                    break;

                case 3:
                    ciseau();
                    break;
            }
        }

        private void Pnull()
        {
            Console.WriteLine("Partie nulle! Nous avons choisis le même élément!");
            Console.WriteLine();
        }

        private void gagne()
        {
            Console.WriteLine("votre choix est " + userchoice + " et mon choix est " + ordchoice + ". Vous gagnez la partie!");
            Console.WriteLine();

        }

        private void perdu()
        {
            Console.WriteLine("Votre choix est " + userchoice + " et mon choix est " + ordchoice + ". Je gagne la partie");
            Console.WriteLine();

        }

        private void roche()
        {
            ordchoice = "roche";

            if (userchoice == "roche")
            {
                Pnull();
            }
            else if (userchoice == "papier")
            {
                gagne();
            }
            else if (userchoice == "ciseau")
            {
                perdu();
            }
           
        }
        private void papier()
        {
            ordchoice = "papier";

            if (userchoice == "roche")
            {
                perdu();
            }
            else if (userchoice == "papier")
            {
                Pnull();
            }
            else if (userchoice == "ciseau")
            {
                gagne();
            }
        }

        private void ciseau()
        {
            ordchoice = "ciseau";

            if (userchoice == "roche")
            {
                gagne();
            }
            else if (userchoice == "papier")
            {
                perdu();
            }
            else if (userchoice == "ciseau")
            {
                Pnull();
            }
           
      
        }

        private void rejouer()
        {
            Console.WriteLine("Voulez-vous refaire une partie (O/N) ? ");
            char rejoue = Console.ReadKey().KeyChar;

            if (rejoue=='N' || rejoue =='n')
            {
                Console.WriteLine();
                selectChoice();
                
            }
            else if (rejoue=='O' || rejoue == 'o')
            {
                Console.WriteLine();
                playerchoice2();
            }
            else
            {
                Console.ReadLine();
                rejouer();

            }
        }

    }
}
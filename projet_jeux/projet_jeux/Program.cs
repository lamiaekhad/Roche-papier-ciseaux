
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
        string[] Fruits;
        string selectmot;
        char[] charArray;
        string mot;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Program program = new Program();
            program.selectChoice();
        }

        //Menu
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
                    enssemble();
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

        //roche/papier/ciseau
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

            if (rejoue == 'N' || rejoue == 'n')
            {
                Console.WriteLine();
                selectChoice();
            }
            else if (rejoue == 'O' || rejoue == 'o')
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

        //Devinette
        private void affichedevinette()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Bienvenue dans la devinette");
            Console.WriteLine("-----------------------------------------------------------");

        }
        private void mothasard()
        {
            int devine;

            devine = random.Next(0, 9);
            Fruits = new string[] { "banane","poire", "pomme",
                                    "cerise","mangue", "figue",
                                    "trangerine", "fraise", "bleuet"};
            selectmot = Fruits[devine];
        }
        
        private void lettrehasard()
        {
            var devinelettre = 0;
            char selectlettre1;
            char selectlettre2;
            char selectlettre3;

            charArray = selectmot.ToCharArray();
            
            devinelettre = (random.Next(0, selectmot.Length));
            selectlettre1 = charArray[devinelettre];

            do
            {
                devinelettre = (random.Next(0, selectmot.Length));
                selectlettre2 = charArray[devinelettre];

            } while (selectlettre1 == selectlettre2);

            do
            {
                devinelettre = (random.Next(0, selectmot.Length));
                selectlettre3 = charArray[devinelettre];

            } while (selectlettre1 == selectlettre3 || selectlettre2 == selectlettre3);

                mot = selectmot.Replace(selectlettre1, '_').Replace(selectlettre2, '_').Replace(selectlettre3, '_');
              
        }

        private void devinette()
        {
            string yourguess = " ";
            int guesstime = 0;
            int guesslimit = 3;
            bool outofguess = false;

            while (yourguess != selectmot && !outofguess)
            {

                if (guesstime < guesslimit)
                {
                    Console.WriteLine("FRUIT A TROUVER: " + mot );
                    yourguess = Console.ReadLine();
                    guesstime++;
                }
                else
                {
                    outofguess = true;
                }
            }

            if (yourguess == selectmot || !outofguess)
            {
                Console.WriteLine();
                Console.WriteLine("Bravo! vous avez trouvé le mot!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("le mot était : " + selectmot);
                Console.WriteLine();

            }
        }
        private void enssemble()
        {
            affichedevinette();
            mothasard();
            lettrehasard();
            devinette();
        }

    }
}
using System;


namespace NumbersGame
{
    class Program
    {
        static Random numberGenerator = new Random();
        static void Main(string[] args)
        {
            bool continuePlaying = true;

            while (continuePlaying)
            {
                int nrOfGuesses = 0;
                int generatedNumber = 0;
                int closeHelpNr = 0;
                bool helpOn = false;

                bool choosenDifficulty = false;
                bool choosenHelp = false;

                Console.WriteLine("Välkommen! Jag kommer tänka på ett nummer. Du ska gissa vilket. Vilken svårighet vill du ha? \"Lätt\", \"medel\" eller \"svårt\"?");
                
                //Checks for which difficulty the user chooses. Sets the settings accordingly.  
                while (!choosenDifficulty)
                {       
                    string difficulty = Console.ReadLine().ToUpper();
                    switch (difficulty)
                    {
                        case "LÄTT":
                            Console.WriteLine("Du valde lätt. Numret är mellan 1 och 10. Du får 5 gissningar.");
                            nrOfGuesses = 5;
                            closeHelpNr = 1;
                            generatedNumber = numberGenerator.Next(1, 11);
                            choosenDifficulty = true;
                            break;

                        case "MEDEL":
                            Console.WriteLine("Du valde medel. Numret är mellan 1 och 25. Du får 4 gissningar.");
                            nrOfGuesses = 4;
                            closeHelpNr = 2;
                            generatedNumber = numberGenerator.Next(1, 26);
                            choosenDifficulty = true;
                            break;

                        case "SVÅRT":
                            Console.WriteLine("Du valde svårt. Numret är mellan 1 och 40. Du får 3 gissningar.");
                            nrOfGuesses = 3;
                            closeHelpNr = 3;
                            generatedNumber = numberGenerator.Next(1, 41);
                            choosenDifficulty = true;
                            break;

                        default:
                            Console.WriteLine("Jag förstod inte. Vänligen välj \"Lätt\", \"medel\" eller \"svårt\"");
                            break;
                    }
                }

                Console.WriteLine("\nVill du få tips på när du är nära numret? Svara \"Ja\" eller \"Nej\"");

                //Checks if the user wants to know if his guess is close. 
                while (!choosenHelp)
                {
                    string answer = Console.ReadLine().ToUpper();
                    switch (answer)
                    {
                        case "JA":
                            choosenHelp = true;
                            helpOn = true;
                            Console.WriteLine("Du valde att få tips när du är nära numret. Börja med att gissa ett nummer. Lycka till!\n");
                            break;
                        case "NEJ":
                            choosenHelp = true;
                            Console.WriteLine("Du valde att inte få tips när du är nära numret. Börja med att gissa ett nummer. Lycka till!\n");
                            break;
                        default:
                            Console.WriteLine("Jag förstod inte. Vänligen svara \"Ja\" eller \"Nej\"");
                            break;
                    }
                }

                int guessesLeft = nrOfGuesses;

                //Loops through the guesses and checks if the user got it right, is close, have guesses left etc
                while (guessesLeft > 0)
                {

                    int guessedNumber = int.Parse(Console.ReadLine());
                    guessesLeft--;

                    if (guessedNumber == generatedNumber)
                    {
                        Console.WriteLine(getCongratsMessage());
                        break;
                    }
                    else if (guessedNumber > generatedNumber & guessesLeft !=0)
                    {
                        Console.WriteLine("Tyvärr du gissade för högt."+ writeIfCloseAndHelpOn(guessedNumber, generatedNumber, closeHelpNr, helpOn));
                        Console.WriteLine(getGuessAgainComment());
                    }
                    else if (guessedNumber < generatedNumber & guessesLeft != 0)
                    {
                        Console.WriteLine("Tyvärr du gissade för lågt." + writeIfCloseAndHelpOn(guessedNumber, generatedNumber, closeHelpNr, helpOn));
                        Console.WriteLine(getGuessAgainComment());
                    }
                    else if (guessesLeft == 0)
                    {
                        Console.WriteLine("Talet var {0} och du lyckades tyvärr inte gissa det!", generatedNumber);

                    }
                }

                //Checks if the user wants to play again
                Console.WriteLine("\n\nVill du starta om spelet? Skriv \"Ja\" isåfall, annars klicka bara enter.");
                if (!(Console.ReadLine().ToUpper()=="JA"))
                {
                    continuePlaying = false;
                }
                else
                {
                    Console.WriteLine("\n\n----------------------------------------------------------------------------------\n\n");
                }

            //Returns a random "guess again" message
            static string getGuessAgainComment()
            {
                string[] comments = new string[] { "Gissa igen!", "Gissa en gång till!", "Gissa ännu en gång!", "Försök med en till gissning!" };
                return comments[numberGenerator.Next(0, comments.Length)];
            }

            //Returns a random congrats message
            static string getCongratsMessage()
            {
                string[] comments = new string[] { "Woho! Du gjorde det!", "Grattis du gissade rätt!", "Du klarade det!", "Såja! Du gissade rätt nummer!" };
                return comments[numberGenerator.Next(0, comments.Length)];
            }
            
            //Returns "Det bränns" if the guessed nr is close to the generated number and if the user has extra help on. 
            static string writeIfCloseAndHelpOn(int guessedNr, int generatedNr, int closeHelpNr, bool helpOn)
                {
                    if (Math.Abs(guessedNr - generatedNr) <= closeHelpNr & helpOn)
                    {
                        return " Men det bränns.";
                    }
                    else
                    {
                        return "";
                    }
                }

            }
        }
    }
}

using System;
using System.Linq;


internal class Program
{
    
    static void Main(string[] args)
    {
        void InitHangManImage(string[] hangManImage)
        {
            hangManImage[9] = "_|___";
            hangManImage[8] = " |\n_|___";
            hangManImage[7] = " |\n |\n_|___";
            hangManImage[6] = " |\n |\n |\n_|___";
            hangManImage[5] = " |\n |\n |\n |\n_|___";
            hangManImage[4] = " |\n |\n |\n |\n |\n_|___";
            hangManImage[3] = " |/\n |\n |\n |\n |\n |\n_|___";
            hangManImage[2] = "  _______\n |/\n |\n |\n |\n |\n_|___";
            hangManImage[1] = "  _______\n |/      |\n |\n |\n |\n |\n_|___";
            hangManImage[0] = "  _______\n |/      |\n |      (_)\n |      \\|/\n |       |\n |      / \\\n_|___";
        }
        string[] hangManImage = new string[11];
        InitHangManImage(hangManImage);

        void PrintHangmanImage(int triesLeft)
        {
            Console.WriteLine(hangManImage[triesLeft]);
        }

        void InitSecretWordsEasy(string[] words)
        {
            words[0] = "BAT";
            words[1] = "RING";
            words[2] = "BIRD";
            words[3] = "HAT";
            words[4] = "KEY";
            words[5] = "WAVE";
            words[6] = "STAR";
            words[7] = "SUN";
            words[8] = "FOOD";
            words[9] = "FORK";
        }
        void InitSecretWordsHard(string[] words)
        {
            words[0] = "SNOWMAN";
            words[1] = "ENCYCLOPEDIA";
            words[2] = "FORHEAD";
            words[3] = "APPLEPIE";
            words[4] = "ROYALTY";
            words[5] = "WATERBOTTLE";
            words[6] = "MONKEY";
            words[7] = "LAPTOP";
            words[8] = "POLICE";
            words[9] = "DOCTOR";
        }
        int tries = 10;
        string[] secretWords = new string[10]; 
        Random rnd = new Random();
        string secretWord = "";
        string chosenWord = "";
       
        Console.WriteLine("Do you want to choose a word of your own? y/n");
        string answer = Console.ReadLine();

        answer = answer.ToUpper();
        if (answer == "YES" || answer == "Y")
        {
            Console.WriteLine("Write the word!");
            secretWord = Console.ReadLine();
            while(secretWord == null || secretWord.Contains(' ')||secretWord=="")
            {
                Console.WriteLine("Word cannot be null or empty, and cannot contain blankspace!");
                secretWord = Console.ReadLine();
            }
            secretWord = secretWord.ToUpper();
            
        }
        else
        {
            Console.WriteLine("Word will be randomized, do you want easy mode? y/n");
            answer = Console.ReadLine();
            answer = answer.ToUpper();
            if (answer == "YES" || answer == "Y")
            {
                InitSecretWordsEasy(secretWords);
                secretWord = secretWords[rnd.Next(10)];
                
            }
            else
            {
                InitSecretWordsHard(secretWords);
                secretWord = secretWords[rnd.Next(10)];
                
            }
            secretWord = secretWord.ToUpper();
        }
        
        char[] chosenWordCharArr = new char[secretWord.Length];
        for (int i = 0;i<secretWord.Length;i++)
        {
            chosenWordCharArr[i] = '_';
        }


        Console.WriteLine(chosenWord);
        Console.WriteLine("Please Type in a letter to guess the secret word!");
        string letter = Console.ReadLine();
        string[] guessedLetters = new string[tries];
        int iterations = 0;
        while(chosenWord!=secretWord)
        {
            
            if (letter== null)
            {
                Console.WriteLine("Letter cannot be null.");
                letter = Console.ReadLine();
                continue;
            }
            if (letter != null)
            {
                letter = letter.ToUpper();
            }
            if (letter!= null)
            {
                if ( letter.Length<1)
                {
                    Console.WriteLine("Letter must be length of one or more.");
                    letter = Console.ReadLine();
                    continue;
                }
                
            }
           
           
            if (letter != null)
            {
                
                if (secretWord.Contains(letter)&&!chosenWord.Contains(letter))
                {

                    int index = secretWord.IndexOf(letter);

                    if(letter.Length>1)
                    {
                       for(int i=0; i< letter.Length; i++)
                        {
                            chosenWordCharArr[index + i] = letter[i];
                        }
                    }
                    else
                    {
                        for (int i = 0; i < secretWord.Length; i++)
                        {
                            if (secretWord[i] == letter[0])
                            {
                                chosenWordCharArr[i] = letter[0];

                            }

                        }
                    }

                    

                    chosenWord = string.Join("", chosenWordCharArr);
                    Console.WriteLine("Correct!");
                    Console.WriteLine(chosenWordCharArr);
                    Console.WriteLine("\n.................");
                    PrintHangmanImage(tries);
                    if (chosenWord==secretWord)
                    {
                        Console.WriteLine("Correct the secret word was: " + secretWord);
                        break;
                    }
                }
                else if (guessedLetters.Contains(letter))
                {
                    Console.WriteLine("You already guessed this.");
                }
                else
                {
                    guessedLetters[iterations++] = letter;
                    tries--;
                    Console.WriteLine("Wrong, " + tries + " tries left!");
                    Console.WriteLine(chosenWordCharArr);
                    Console.WriteLine("\n.................");
                    PrintHangmanImage(tries);
                    

                    if (tries == 0)
                    {
                        Console.WriteLine("Wrong, " + tries + " tries left! You LOST!!!!");
                        Console.WriteLine("The word was " + secretWord);
                        break;
                    }

                    
                    
                }
                
            }
            Console.WriteLine("Please Type in a letter to guess the secret word!");
            letter = Console.ReadLine();

        }
        
        
    }
    
}


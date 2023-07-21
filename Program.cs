namespace pokemonproject;
class Program
{
    static void Main(string[] args)
    {
        string itemsFile = @"assets/items.txt";

        string[] mainOptions = { "Jugar", "Ajustes", "Salir" };
        string[] settingsOptions = { "Volumen", "Idioma", "Volver Atrás" };
        string[] languageOptions = { "Español", "Inglés", "Volver Atrás" };
        string[] gameOptions = { "Pikachu", "Charizard", "Volver Atrás" };

        string[] engMainOptions = { "Play", "Settings", "Exit" };
        string[] engSettingsOptions = { "Volume", "Languages", "Back" };
        string[] engLanguageOptions = { "Spanish", "English" };


        string[] items = File.ReadAllLines(itemsFile)!;

        string prompt = "Qué desea hacer?";
        string gamePrompt = @"   JUGADOR 1 
                                                                                            Seleccione su Pokemón";
        // string engPrompt = "What would you like to do?";
        string currentLanguage = "esp";

        #region Object Creation

        Menu mainMenu = new Menu(mainOptions, prompt);
        Menu settingsMenu = new Menu(settingsOptions, prompt);
        Menu languageMenu = new Menu(languageOptions, prompt);
        Menu gameMenu = new Menu(gameOptions, gamePrompt);
        // Pokemon pikachu = new Pokemon("Pikachu", "Electric", 25, statistics(35, 55, 40, 50, 50, 90), individualValues(), effortValues());
        // Pokemon charizard = new Pokemon("Pikachu", "Electric", 25, statistics(78, 84, 78, 109, 85, 100), individualValues(), effortValues());


        #endregion

        string firstPlayerPokemon = "Pikachu";
        string secondPlayerPokemon = "Charizard";

        Game game = new Game();

        bool running = true;

        while (running)
        {
            switch (mainMenu.Run())
            {
                case 0:
                    switch (gameMenu.Run())
                    {
                        case 0:

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@$"


                                                                                              JUGADOR 1: {firstPlayerPokemon}");

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@$"
                                                                                              JUGADOR 2: {secondPlayerPokemon}");

                            Console.ResetColor();
                            Console.WriteLine(@"
                                                    
                                                                                          Presione 'ENTER' para comenzar.");
                            Console.ReadLine();

                            loadingAnimation();

                            game.Run(firstPlayerPokemon, secondPlayerPokemon);
                            break;
                        case 1:
                            firstPlayerPokemon = "Charizard";
                            secondPlayerPokemon = "Pikachu";

                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(@$"


                                                                                              JUGADOR 1: {firstPlayerPokemon}");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@$"
                                                                                              JUGADOR 2: {secondPlayerPokemon}");

                            Console.ResetColor();
                            Console.WriteLine(@"
                                                    
                                                                                          Presione 'ENTER' para comenzar.");
                            Console.ReadLine();

                            loadingAnimation();

                            game.Run(firstPlayerPokemon, secondPlayerPokemon);
                            break;
                        case 3:
                            break;
                    }

                    break;

                case 1:
                    switch (settingsMenu.Run())
                    {
                        case 0:
                            Console.ReadLine();
                            break;
                        case 1:
                            switch (languageMenu.Run())
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                            }
                            break;
                        case 2:
                            break;
                    }
                    break;

                case 2:
                    if (currentLanguage == "esp")
                    {
                        string dot = ".";

                        Console.WriteLine();
                        Console.Write(@"Saliendo");

                        //Adds a dot for the loading animation
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(dot);
                            Thread.Sleep(500);
                        }

                        // Sets running to false so the while does not execute anymore
                        running = false;

                    }
                    else
                    {
                        string dot = ".";

                        Console.WriteLine();
                        Console.Write(@"Exiting");

                        //Adds a dot for the loading animation
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(dot);
                            Thread.Sleep(500);
                        }

                        // Sets running to false so the while does not execute anymore
                        running = false;


                    }
                    break;
            }
            continue;
        }
    }

    static void loadingAnimation()
    {
        string loadingAscii = @"
                        

         
                
                                                                                ██       ██████   █████  ██████  ██ ███    ██  ██████  
                                                                                ██      ██    ██ ██   ██ ██   ██ ██ ████   ██ ██       
                                                                                ██      ██    ██ ███████ ██   ██ ██ ██ ██  ██ ██   ███ 
                                                                                ██      ██    ██ ██   ██ ██   ██ ██ ██  ██ ██ ██    ██ 
                                                                                ███████  ██████  ██   ██ ██████  ██ ██   ████  ██████    ";

        string dot = "  ██  ";

        int counter = 0;
        ConsoleColor foregroundColor1 = ConsoleColor.Red;
        ConsoleColor foregroundColor2 = ConsoleColor.Cyan;

        while (true)
        {
            Console.Clear();

            int leftOver = counter % 2;



            Console.Write(loadingAscii);

            for (int i = 0; i < 3; i++)
            {
                switch (leftOver)
                {
                    case 0:
                        Console.ForegroundColor = foregroundColor1;
                        break;

                    case 1:
                        Console.ForegroundColor = foregroundColor2;
                        break;

                }
                Console.Write(dot);
                Thread.Sleep(700);
            }
            counter++;
            if (counter > 2)
            {
                break;
            }
        }

    }

    static Dictionary<string, int> individualValues()
    {
        Dictionary<string, int> IVs = new Dictionary<string, int>(6);
        Random rnd = new Random();

        IVs.Add("HP", rnd.Next(0, 31));
        IVs.Add("Attack", rnd.Next(0, 31));
        IVs.Add("Defense", rnd.Next(0, 31));
        IVs.Add("Sp. Attack", rnd.Next(0, 31));
        IVs.Add("Sp. Defense", rnd.Next(0, 31));
        IVs.Add("Speed", rnd.Next(0, 31));


        return IVs;
    }


}

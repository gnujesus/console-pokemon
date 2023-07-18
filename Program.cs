namespace pokemonproject;
class Program
{
    static void Main(string[] args)
    {
        string itemsFile = @"assets/items.txt";

        string[] mainOptions = { "Jugar", "Ajustes", "Salir" };
        string[] settingsOptions = { "Volumen", "Idioma", "Volver Atrás" };
        string[] languageOptions = { "Español", "Inglés" };
        string[] gameOptions = { "Pikachu", "Charizard", "Volver Atrás" };

        string[] engMainOptions = { "Play", "Settings", "Exit" };
        string[] engSettingsOptions = { "Volume", "Languages", "Back" };
        string[] engLanguageOptions = { "Spanish", "English" };


        string[] items = File.ReadAllLines(itemsFile)!;

        string prompt = "Qué desea hacer?";
        string gamePrompt = "Seleccione su Pokemón";
        // string engPrompt = "What would you like to do?";
        string currentLanguage = "esp";

        #region Object Creation

        Menu mainMenu = new Menu(mainOptions, prompt);
        Menu settingsMenu = new Menu(settingsOptions, prompt);
        Menu languageMenu = new Menu(languageOptions, prompt);
        Menu gameMenu = new Menu(gameOptions, gamePrompt);
        Pokemon pikachu = new Pokemon("Pikachu", "Electric", 25, statistics(35, 55, 40, 50, 50, 90), individualValues(), effortValues());
        Pokemon charizard = new Pokemon("Pikachu", "Electric", 25, statistics(78, 84, 78, 109, 85, 100), individualValues(), effortValues());
        Bag playerOneBag = new Bag(GetRandomElements(items));
        Bag playerTwoBag = new Bag(GetRandomElements(items));

        #endregion

        string playerOnePokemon = "Pikachu";
        string playerTwoPokemon = "Charizard";


        bool running = true;

        while (running)
        {
            switch (mainMenu.Run())
            {
                case 0:
                    switch (gameMenu.Run())
                    {
                        case 0:

                            Console.WriteLine($"JUGADOR 1: {playerOnePokemon}");
                            Console.WriteLine($"JUGADOR 2: {playerTwoPokemon}");

                            Console.WriteLine("Presione 'ENTER' para comenzar.");
                            Console.ReadLine();

                            break;
                        case 1:
                            playerOnePokemon = "Charizard";
                            playerTwoPokemon = "Pikachu";

                            Console.WriteLine();

                            Console.WriteLine($"JUGADOR 1: {playerOnePokemon}");
                            Console.WriteLine($"JUGADOR 2: {playerTwoPokemon}");

                            Console.WriteLine("Presione 'ENTER' para comenzar.");
                            Console.ReadLine();

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

    static Dictionary<string, int> statistics(int HP, int Attack, int Defense, int SpAttack, int SpDefense, int Speed)
    {
        Dictionary<string, int> stats = new Dictionary<string, int>(6);
        stats.Add("HP", HP);
        stats.Add("Attack", Attack);
        stats.Add("Defense", Defense);
        stats.Add("Sp. Attack", SpAttack);
        stats.Add("Sp. Defense", SpDefense);
        stats.Add("Speed", Speed);

        return stats;
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

    // Nomar
    static Dictionary<string, int> effortValues()
    {
        Dictionary<string, int> EVs = new Dictionary<string, int>
        {
            { "HP", 0 },
            { "Attack", 0 },
            { "Defense", 0 },
            { "Sp. Attack", 0 },
            { "Sp. Defense", 0 },
            { "Speed", 0 }
        };
        return EVs;
    }

    // Emelind


    static string[] GetRandomElements(string[] array)
    {
        Random random = new Random();
        int elementsToReturn = Math.Min(6, array.Length);
        int[] indices = Enumerable.Range(0, array.Length).OrderBy(x => random.Next()).Take(elementsToReturn).ToArray();
        string[] randomElements = indices.Select(P => array[P]).ToArray();
        foreach (string value in randomElements)
        {
            Console.WriteLine(value);
        }

        return randomElements;
    }


}

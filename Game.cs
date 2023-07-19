class Game
{
    #region Menus
    private FightMenu GameMenu;
    private BagMenu PlayerOneBagMenu;
    private BagMenu PlayerTwoBagMenu;
    private FightMenu PikachuInfoMenu;
    private FightMenu CharizardInfoMenu;
    private string Prompt;
    private string[] Options;
    private string[] PlayerOneBagOptions;
    private string[] PlayerTwoBagOptions;
    private string[] InfoMenuOptions;
    private string PikachuInfoMenuPrompt;
    private string CharizardInfoMenuPrompt;

    #endregion



    #region Pokemons
    private Pokemon Pikachu;
    private Pokemon Charizard;

    #endregion



    #region Items
    private string ItemsFile;
    private Bag PlayerOneBag;
    private Bag PlayerTwoBag;
    private string[] Items;

    #endregion 


    #region Pikachu Moves

    Move latigo = new Move("Latigo", "Normal");
    Move ataqueRapido = new Move("Ataque Rapido", "Normal");
    Move amago = new Move("Amago", "Normal");
    Move impactrueno = new Move("Impactrueno", "Electric");
    Move bolaVoltio = new Move("Bola Voltio", "Electric");
    Move ondaTrueno = new Move("Onda Trueno", "Electric");
    Move chispa = new Move("Chispa", "Electric");

    #endregion


    #region Both Pokemon Moves


    Move grunido = new Move("Grunido", "Normal");


    #endregion



    #region Charizard Moves
    Move ataqueAla = new Move("Ataque Ala", "Flying");
    Move tajoAereo = new Move("Tajo Aereo", "Flying");
    Move aranazo = new Move("Aranazo", "Normal");
    Move envisteIgneo = new Move("Enviste Igneo", "Fire");
    Move ondaIgnea = new Move("Onda Ignea", "Fire");
    Move ascuas = new Move("Ascuas", "Fire");
    Move garraDragon = new Move("Garra Dragon", "Dragon");

    #endregion




    public Game()
    {
        ItemsFile = @"assets/items.txt";
        Items = File.ReadAllLines(ItemsFile);

        PlayerOneBag = new Bag(GetRandomElements(Items));
        PlayerTwoBag = new Bag(GetRandomElements(Items));

        Prompt = "QUÉ HARÁS?";
        Options = new string[] { "Atacar", "Mochila", "Pokemon", "Huir" };
        PlayerOneBagOptions = PlayerOneBag.Items;
        PlayerTwoBagOptions = PlayerOneBag.Items;
        GameMenu = new FightMenu(Options, Prompt);
        PlayerOneBagMenu = new BagMenu(PlayerOneBagOptions, Prompt);
        PlayerTwoBagMenu = new BagMenu(PlayerTwoBagOptions, Prompt);

        Pikachu = new Pokemon("Pikachu", "Electric", 25, statistics(35, 55, 40, 50, 50, 90), individualValues(), effortValues());
        Charizard = new Pokemon("Pikachu", "Electric", 25, statistics(78, 84, 78, 109, 85, 100), individualValues(), effortValues());

        InfoMenuOptions = new string[] { "Volver Atrás" };
        CharizardInfoMenuPrompt = Charizard.returnInfo();
        PikachuInfoMenuPrompt = Pikachu.returnInfo();
        PikachuInfoMenu = new FightMenu(InfoMenuOptions, PikachuInfoMenuPrompt);
        CharizardInfoMenu = new FightMenu(InfoMenuOptions, CharizardInfoMenuPrompt);

    }

    private Dictionary<string, int> statistics(int HP, int Attack, int Defense, int SpAttack, int SpDefense, int Speed)
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

    private Dictionary<string, int> individualValues()
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
    private Dictionary<string, int> effortValues()
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

    private string[] GetRandomElements(string[] array)
    {
        Random random = new Random();
        int elementsToReturn = Math.Min(6, array.Length);
        int[] indices = Enumerable.Range(0, array.Length).OrderBy(x => random.Next()).Take(elementsToReturn).ToArray();
        string[] randomElements = indices.Select(P => array[P]).ToArray();
        foreach (string value in randomElements)
        {
            Console.WriteLine(value);
        }

        List<string> randomElementsWithBackOption = new List<string>(randomElements);
        randomElementsWithBackOption.Add("Volver Atrás");
        string[] finalRandomElements = randomElementsWithBackOption.ToArray();

        return finalRandomElements;

    }

    public void Run(string playerOnePokemon, string playerTwoPokemon)
    {
        bool running = true;
        bool playerOne = true;

        while (running)
        {
            switch (GameMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
            {
                case 0:
                    playerOne = !playerOne;
                    break;

                case 1:
                    if (playerOne == true)
                    {

                        switch (PlayerOneBagMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
                        {
                            case 0:
                                break;
                            case 7:
                                break;
                        }
                    }
                    else
                    {
                        switch (PlayerTwoBagMenu.Run(playerTwoPokemon, playerTwoPokemon, playerOne))
                        {
                            case 0:
                                break;
                            case 7:
                                break;
                        }
                    }
                    break;

                case 2:
                    if (playerOne == true)
                    {
                        switch (playerOnePokemon)
                        {
                            case "Pikachu":
                                PikachuInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne);
                                break;
                            case "Charizard":
                                CharizardInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne);
                                break;
                        }
                    }
                    else
                    {
                        switch (playerTwoPokemon)
                        {
                            case "Pikachu":
                                PikachuInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne);
                                break;
                            case "Charizard":
                                CharizardInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne);
                                break;
                        }
                    }
                    break;


            }
        }
    }

}
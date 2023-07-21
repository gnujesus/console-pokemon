class Game
{
    #region Menus
    private FightMenu GameMenu;
    private BagMenu PlayerOneBagMenu;
    private BagMenu PlayerTwoBagMenu;
    private InfoMenu PikachuInfoMenu;
    private InfoMenu CharizardInfoMenu;
    private CantFleeMenu cantFleeMenu;
    private AttackMenu pikachuAttackMenu;
    private AttackMenu charizardAttackMenu;
    private string Prompt;
    private string[] Options;
    private string[] PlayerOneBagOptions;
    private string[] PlayerTwoBagOptions;
    private string[] InfoMenuOptions;
    private string[] goBackOption;
    private string PikachuInfoMenuPrompt;
    private string CharizardInfoMenuPrompt;
    private string cantFleePrompt;
    private string attackMenuPrompt;
    private string cantCatchAnothersTrainerPokemonPrompt;

    private Dictionary<string, Pokemon> PlayersPokemons;

    #endregion



    #region Pokemons
    private Pokemon Pikachu;
    private Pokemon Charizard;
    private Dictionary<string, Move> PikachuMoves;
    private Dictionary<string, Move> CharizardMoves;
    private string[] PikachuMoveOptions;
    private string[] CharizardMoveOptions;

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
        cantFleePrompt = "NO PUEDES HUIR!";
        cantCatchAnothersTrainerPokemonPrompt = "NO PUEDES ATRAPAR EL POKEMON DE OTRO ENTRENADOR";
        attackMenuPrompt = "ELIGE TU ATAQUE";
        PikachuMoveOptions = new string[] { "Latigo", "Ataque Rápido", "Impactrueno", "Bola Voltio", "Onda Trueno", "Amago", "Volver Atrás" };
        CharizardMoveOptions = new string[] { "Ataque Ala", "Tajo Aereo", "Aranazo", "Enviste Igneo", "Onda Ignea", "Ascuas", "Garra Dragon", "Volver Atrás" };
        Options = new string[] { "Atacar", "Mochila", "Pokemon", "Huir" };

        pikachuAttackMenu = new AttackMenu(PikachuMoveOptions, attackMenuPrompt);
        charizardAttackMenu = new AttackMenu(CharizardMoveOptions, attackMenuPrompt);


        PlayerOneBagOptions = PlayerOneBag.Items;
        PlayerTwoBagOptions = PlayerOneBag.Items;
        PlayerOneBagMenu = new BagMenu(PlayerOneBagOptions, Prompt);
        PlayerTwoBagMenu = new BagMenu(PlayerTwoBagOptions, Prompt);
        GameMenu = new FightMenu(Options, Prompt);


        Pikachu = new Pokemon("Pikachu", "Electric", 60, statistics(35, 55, 40, 50, 50, 90), individualValues(), effortValues(200, 40, 24, 136, 8, 148));
        Charizard = new Pokemon("Charizard", "Fire", 20, statistics(78, 84, 78, 109, 85, 100), individualValues(), effortValues(200, 30, 84, 112, 80, 32));

        InfoMenuOptions = new string[] { "Volver Atrás" };
        CharizardInfoMenuPrompt = Charizard.returnInfo();
        PikachuInfoMenuPrompt = Pikachu.returnInfo();
        PikachuInfoMenu = new InfoMenu(InfoMenuOptions, PikachuInfoMenuPrompt);
        CharizardInfoMenu = new InfoMenu(InfoMenuOptions, CharizardInfoMenuPrompt);
        cantFleeMenu = new CantFleeMenu(goBackOption, cantFleePrompt);


        PlayersPokemons = new Dictionary<string, Pokemon>();
        PlayersPokemons.Add("First Player Pokemon", Pikachu);
        PlayersPokemons.Add("Second Player Pokemon", Charizard);

        PikachuMoves = new Dictionary<string, Move>();
        PikachuMoves.Add("Latigo", latigo);
        PikachuMoves.Add("Amago", amago);
        PikachuMoves.Add("Impactrueno", impactrueno);
        PikachuMoves.Add("Bola Voltio", bolaVoltio);
        PikachuMoves.Add("Chispa", chispa);
        PikachuMoves.Add("Ataque Rapido", ataqueRapido);
        PikachuMoves.Add("Onda Trueno", ondaTrueno);

        CharizardMoves = new Dictionary<string, Move>();
        CharizardMoves.Add("Ataque Ala", ataqueAla);
        CharizardMoves.Add("Tajo Aereo", tajoAereo);
        CharizardMoves.Add("Aranazo", aranazo);
        CharizardMoves.Add("Enviste Igneo", envisteIgneo);
        CharizardMoves.Add("Onda Ignea", ondaIgnea);
        CharizardMoves.Add("Ascuas", ascuas);
        CharizardMoves.Add("Garra Dragon", garraDragon);

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

        IVs.Add("HP", rnd.Next(10, 31));
        IVs.Add("Attack", rnd.Next(1, 31));
        IVs.Add("Defense", rnd.Next(1, 31));
        IVs.Add("Sp. Attack", rnd.Next(1, 31));
        IVs.Add("Sp. Defense", rnd.Next(1, 31));
        IVs.Add("Speed", rnd.Next(1, 31));


        return IVs;
    }

    // Nomar
    private Dictionary<string, int> effortValues(int HP, int Attack, int Defense, int SpAttack, int SpDefense, int Speed)
    {
        Dictionary<string, int> EVs = new Dictionary<string, int>();
        EVs.Add("HP", HP);
        EVs.Add("Attack", Attack);
        EVs.Add("Defense", Defense);
        EVs.Add("Sp. Attack", SpAttack);
        EVs.Add("Sp. Defense", SpDefense);
        EVs.Add("Speed", Speed);

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

    private int Heal(int HP, int Increment, int BaseHP)
    {

        int totalHP = HP + Increment;
        if (totalHP > BaseHP)
        {
            totalHP = BaseHP;
        }
        return totalHP;
    }

    public void restoreAll(ref string currentEffect, ref int HP, int baseHealth, Pokemon healedPokemon)
    {
        switch (healedPokemon.Name)
        {
            case "Pikachu":
                Pikachu.inGameStats["Defense"] = Pikachu.inGameStats["Defense"];
                Pikachu.inGameStats["HP"] = baseHealth;
                Console.WriteLine("TODOS LOS EFECTOS HAN SIDO LIMPIADOS!");
                break;


        }
    }

    public void decreaseHP(int HP, int decrement, Pokemon attackedPokemon, string attackType)
    {
        switch (attackedPokemon.Name)
        {
            case "Pikachu":
                Pikachu.inGameStats["HP"] = HP - (decrement - (Pikachu.inGameStats["Defense"] / 2));
                break;
            case "Charizard":
                Charizard.inGameStats["HP"] = HP - (decrement - (Pikachu.inGameStats["Defense"] / 2));
                break;
        }
    }

    public void itemsFunctionality(string item, string playerOnePokemon, string playerTwoPokemon)
    {
        switch (item)
        {
            case "Poción":
                break;
            case "Vidasfera":
                break;
            case "Sprite de Cinta Fuerte":
                break;
            case "Chaleco Asalto":
                break;
            case "Orison Soto":
                break;
            case "Superpoción":
                break;
            case "Hiperpoción":
                break;
            case "Restaurar Todo":
                break;
            case "Pokeball":
                switch (playerOnePokemon)
                {
                    case "Pikachu":
                        Console.WriteLine(@"
                                                                                NO PUEDES ATRAPAR EL POKEMON DE OTRO JUGADOR! 
                                                                                              Presiona 'ENTER'");
                        Console.ReadLine();
                        break;
                    case "Charizard":
                        Console.WriteLine(@"
                                                                                NO PUEDES ATRAPAR EL POKEMON DE OTRO JUGADOR! 
                                                                                              Presiona 'ENTER'");
                        Console.ReadLine();
                        break;
                }
                break;
            case "Masterball":
                switch (playerOnePokemon)
                {
                    case "Pikachu":
                        Console.WriteLine(@"
                                                                                NO PUEDES ATRAPAR EL POKEMON DE OTRO JUGADOR! 
                                                                                              Presiona 'ENTER'");
                        Console.ReadLine();
                        break;
                    case "Charizard":
                        Console.WriteLine(@"
                                                                                NO PUEDES ATRAPAR EL POKEMON DE OTRO JUGADOR! 
                                                                                              Presiona 'ENTER'");
                        Console.ReadLine();
                        break;
                }
                break;
        }
        return;
    }

    public void Run(string playerOnePokemon, string playerTwoPokemon)
    {
        bool running = true;
        bool playerOne = true;

        while (running && PlayersPokemons["First Player Pokemon"].inGameStats["HP"] != 0 && PlayersPokemons["Second Player Pokemon"].inGameStats["HP"] != 0)
        {
            switch (GameMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
            {
                case 0:
                    if (playerOne)
                    {
                        switch (playerOnePokemon)
                        {
                            case "Pikachu":
                                switch (pikachuAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
                                {
                                    case 0:
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        playerOne = !playerOne;
                                        break;
                                    case 7:
                                        break;
                                }
                                break;
                            case "Charizard":
                                switch (charizardAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
                                {
                                    case 0:
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        playerOne = !playerOne;
                                        break;
                                    case 7:
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (playerTwoPokemon)
                        {
                            case "Pikachu":
                                switch (pikachuAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
                                {
                                    case 0:
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        playerOne = !playerOne;
                                        break;
                                    case 7:
                                        break;
                                }
                                break;
                            case "Charizard":
                                switch (charizardAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
                                {
                                    case 0:
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        playerOne = !playerOne;
                                        break;
                                    case 7:
                                        break;
                                }
                                break;
                        }

                    }
                    break;

                case 1:
                    if (playerOne)
                    {

                        switch (PlayerOneBagMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne))
                        {
                            case 0:
                                itemsFunctionality(PlayerOneBagMenu.Options[0], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 1:
                                itemsFunctionality(PlayerOneBagMenu.Options[1], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 2:
                                itemsFunctionality(PlayerOneBagMenu.Options[2], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 3:
                                itemsFunctionality(PlayerOneBagMenu.Options[3], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 4:
                                itemsFunctionality(PlayerOneBagMenu.Options[4], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 5:
                                itemsFunctionality(PlayerOneBagMenu.Options[5], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 6:
                                itemsFunctionality(PlayerOneBagMenu.Options[6], playerOnePokemon, playerTwoPokemon);
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
                            case 1:
                                itemsFunctionality(PlayerOneBagMenu.Options[1], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 2:
                                itemsFunctionality(PlayerOneBagMenu.Options[2], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 3:
                                itemsFunctionality(PlayerOneBagMenu.Options[3], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 4:
                                itemsFunctionality(PlayerOneBagMenu.Options[4], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 5:
                                itemsFunctionality(PlayerOneBagMenu.Options[5], playerOnePokemon, playerTwoPokemon);
                                break;
                            case 6:
                                itemsFunctionality(PlayerOneBagMenu.Options[6], playerOnePokemon, playerTwoPokemon);
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
                case 3:
                    cantFleeMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne);
                    break;

            }
        }
    }

}
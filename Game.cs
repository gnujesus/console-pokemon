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
    public string Spaces;

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


        Pikachu = new Pokemon("Pikachu", "Electric", 60, statistics(35, 55, 40, 50, 50, 90), individualValues(), effortValues(200, 40, 24, 136, 8, 148));
        Charizard = new Pokemon("Charizard", "Fire", 20, statistics(78, 84, 78, 109, 85, 100), individualValues(), effortValues(200, 30, 84, 112, 80, 32));

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

        pikachuAttackMenu = new AttackMenu(PikachuMoveOptions, attackMenuPrompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
        charizardAttackMenu = new AttackMenu(CharizardMoveOptions, attackMenuPrompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);


        PlayerOneBagOptions = PlayerOneBag.Items;
        PlayerTwoBagOptions = PlayerTwoBag.Items;
        PlayerOneBagMenu = new BagMenu(PlayerOneBagOptions, Prompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
        PlayerTwoBagMenu = new BagMenu(PlayerTwoBagOptions, Prompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
        GameMenu = new FightMenu(Options, Prompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);



        InfoMenuOptions = new string[] { "Volver Atrás" };
        CharizardInfoMenuPrompt = Charizard.returnInfo();
        PikachuInfoMenuPrompt = Pikachu.returnInfo();
        PikachuInfoMenu = new InfoMenu(InfoMenuOptions, PikachuInfoMenuPrompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
        CharizardInfoMenu = new InfoMenu(InfoMenuOptions, CharizardInfoMenuPrompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
        cantFleeMenu = new CantFleeMenu(InfoMenuOptions, cantFleePrompt, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);

        Spaces = "                                                           ";

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

    private void Heal(Pokemon healedPokemon, int Increment)
    {

        if ((healedPokemon.inGameStats["HP"] += Increment) <= healedPokemon.BaseHP)
        {
            healedPokemon.inGameStats["HP"] += Increment;
        }
        else
        {
            healedPokemon.inGameStats["HP"] = healedPokemon.BaseHP;
        }
    }

    public void restoreAll(ref string currentEffect, ref int HP, int baseHealth, Pokemon healedPokemon)
    {
        switch (healedPokemon.Name)
        {
            case "Pikachu":
                Pikachu.inGameStats["Defense"] = Pikachu.inGameStats["Defense"];
                Pikachu.inGameStats["HP"] = baseHealth;
                Console.WriteLine("                 TODOS LOS EFECTOS HAN SIDO LIMPIADOS!");
                break;


        }
    }

    public void decreaseHP(int decrement, Pokemon attackedPokemon, string attackType)
    {
        switch (attackedPokemon.Name)
        {
            case "Pikachu":
                Pikachu.inGameStats["HP"] = Pikachu.inGameStats["HP"] - (decrement - (Pikachu.inGameStats["Defense"] / 2));
                break;
            case "Charizard":
                Charizard.inGameStats["HP"] = Charizard.inGameStats["HP"] - (decrement - (Charizard.inGameStats["Defense"] / 2));
                break;
        }
    }

    public void increaseAttack(int increment, Pokemon attackIncreasedPokemon)
    {
        switch (attackIncreasedPokemon.Name)
        {
            case "Pikachu":
                Pikachu.inGameStats["Attack"] += increment;
                break;
            case "Charizard":
                Charizard.inGameStats["Attack"] += increment;
                break;
        }
    }

    public void increaseSpDefense(int increment, Pokemon defenseIncreasedPokemon)
    {
        switch (defenseIncreasedPokemon.Name)
        {
            case "Pikachu":
                Pikachu.inGameStats["Sp. Defense"] += increment;
                break;
            case "Charizard":
                Charizard.inGameStats["Sp. Defense"] += increment;
                break;
        }
    }

    public void itemsFunctionality(string item, string playerOnePokemon, string playerTwoPokemon, bool playerOne)
    {
        switch (item)
        {
            case "-":
                break;

            case "Poción":
                if (playerOne)
                {
                    switch (playerOnePokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 40);
                            break;
                        case "Charizard":
                            Heal(Charizard, 40);
                            break;
                    }
                }
                else
                {

                    switch (playerTwoPokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 40);
                            break;
                        case "Charizard":
                            Heal(Charizard, 40);
                            break;
                    }
                }
                Console.WriteLine(@$"
                        {Spaces}TU VIDA HA SIDO RESTAURADA POR 40 PUNTOS!
                                    {Spaces}PRESIONA 'ENTER'");
                Console.ReadLine();
                break;
            case "Vidasfera":
                if (playerOne)
                {
                    switch (playerOnePokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 60);
                            break;
                        case "Charizard":
                            Heal(Charizard, 60);
                            break;
                    }
                }
                else
                {

                    switch (playerTwoPokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 60);
                            break;
                        case "Charizard":
                            Heal(Charizard, 60);
                            break;
                    }
                }
                Console.WriteLine($@"
                        {Spaces}TU VIDA HA SIDO RESTAURADA POR 60 PUNTOS!
                                    {Spaces}PRESIONA 'ENTER'   ");
                Console.ReadLine();
                break;
            case "Sprite de Cinta Fuerte":
                if (playerOne)
                {
                    switch (playerOnePokemon)
                    {
                        case "Pikachu":
                            increaseAttack(20, Pikachu);
                            break;
                        case "Charizard":
                            increaseAttack(20, Charizard);
                            break;
                    }
                }
                else
                {
                    switch (playerTwoPokemon)
                    {
                        case "Pikachu":
                            increaseAttack(20, Pikachu);
                            break;
                        case "Charizard":
                            increaseAttack(20, Charizard);
                            break;
                    }
                }
                Console.WriteLine($@"
                        {Spaces}TU DEFENSA HA SIDO AUMENTADA POR 20 PUNTOS!
                                    {Spaces}PRESIONA 'ENTER'   ");
                Console.ReadLine();
                break;
            case "Chaleco Asalto":
                if (playerOne)
                {
                    switch (playerOnePokemon)
                    {
                        case "Pikachu":
                            increaseSpDefense(30, Pikachu);
                            break;
                        case "Charizard":
                            increaseSpDefense(30, Charizard);
                            break;
                    }
                }
                else
                {
                    switch (playerTwoPokemon)
                    {
                        case "Pikachu":
                            increaseSpDefense(30, Pikachu);
                            break;
                        case "Charizard":
                            increaseSpDefense(30, Charizard);
                            break;
                    }
                }
                Console.WriteLine($@"
                        {Spaces}TU DEFENSA ESPECIAL HA SIDO AUMENTADA POR 30 PUNTOS!
                                    {Spaces}PRESIONA 'ENTER'   ");
                Console.ReadLine();
                break;
            case "Orison Soto":
                Console.WriteLine(@$"
        {Spaces}HAS UTILIZADO AL LEGENDARIO 'ORISON SOTO', HAS OBTENIDO 5 PUNTOS PARA TU CALIFICACIÓN
                                    {Spaces}PRESIONA 'ENTER'");
                Console.ReadLine();
                break;
            case "Superpoción":
                if (playerOne)
                {
                    switch (playerOnePokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 60);
                            break;
                        case "Charizard":
                            Heal(Charizard, 60);
                            break;
                    }
                }
                else
                {

                    switch (playerTwoPokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 60);
                            break;
                        case "Charizard":
                            Heal(Charizard, 60);
                            break;
                    }
                }
                Console.WriteLine(@$"
                        {Spaces}TU VIDA HA SIDO RESTAURADA POR 60 PUNTOS!
                                    {Spaces}PRESIONA 'ENTER'");
                Console.ReadLine();
                break;
            case "Hiperpoción":
                if (playerOne)
                {
                    switch (playerOnePokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 100);
                            break;
                        case "Charizard":
                            Heal(Charizard, 100);
                            break;
                    }
                }
                else
                {

                    switch (playerTwoPokemon)
                    {
                        case "Pikachu":
                            Heal(Pikachu, 100);
                            break;
                        case "Charizard":
                            Heal(Charizard, 100);
                            break;
                    }
                }
                Console.WriteLine(@$"
                        {Spaces}TU VIDA HA SIDO RESTAURADA POR 100 PUNTOS!
                                    {Spaces}PRESIONA 'ENTER'");
                Console.ReadLine();
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

    static void AtaquePikachu()
    {
        string[] framesPikachu =
        {
                " \r\n                    MMMMM                           MMMMM                                                                                                  MM\r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM                                                                                                 MMMM      M              MMMMMM\r\n                     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                          MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,MMMMMMMMMMM            MMM,,,,,,,,,MMMM\r\n     NNNNNNNNN            MMM   MMMMMMMMMMMMM   MMM                                                                                                  MM,,,MMMMMMMMMMMMM            MM,,,,,,,,,,,,,MMMM\r\n      NNNNNNNNNNNNN      MMMM   MMMMMMMMMMMMM   MMMM                                                                                                 MM,,MMMMMMM  MMMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n       NNNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MM,,,,MMMMM  MMMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n        NNNNNNNNNNNNNNN MMM  MMMMMMMMMMMMMMMMMM  MMM                                                                                               MMM,,MMMMMMMMMMMMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                                                                                               MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                  MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                   MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                                                                                       MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                             MMMMMMMMM            MMMMMMM\r\n                         MMMMMM               MMMMM                                                                                                         MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "\r\n                    MMMM                              MMMMMM                                                                                               MM\r\n                     MMMMMMMMM     MMMMMMMMMMMM    MMMMMMM                                                                                                MMMM      M              MMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                            MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                  MMM,,MMMMMMMMMMM            MMM,,,,,,,,,MMMM\r\n                      MMMM  MMMM  MMMMMMMMMMMMMM  MMM                                                                                                MM,,,MMMMMMMMMMMMM            MM,,,,,,,,,,,,,MMMM\r\n    NNNNNNNNN        MMMMM  MMMM   MMMMMMMMMMMM   MMM                                                                                                MM,,MMMMMMM  MMMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n     NNNNNNNNNNNNN   MMMMM MMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                              MM,,,,MMMMM  MMMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n      NNNNNNNNNNNNN  MMMMM MMMM  MMMMMMMMMMMMMMMMMM  MM                                                                                            MMM,,MMMMMMMMMMMMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n       NNNNNNNNNNNNN  NNMMMMMMM  MMMMMM      MMMMMM  MM                                                                                            MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                NNNNN  NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                              M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN  MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                          MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n                NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                      MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n               NNNNNN      MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                        M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n              NNNNNN       MMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n             NNNNNNN       MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                        MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n             NNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                 NNNNNNNMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                     MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                  NNNNNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                   NNNNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                        MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                       NMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMM                MMMMM                                                                                                         MMMMMMMMM            MMMMMMM\r\n                         MMM                     MMM                                                                                                        MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "\r\n              MMM                               MMMMM                                                                                                      MM\r\n              MMMMMM           MMMMMMMMMMMM   MMMMMM                                                                                                      MMMM      M              MMMMMM\r\n                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                 MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                       MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                     MMMMMMMM  MMMMMMMMMMMMMM  MMM                                                                                                    MMM,,MMMMMMMMMMM            MMM,,,,,,,,,MMMM\r\n                        MMMMM    MMMMMMMMMMM   MMMM                                                                                                  MM,,,MMMMMMMMMMMMM            MM,,,,,,,,,,,,,MMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMM   MMM                                                                                            MM,,MMMMMMM  MMMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n        NNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMM  MMMMMMM                                                                                           MM,,,,MMMMM  MMMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n         NNNNNNNNM M M MMMMM  MMMMMMMM     MMMMM  MMMMMMM                                                                                          MMM,,MMMMMMMMMMMMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n          NNNNNNN MMMMM MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                           MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n           NNNNNNN NMMMM MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                             M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                  N MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                              MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n                    N MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n                     N MMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                   M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n                    NNN MMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n                   NNNNN MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                 NNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                  NNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                     NN MM M M MMMMMMMMMMMMMMMMMMMMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                       MMM MMMM MMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMM MMMM MMMMMMMMMMMMMMMMMMMM                                                                                                        MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMM MMM MMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                          MMM MM MM      MMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                             MMMM           MMMMMM                                                                                                            MMMMMMMMM            MMMMMMM\r\n                                             MMMM                                                                                                           MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "\r\n              MMM                               MMMMM                                                                                               *      MM   *      *    \r\n              MMMMMM           MMMMMMMMMMMM   MMMMMM                                                                                                      MMMM      M              MMMMMM\r\n                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                         .;  .                                 *   *  MMM,,,MM * MMM  *  *      MM,,,,,,MMMM\r\n                 MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                .  :....';;.' .                                        MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                     MMMMMMMM  MMMMMMMMMMMMMM  MMM                                    .  ;,,'..';;. .,'','.   ';,'';;                                 MMM,,MMMMMMMMMMM    *       MMM,,,,,,,,,MMMM\r\n                        MMMMM    MMMMMMMMMMM   MMMM                                    ' . .'''..                  ,..                            *  MM,,,MMMMM    MMMM            MM,,,,,,,,,,,,,MMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMM   MMM                           ..':,                    MMMMMMNMM                               MM,,MMMMMM XX MMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n        NNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMM  MMMMMMM                           ';   ''         MMMMMMMM MM MMM MM                              MM,,,,MMMM XX MMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n         NNNNNNNNM M M MMMMM  MMMMMMMM     MMMMM  MMMMMMM                          .;,     MMMMMMMM MM    MM MM  M  MM                             MMM,,MMMMMM    MMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n          NNNNNNN MMMMM MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                           MMMMMM  MM    MM MM    MM MM     MM                             MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n           NNNNNNN NMMMM MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                            MM    M MM    MM MM    MM MM     MM .                            M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                  N MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                             MMMMMM  MM    MM MMMMMMM          ;,                             MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n                    N MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                              MM    M  MMMMMMM                 ;,                               MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n                     N MMMMMMMMMMMMMMMMMMMMMMMMMMMMM                               MMMMMM                     .. ,,,,                                  M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n                    NNN MMMMMMMMMMMMMMMMMMMMMMMMMMM                                 ;.,,.                 .;,.  .;'                                           MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n                   NNNNN MMMMMMMMMMMMMMMMMMMMMMMMMM                                   .:    .,   .   ..    . '                                              MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                 NNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMM                                  ...,,, .',,'',,,' :                                                 MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                  NNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                     NN MM M M MMMMMMMMMMMMMMMMMMMMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                       MMM MMMM MMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMM MMMM MMMMMMMMMMMMMMMMMMMM                                                                                                        MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMM MMM MMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                          MMM MM MM      MMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                             MMMM           MMMMMM                                                                                                            MMMMMMMMM            MMMMMMM\r\n                                             MMMM                                                                                                           MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "                                                                                                                                                          *               *                     \r\n                    MMMMM                           MMMMM                                                                                      *           MM    *                          \r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM                                                                                                 MMMM      M              MMMMMM\r\n                     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                              *  MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,,MM   MMM     *      MM,,,,,,MMMM\r\n                          MMMMMMMMMMMMMMMMMMMMMMMM                                                                                              *     MMM,,MMMMMMMMMMM            MMM,,,,,,,,,MMMM\r\n     NNNNNNNNN            MMM   MMMMMMMMMMMMM   MMM                                                                                                  MM,,,MMMMM    MMMM            MM,,,,,,,,,,,,,MMMM\r\n      NNNNNNNNNNNNN      MMMM   MMMMMMMMMMMMM   MMMM                                                                                                 MM,,MMMMMM  X MMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n       NNNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MM,,,,MMMM X  MMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n        NNNNNNNNNNNNNNN MMM  MMMMMMMMMMMMMMMMMM  MMM                                                                                               MMM,,MMMMMM    MMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                                                                                               MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                  MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                   MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                                                                                       MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                             MMMMMMMMM            MMMMMMM\r\n                         MMMMMM               MMMMM                                                                                                         MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''"
            };

        for (int j = 0; j < framesPikachu.Length; j++)
        {
            Console.Clear();
            Console.WriteLine(framesPikachu[j]);
            if (j == 3) Thread.Sleep(900);
            Thread.Sleep(700);
        };
        Console.WriteLine(@$"
                
                                                                                            EL ATAQUE ES EFECTIVO!
                                                                                                PRESIONE 'ENTER'");
        Console.ReadLine();
        Console.Clear();
    }
    static void AtaqueCharizard()
    {
        string[] frameCharizard =
        {
                " \r\n                    MMMMM                           MMMMM                                                                                                  MM\r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM                                                                                                 MMMM      M              MMMMMM\r\n                     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                          MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,MMMMMMMMMMM            MMM,,,,,,,,,MMMM\r\n     NNNNNNNNN            MMM   MMMMMMMMMMMMM   MMM                                                                                                  MM,,,MMMMMMMMMMMMM            MM,,,,,,,,,,,,,MMMM\r\n      NNNNNNNNNNNNN      MMMM   MMMMMMMMMMMMM   MMMM                                                                                                 MM,,MMMMMMM  MMMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n       NNNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MM,,,,MMMMM  MMMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n        NNNNNNNNNNNNNNN MMM  MMMMMMMMMMMMMMMMMM  MMM                                                                                               MMM,,MMMMMMMMMMMMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                                                                                               MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                  MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                   MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                                                                                       MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                             MMMMMMMMM            MMMMMMM\r\n                         MMMMMM               MMMMM                                                                                                         MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "\r\n                    MMMMM                           MMMMM                                                                                                             M    M         MMMM   \r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM                                                                                                            MM   MMM          MM,MM\r\n                     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          M  MMMMMMMMM           MM,,MM \r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                            MM MMMM   MMMM          MM,,,,MM   \r\n                          MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MM,MMMMMM   MMMMM          MMM,,,,,MM\r\n     NNNNNNNNN            MMM   MMMMMMMMMMMMM   MMM                                                                                                        MM,,,MMMMMMMMMMMMMMM         MM,,,,,,,MMM \r\n      NNNNNNNNNNNNN      MMMM   MMMMMMMMMMMMM   MMMM                                                                                                     MMM,,,,MMMMMMMMMMMMMMM       MMMM,,,,,,,,,MMM \r\n       NNNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                   MMMM,,,,,MM      MMMMMMMMM  MMMMMM,,,,,,,,,,,,,MMM\r\n        NNNNNNNNNNNNNNN MMM  MMMMMMMMMMMMMMMMMM  MMM                                                                                                 MMMM,,,,,,,    MMM MMMMMMMMMMMMMMMM,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                                                                                                MMM,,,,,,,,    MM    MMMMMMMMMMMMMM,,,,MM,,,,,,,,,,,,MMM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MMM,,,,,MMMM       MMMMMMMMMMMMMMMM,,,,MMMM,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MMM,,,,,MM  MMMM   MMMMMMMMMMMMMMMMMMMMMMMM,,,,,,   ,,,,MM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                M,,         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM  MMMMM     ,MM\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                               M,              MMMMMMMMMMMMMMMMMMMMMMMMM    MMMMMM     M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                                MMMMMMMMMMMMMMMMMMMMM      MMMMMMM     \r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                                                                                              MMMMMMMMMMMMMMMMMMMMMMM    MMMMMMMM    \r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                              MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM \r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                              MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM \r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                            MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM  \r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM \r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM    \r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                            MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM \r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                              MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                               MMMMMMMMM                MMMMMM  \r\n                         MMMMMM               MMMMM                                                                                                            MMMMMMMMM                 MMMMMMM \r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "\r\n                    MMMMM                           MMMMM                                                                                                             MMM                MMMM \r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM                                                                                                        MMMMMMM                  M,,,MM\r\n                     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                      MMMM,,,,,MM                  MM,,,,MMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                       MMM,,,,,,,,MM  M                M,,,,,,MMMM\r\n                          MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                       MM,,,,,,,,MM,,MMMM                MMM,,,,,,,,MM\r\n     NNNNNNNNN            MMM   MMMMMMMMMMMMM   MMM                                                                                                    MMM,,,,,,,MMMMMMMMM                 MM,,,,,,,,,,,MM\r\n      NNNNNNNNNNNNN      MMMM   MMMMMMMMMMMMM   MMMM                                                                                                  MM,,,,,,,, MMMMM  MMMMMM             MMM,,,,,,,,,,,MM\r\n       NNNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 MM,,,,,,,,M MMMM   MMMMMMNMMM        MMMM,,,,,,,,,,,,MM\r\n        NNNNNNNNNNNNNNN MMM  MMMMMMMMMMMMMMMMMM  MMM                                                                                                MM,,,,,,,,,MMMMMMMMMMMMMMMMMMMMM    MMMMMM,,,,,,,,,,,,,MM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                                                                                               MM,,,,,,,,,MMMMMM.MMMMMMMMMMMMMMMMMMMMMMMMM,,,,,,,,,,,,,,MM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                               MMM,,,,,,,,M'  ...MM  MMMMMMMMMMM MMMMMM,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MM,,,,,,,    .MMMMM    MMMMMMMMMM MMMMMM,,,,,,,,,,,,,,,,,,,MM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                MM,,,,                MMMMMMMMMMMM MMM MM,,,,,,,,,,,,,,,,,,,M\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                M,,       MMMMM    MMMMMMMMMMMMMM MM MMMMM,,     ,, MMMM ,,M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                               M,        MM MMMMMMMMMMMMMMM MMM MM MMMMMM         MMMMMM\r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                                                                                             MMMMM  MMMMM MMM MM MMMMMMMM       MMMMMMMM\r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                                  MMMMMMMMMMMMMMMMMMMMMMMMM    MMMMMMMMMM\r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                               MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                              MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                               MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                                 MMMMMMMMMMM       MMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                                  MMMMMMMMM           MMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                                    MMMMMMMM            MMMMMMMM\r\n                         MMMMMM               MMMMM                                                                                                                 MMMMMMMM             MMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "\r\n             *      MMMMM   *           *       *   MMMMM                                                                                                             MMM                MMMM \r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM    *                                                                                                   MMMMMMM                  M,,,MM\r\n               *  *  MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM *                                                  .;  .                                             MMMM,,,,,MM                  MM,,,,MMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM       *                                     .  :....';;.' .                                           MMM,,,,,,,,MM  M                M,,,,,,MMMM\r\n                          MM     MMMMMMMMMMM     M     *                              .  ;,,'..';;. .,'','.   ';,'';;                                    MM,,,,,,,,MM,,MMMM                MMM,,,,,,,,MM\r\n     NNNNNNNNN            MM   X MMMMMMMMMMM X   MM                                    ' . .'''..                  ,..                                 MMM,,,,,,,MMMMMMMMM                 MM,,,,,,,,,,,MM\r\n      NNNNNNNNNNNNN      MMM X   MMMMMMMMMMM   X MMM                                ..':,                    MMMMMMNMM                                MM,,,,,,,, MMMMM  MMMMMM             MMM,,,,,,,,,,,MM\r\n       NNNNNNNNNNNNNNNN MMMM     MMMMMMMMMMM     MMM                                ';   ''         MMMMMMMM MM MMM MM                               MM,,,,,,,,M MMMM   MMMMMMNMMM        MMMM,,,,,,,,,,,,MM\r\n        NNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                               .;,     MMMMMMMM MM    MM MM  M  MM                              MM,,,,,,,,,MMMMMMMMMMMMMMMMMMMMM    MMMMMM,,,,,,,,,,,,,MM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                               MMMMMM  MM    MM MM    MM MM     MM                             MM,,,,,,,,,MMMMMM.MMMMMMMMMMMMMMMMMMMMMMMMM,,,,,,,,,,,,,,MM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                MM    M MM    MM MM    MM MM     MM .                          MMM,,,,,,,,M'  ...MM  MMMMMMMMMMM MMMMMM,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                 MMMMMM  MM    MM MMMMMMM          ;,                           MM,,,,,,,    .MMMMM    MMMMMMMMMM MMMMMM,,,,,,,,,,,,,,,,,,,MM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                 MM    M  MMMMMMM                 ;,                            MM,,,,                MMMMMMMMMMMM MMM MM,,,,,,,,,,,,,,,,,,,M\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                MMMMMM                     .. ,,,,                              M,,       MMMMM    MMMMMMMMMMMMMM MM MMMMM,,     ,, MMMM ,,M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                ;.,,.                 .;,.  .;'                                M,        MM MMMMMMMMMMMMMMM MMM MM MMMMMM         MMMMMM\r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                 .:    .,   .   ..    . '                                                    MMMMM  MMMMM MMM MM MMMMMMMM       MMMMMMMM\r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                 ...,,, .',,'',,,' :                                                              MMMMMMMMMMMMMMMMMMMMMMMMM    MMMMMMMMMM\r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                               MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                              MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                               MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                                 MMMMMMMMMMM       MMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                                  MMMMMMMMM           MMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                                    MMMMMMMM            MMMMMMMM\r\n                         MMMMMM               MMMMM                                                                                                                 MMMMMMMM             MMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''",
                "                      *                                 *\r\n            *       MMMMM    *       *          *   MMMMM                                                                                                  MM\r\n                    MMMMMMM    MMMMMMMMMMMMMMM    MMMMMMM                                                                                                 MMMM      M              MMMMMM\r\n                     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM     *                                                                                           MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                *       MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    MMM,,,MM   MMM            MM,,,,,,MMMM\r\n                      *   MM     MMMMMMMMMMM     M    *     *                                                                                         MMM,,MMMMMMMMMMM            MMM,,,,,,,,,MMMM\r\n     NNNNNNNNN            MM XXX MMMMMMMMMMM XXX MM                                                                                                  MM,,,MMMMMMMMMMMMM            MM,,,,,,,,,,,,,MMMM\r\n      NNNNNNNNNNNNN      MMM XXX MMMMMMMMMMM XXX MMM                                                                                                 MM,,MMMMMMM  MMMMMM          MMM,,,,,,,,,,,,,,,,MMMM\r\n       NNNNNNNNNNNNNNNN MMMM     MMMMMMMMMMM     MMM                                                                                                MM,,,,MMMMM  MMMMMMMMM       MMM,,,,,,,,,,,,,,,,,,,,MMM\r\n        NNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                               MMM,,MMMMMMMMMMMMMMMMMMMM    MMM,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN  MM  MMMMMM       MMMMM  MMM                                                                                               MM,,,MMMMMMMMMMMMMMMMMMMMMM  MM,,,,,,,,,,,,,,,,,,,,,,,,MMM\r\n                 NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                 M,,,,,MMMMM     MMMMMMMMMMMMM,,,,,,,,,,,,,,,,,,,,,,,,,MM\r\n                NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                  MM,,,          MMMMMMMMMMMMMMM,,,,    ,,MMMMM,,,    ,,MMM\r\n               NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM                                                                                                   MM,          MMMMMMMMMMMM MMMMM        MMMMMM        ,MM\r\n              NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                    M         MMMMMMMMMMMMMM MMMMMM      MMMMMMM         M\r\n             NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMM MMMM MM   MMMMMMMM\r\n              NNNNNNNNNNMM MMMMM MMMMMMMMMMM MMMMM MM                                                                                                       MMMMMMMMMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                  NNNNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMMMM  MMMMMMMMMMMMMM MMMM MMMMMMMMMMMM\r\n                    NNNNMMM MMM MMMMMMMMMMMMM MMM MMM                                                                                                     MMMM   MMMMMMMMMMMMMM MMMMM MMMMMMMMMMM\r\n                       MMMMM M MMMMMMMMMMMMMMM M MMMM                                                                                                     MM   MMMMMMMMMMMMMMMMM M M MMMMMMMMM\r\n                       MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                         MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                         MMMMMMMMMMMMMMMMMMMMMMMMMM                                                                                                          MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMMM                                                                                                           MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\r\n                           MMMMMMMMMMMMMMMMMMMMMM                                                                                                             MMMMMMMMM            MMMMMMM\r\n                         MMMMMM               MMMMM                                                                                                         MMMMMMMMMMMM           MMMMMMMMM\r\n'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''"
            };

        for (int j = 0; j < frameCharizard.Length; j++)
        {
            Console.Clear();
            Console.WriteLine(frameCharizard[j]);
            if (j == 3) Thread.Sleep(900);
            Thread.Sleep(700);
        };
        Console.WriteLine(@$"
                
                                                                                            EL ATAQUE ES EFECTIVO!
                                                                                                PRESIONE 'ENTER'");
        Console.ReadLine();
        Console.Clear();
        Console.Clear();
    }


    public void Run(string playerOnePokemon, string playerTwoPokemon)
    {
        bool running = true;
        bool playerOne = true;

        while (running && PlayersPokemons["First Player Pokemon"].inGameStats["HP"] > 0 && PlayersPokemons["Second Player Pokemon"].inGameStats["HP"] > 0)
        {
            switch (GameMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
            {
                case 0:
                    if (playerOne)
                    {
                        switch (playerOnePokemon)
                        {
                            case "Pikachu":
                                switch (pikachuAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
                                {
                                    case 0:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA LÁTIGO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, latigo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, ATAQUE RÁPIDO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, ataqueRapido.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA IMPACTRUENO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, impactrueno.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA BOLA VOLTIO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, bolaVoltio.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA ONDA TRUENO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, ondaTrueno.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA AMAGO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, amago.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        break;
                                }
                                break;
                            case "Charizard":
                                switch (charizardAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
                                {
                                    case 0:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ATAQUE ALA!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Attack"], Pikachu, ataqueAla.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA TAJO AEREO!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, tajoAereo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ARANAZO!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Attack"], Pikachu, aranazo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ENVISTE IGNEO!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, envisteIgneo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ONDA IGNEA!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, ondaIgnea.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ASCUAS!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, ascuas.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA GARRA DRAGÓN!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, garraDragon.MoveType);
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
                                switch (pikachuAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
                                {
                                    case 0:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA LÁTIGO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, latigo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, ATAQUE RÁPIDO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, ataqueRapido.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA IMPACTRUENO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, impactrueno.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA BOLA VOLTIO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, bolaVoltio.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA ONDA TRUENO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, ondaTrueno.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        Console.WriteLine(@$"
                                {Spaces}PIKACHU, USA AMAGO!");
                                        Thread.Sleep(2000);
                                        AtaquePikachu();
                                        decreaseHP(Pikachu.inGameStats["Attack"], Charizard, amago.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        break;
                                }
                                break;
                            case "Charizard":
                                switch (charizardAttackMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
                                {
                                    case 0:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ATAQUE ALA!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Attack"], Pikachu, ataqueAla.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 1:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA TAJO AEREO!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, tajoAereo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 2:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ARANAZO!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Attack"], Pikachu, aranazo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 3:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ENVISTE IGNEO!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, envisteIgneo.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 4:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ONDA IGNEA!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, ondaIgnea.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 5:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA ASCUAS!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, ascuas.MoveType);
                                        playerOne = !playerOne;
                                        break;
                                    case 6:
                                        Console.WriteLine(@$"
                                {Spaces}CHARIZARD, USA GARRA DRAGÓN!");
                                        Thread.Sleep(2000);
                                        AtaqueCharizard();
                                        decreaseHP(Charizard.inGameStats["Sp. Attack"], Pikachu, garraDragon.MoveType);
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
                    if (playerOne == true)
                    {

                        switch (PlayerOneBagMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
                        {
                            case 0:
                                itemsFunctionality(PlayerOneBagMenu.Options[0], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerOneBagMenu.Options[0] = "-";
                                playerOne = !playerOne;
                                break;
                            case 1:
                                itemsFunctionality(PlayerOneBagMenu.Options[1], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerOneBagMenu.Options[1] = "-";
                                playerOne = !playerOne;
                                break;
                            case 2:
                                itemsFunctionality(PlayerOneBagMenu.Options[2], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerOneBagMenu.Options[2] = "-";
                                playerOne = !playerOne;
                                break;
                            case 3:
                                itemsFunctionality(PlayerOneBagMenu.Options[3], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerOneBagMenu.Options[3] = "-";
                                playerOne = !playerOne;
                                break;
                            case 4:
                                itemsFunctionality(PlayerOneBagMenu.Options[4], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerOneBagMenu.Options[4] = "-";
                                playerOne = !playerOne;
                                break;
                            case 5:
                                itemsFunctionality(PlayerOneBagMenu.Options[5], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerOneBagMenu.Options[5] = "-";
                                playerOne = !playerOne;
                                break;
                            case 6:
                                break;

                        }
                    }
                    else
                    {
                        switch (PlayerTwoBagMenu.Run(playerTwoPokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]))
                        {
                            case 0:
                                itemsFunctionality(PlayerTwoBagMenu.Options[0], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerTwoBagMenu.Options[0] = "-";
                                playerOne = !playerOne;
                                break;
                            case 1:
                                itemsFunctionality(PlayerTwoBagMenu.Options[1], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerTwoBagMenu.Options[1] = "-";
                                playerOne = !playerOne;
                                break;
                            case 2:
                                itemsFunctionality(PlayerTwoBagMenu.Options[2], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerTwoBagMenu.Options[2] = "-";
                                playerOne = !playerOne;
                                break;
                            case 3:
                                itemsFunctionality(PlayerTwoBagMenu.Options[3], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerTwoBagMenu.Options[3] = "-";
                                playerOne = !playerOne;
                                break;
                            case 4:
                                itemsFunctionality(PlayerTwoBagMenu.Options[4], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerTwoBagMenu.Options[4] = "-";
                                playerOne = !playerOne;
                                break;
                            case 5:
                                itemsFunctionality(PlayerTwoBagMenu.Options[5], playerOnePokemon, playerTwoPokemon, playerOne);
                                PlayerTwoBagMenu.Options[5] = "-";
                                playerOne = !playerOne;
                                break;
                            case 6:
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

                                PikachuInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
                                break;

                            case "Charizard":

                                CharizardInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
                                break;
                        }
                    }
                    else
                    {
                        switch (playerTwoPokemon)
                        {
                            case "Pikachu":
                                PikachuInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
                                break;
                            case "Charizard":
                                CharizardInfoMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
                                break;
                        }
                    }
                    break;
                case 3:
                    cantFleeMenu.Run(playerOnePokemon, playerTwoPokemon, playerOne, PlayersPokemons["First Player Pokemon"].inGameStats["HP"], PlayersPokemons["Second Player Pokemon"].inGameStats["HP"]);
                    break;

            }
        }
        Console.WriteLine(@"
                            
                                                                                                                            GAME OVER!
                                                                                                                            
                                                                                                                            
                                                                                                                            ");
        if (PlayersPokemons["First Player Pokemon"].inGameStats["HP"] > PlayersPokemons["Second Player Pokemon"].inGameStats["HP"])
        {
            Console.WriteLine($"                                                                                            {PlayersPokemons["First Player Pokemon"].Name} HA GANADO!");
        }
        else
        {

            Console.WriteLine($"                                                                                            {PlayersPokemons["Second Player Pokemon"].Name} HA GANADO!");
        }

        Console.ReadLine();
        return;
    }

}
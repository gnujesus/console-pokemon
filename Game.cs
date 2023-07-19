class Game
{
    private Menu GameMenu;
    private Pokemon Pikachu;
    private Pokemon Charizard;

    private string[] Items;

    private string ItemsFile;

    private Bag PlayerOneBag;
    private Bag PlayerTwoBag;
    private string FirstPlayerPokemon;
    private string SecondPlayerPokemon;



    public Game(string firstPlayerPokemon, string secondPlayerPokemon)
    {
        Pikachu = new Pokemon("Pikachu", "Electric", 25, statistics(35, 55, 40, 50, 50, 90), individualValues(), effortValues());
        Charizard = new Pokemon("Pikachu", "Electric", 25, statistics(78, 84, 78, 109, 85, 100), individualValues(), effortValues());

        ItemsFile = @"assets/items.txt";
        Items = File.ReadAllLines(ItemsFile);

        PlayerOneBag = new Bag(GetRandomElements(Items));
        PlayerTwoBag = new Bag(GetRandomElements(Items));

        FirstPlayerPokemon = firstPlayerPokemon;
        SecondPlayerPokemon = secondPlayerPokemon;
    }

    public Dictionary<string, int> statistics(int HP, int Attack, int Defense, int SpAttack, int SpDefense, int Speed)
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

    public Dictionary<string, int> individualValues()
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
    public Dictionary<string, int> effortValues()
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

    public string[] GetRandomElements(string[] array)
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
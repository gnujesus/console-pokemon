
class Pokemon
{
    private string Name;
    private Dictionary<string, int> BaseStats;
    private Dictionary<string, int> EVs;
    private Dictionary<string, int> IVs;
    public Dictionary<string, int> inGameStats;
    private int Level;
    private int Nature;
    private Random rnd;
    private string Type;


    public Pokemon(string name, string type, int level, Dictionary<string, int> stats, Dictionary<string, int> ivs, Dictionary<string, int> evs)
    {
        Name = name;
        Level = level;
        BaseStats = stats;
        EVs = evs;
        IVs = ivs;
        rnd = new Random();
        Nature = rnd.Next(1, 13);
        Type = type;
        inGameStats = new Dictionary<string, int> { };

        inGameStats.Add("HP", 0);
        inGameStats.Add("Attack", 0);
        inGameStats.Add("Defense", 0);
        inGameStats.Add("Sp. Attack", 0);
        inGameStats.Add("Sp. Defense", 0);
        inGameStats.Add("Speed", 0);
    }

    private void calculateInGameStats()
    {
        foreach (string value in inGameStats.Keys)
        {
            if (value == "HP")
            {
                inGameStats["HP"] = (((2 * BaseStats["HP"] + IVs["HP"] + (EVs["HP"] / 4) * Level)) / 100) + Level + 10;
            }
            else
            {
                inGameStats[value] = ((((2 * BaseStats[value] + IVs[value] + (EVs[value] / 4) * Level)) / 100) + 5) * Nature;
            }
        }
    }

    public string returnInfo()
    {
        string info = @$"
                                                                                    HP:          {inGameStats["HP"]} 
                                                                                    Attack:      {inGameStats["Attack"]} 
                                                                                    Defense:     {inGameStats["Defense"]} 
                                                                                    Sp. Attack:  {inGameStats["Sp. Attack"]} 
                                                                                    Sp. Defense: {inGameStats["Sp. Defense"]} 
                                                                                    Speed:       {inGameStats["Speed"]} 
        ";

        return info;
    }

}

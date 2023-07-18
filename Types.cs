
class Types
{
    private double[] Multipliers;
    public Dictionary<string, Array> PokemonTypes;

    public Types()
    {
        Multipliers = new double[] { 0.5, 1, 1.5, 2, 4 };
        PokemonTypes = new Dictionary<string, Array> { };
        PokemonTypes.Add("Fire", Multipliers);
        PokemonTypes.Add("Electric", Multipliers);
        PokemonTypes.Add("Normal", Multipliers);
        PokemonTypes.Add("Steel", Multipliers);
        PokemonTypes.Add("Fight", Multipliers);
        PokemonTypes.Add("Poison", Multipliers);
        PokemonTypes.Add("Flying", Multipliers);
    }
}
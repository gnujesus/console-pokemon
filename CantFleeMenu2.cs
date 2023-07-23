class CantFleeMenu : FightMenu
{
    public CantFleeMenu(string[] options, string prompt, int firstPokemonBaseHP, int secondPokemonBaseHP)
    : base(options, prompt, firstPokemonBaseHP, secondPokemonBaseHP)
    {

    }
    protected override void DisplayOptions(string playerOnePokemon, int playerOnePokemonCurrentHP, int playerTwoPokemonCurrentHP)
    {
        Console.Clear();
        ConsoleColor foregroundColor = ConsoleColor.White;
        ConsoleColor optionForegroundColor = ConsoleColor.Green;
        Console.ForegroundColor = foregroundColor;
        Console.Write(PokemonsAscii);
        Console.ResetColor();

        string spaces2 = @"                                ";
        Console.Write(spaces2);
        Console.Write($"{playerOnePokemonCurrentHP}/{FirstPokemonBaseHP}");
        string spaces3 = @"                                                                                                                       ";
        Console.Write(spaces3);
        Console.Write($"{playerTwoPokemonCurrentHP}/{SecondPokemonBaseHP}");

        Console.WriteLine(@$"                                               
                                                                                                {Prompt}


                                                                                                 {playerOnePokemon.ToUpper()}


            ");





        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;

            if (i == SelectedIndex)
            {
                prefix = "» ";

                ConsoleColor backgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = optionForegroundColor;
                // Console.BackgroundColor = backgroundColor;

            }
            else
            {
                prefix = "  ";
                Console.ResetColor();
            }

            // Since is only one option, it can be set before-hand
            Console.SetCursorPosition(93, 44);
            Console.Write($"{prefix} {currentOption.ToUpper()}   ");
        }
        Console.ResetColor();
    }
}
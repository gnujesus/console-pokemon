class FightMenu
{
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;
    private bool EnterWasPressed;
    private string[] YesOrNo;
    private string[] SiONo;
    private string pokemonsAscii;

    public FightMenu(string[] options, string prompt)
    {
        Console.CursorVisible = false;

        Options = options;
        Prompt = prompt;
        SelectedIndex = 0;
        EnterWasPressed = false;
        YesOrNo = new string[] { "Yes", "No" };
        SiONo = new string[] { "Sí", "No" };
        pokemonsAscii = @"
                                                      
               MM                                MMM 
               MMMMM                          MMMMMM
               MMMMMMMM   MMMMMMMMMMMMMMM  MMMMMMMM
                MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
                   MMMMMMMMMMMMMMMMMMMMMMMMMMMM
                     MMMMMMMMMMMMMMMMMMMMMMMM
NNNNNNNNN            MMM   MMMMMMMMMMMMM   MMM
NNNNNNNNNNNNNN      MMMM   MMMMMMMMMMMMM   MMMM
NNNNNNNNNNNNNNNNNN MMMMMMMMMMMMMMMMMMMMMMMMMMMM
NNNNNNNNNNNNNNNNNN MMM  MMMMMMMMMMMMMMMMMM  MMM
            NNNNNN  MM  MMMMMM       MMMMM  MMM
            NNNNNN   MMMMMMMMMMMMMMMMMMMMMMMMM
           NNNNNN    MMMMMMMMMMMMMMMMMMMMMMMM
          NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMM
         NNNNNN     MMMMMMMMMMMMMMMMMMMMMMMMMM
        NNNNNNN    MMMMMMMMMMMMMMMMMMMMMMMMMMMM
         NNNNNNNNNNMMM.MMM.MMMMMMMMMMMMM.MMM.MMM
             NNNNNNMMM.MMM.MMMMMMMMMMMMM.MMM.MMM
               NNNNMMM.MMM.MMMMMMMMMMMMM.MMM.MMM
                  MMMMM...MMMMMMMMMMMMMMM...MMMM
                  MMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
                   MMMMMMMMMMMMMMMMMMMMMMMMMMMM
                    MMMMMMMMMMMMMMMMMMMMMMMMMM
                      MMMMMMMMMMMMMMMMMMMMMMM
                      MMMMMMMMMMMMMMMMMMMMMM
                    MMMMMM               MMMMM
                                                               
        ";

    }

    private void DisplayOptions()
    {
        Console.Clear();
        ConsoleColor foregroundColor = ConsoleColor.Cyan;
        ConsoleColor optionForegroundColor = ConsoleColor.Green;
        Console.ForegroundColor = foregroundColor;
        Console.Write(pokemonsAscii);
        Console.ResetColor();
        Console.WriteLine(@$"                                               
                                                                {Prompt}
            
            
            ");

        string spaces = @"                                               ";
        Console.Write(spaces);

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

            Console.Write($"{prefix} {currentOption.ToUpper()}   ");
        }
        Console.ResetColor();
    }

    public void HandleKeyboard(ConsoleKeyInfo key)
    {
        EnterWasPressed = false;
        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
                if (SelectedIndex == Options.Length - 1)
                {
                    break;
                }
                else
                {
                    SelectedIndex++;
                    break;
                }

            case ConsoleKey.RightArrow:
                if (SelectedIndex == Options.Length - 1)
                {
                    break;
                }
                else
                {
                    SelectedIndex++;
                    break;
                }

            case ConsoleKey.UpArrow:
                if (SelectedIndex == 0)
                {
                    break;
                }
                else
                {
                    SelectedIndex--;
                    break;
                }

            case ConsoleKey.LeftArrow:
                if (SelectedIndex == 0)
                {
                    break;
                }
                else
                {
                    SelectedIndex--;
                    break;
                }

            case ConsoleKey.Enter:
                EnterWasPressed = true;
                break;
        }
    }

    public int Run(string firstPlayerPokemon)
    {
        ConsoleKeyInfo pressedKey;

        while (true)
        {

            DisplayOptions();

            pressedKey = Console.ReadKey();

            HandleKeyboard(pressedKey);

            if (EnterWasPressed)
            {
                return SelectedIndex;
            }

        }

    }


    private void ResetVariables()
    {
        EnterWasPressed = false;
        SelectedIndex = 0;
    }

}

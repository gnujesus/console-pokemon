class Menu
{
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;
    private bool EnterWasPressed;
    private string[] YesOrNo;
    private string[] SiONo;
    private string welcomeAscii;

    public Menu(string[] options, string prompt)
    {
        Console.CursorVisible = false;

        Options = options;
        Prompt = prompt;
        SelectedIndex = 0;
        EnterWasPressed = false;
        YesOrNo = new string[] { "Yes", "No" };
        SiONo = new string[] { "Sí", "No" };
        welcomeAscii = @"



                                ██████   ██████  ██   ██ ███████ ███    ███  ██████  ███    ██ 
                                ██   ██ ██    ██ ██  ██  ██      ████  ████ ██    ██ ████   ██ 
                                ██████  ██    ██ █████   █████   ██ ████ ██ ██    ██ ██ ██  ██ 
                                ██      ██    ██ ██  ██  ██      ██  ██  ██ ██    ██ ██  ██ ██ 
                                ██       ██████  ██   ██ ███████ ██      ██  ██████  ██   ████ 

                                                               
        ";

    }

    private void DisplayOptions()
    {
        Console.Clear();
        ConsoleColor foregroundColor = ConsoleColor.Cyan;
        ConsoleColor optionForegroundColor = ConsoleColor.Green;
        Console.ForegroundColor = foregroundColor;
        Console.Write(welcomeAscii);
        Console.ResetColor();
        Console.WriteLine(@$"                                               {Prompt}
            
            
            ");

        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;
            string spaces = @"                                                       ";

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

            Console.WriteLine($"{spaces} {prefix} {currentOption.ToUpper()}");
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



            case ConsoleKey.Enter:
                EnterWasPressed = true;
                break;
        }
    }

    public int Run()
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

    public void changeLanguage(string[] newOptions, string newPrompt)
    {
        Options = newOptions;
        Prompt = newPrompt;
    }
}

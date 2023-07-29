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
                                                                                                           MMMM                                                                                                .,
                                                                                                          MMM                                                                                                  .,
                                                   MMMMMMMM                     MMMMM                                            MMMM                                                                          .,
                                             MMMMMMMMMMMMMMMMMM               MMMMMMM    MMMMM        MMMMMMMMM         MMMMMMM MMMMMM                                                                        .,
                                          MMMMMMMMMMMMMMMMMMMMMMM             MMMMMMMM MMMMMMMM    MMMMMMMMMMMMMMM     MMMMMMMM MMMMMM              MMMMMMMM                                                   .,
                                         MMMMMMMMMMMMMMMMMMMMMMMMM             MMMMMMMMMMMMMMMMM  MMMMM    MMMMMMM     MMMMMMMMMMMMMMMM              MMMMMMM     MMMMM                                         .,
                                          MMMMMMMMMMMMMM  MMMMMMMM             MMMMMMMMMMMMMMM   MMMM       MMMM       MMMMMMMMMMMMMMMM      MM      MMMMMMMM   MMMMMMM                                        .,
                                           MMMMMMMMMMMM     MMMMMM       MM    MMMMMMMMMMMMM    MMMMM     MMMMM       MMMMMMMMMMMMMMMMM  MMMMMMMMMM  MMMMMMMM  MMMMMMM                                         .,
                                              MMMMMMMMMM     MMMM    MMMMMMMMMM MMMMMMMMMM      MMMMMMMMMMMMM  MMM    MMMMMMMMMMMMMMMM MMMM  MMMMMMMM MMMMMMM  MMMMMM                                          .,
                                               MMMMMMMMM    MMMMM  MMM  MMMMMMMMM MMMMMMMMMMMM   MMMMMMMMMMMMMMMMMMM   MMMMMMMMMMMMMM MMMM   MMMMMMMMM MMMMMM MMMMMMM                                          .,
                                                MMMMMMMMMMMMMMM   MMMM  MMMMMMMMM MMMMMMMMMMMMMM  MMMMMMMMMMMMMMMMM   MMMMM  MMMMM  M MMMMM      MMMMM MMMMMMMMMMMMM                                           .,
                                                 MMMMMMMMMMMMM   MMMMM      MMMMM  MMMMMMMMMMMMMMMM MMMMMMMMMMMMM    MMMMMM   MMMM  M MMMMMMMMMMMMMMMMM MMMMMMMMMMMM                                           .,
                                                  MMMMMMMMMM     MMMMMMMMMMMMMMMM MMMMM   MMMMMMMMMM MMMMMMMMMMM     MMMMMM    MMM  MM MMMMMMMMMMMMMM MMMMMMMMMMMMM                                            .,
                                                   MMMMMMMM      MMMMMMMMMMMMMMMM MMMMM        MMMMMMMMMM             MMMM      MM  M MMMMMMMMMMMMMM MMMMMMMMMMMMM                                             .,
                                                    MMMMMMMM      MMMMMMMMMMMMM  MMMMMM            MMMMMMM                          MMMM MMMMMMMMM MMMMMMMMMMMMMM                                              .,
                                                     MMMMMMM       MMMMMMMMMM    MMMMMM                MM                           MMMM           MMMMM MMMMMMMM                                              .,
                                                      MMMMMMM                                                                                       MMMM MMMMMMM                                               .,
                                                      MMMMMMM                                                                                             MMMMM            l                                   .,
                                                       MMMMMM                                                                                             MM      MMMMMMMMMM                                   .,
                                                                                                                                                            MMMMMM,,,,,,,,,MM                                  .,
                                                                                                                                                          MM,,,,,,,,,,,,,,M,M  M                               .,
                                            M                                                                                                         MMMM,,,,,,,,,,,,,,,MM,M  MM                              .,
                                          MMMM                                                                                                       M,,,,,,,,,,,,,,,,,,MMM,M  MM                              .,
                                       MMMMMMMMMMM                          .......................................................                 M,,,,,,,,,,,,,,,,,,MMM,MM MMMM                             .,
                                     MMMMMMMMMMMMMMMMM                     .::...................................................'c'               M,,,,,,,,,,,,,,,,,,MMMMMMMMMMMMM           MM               .,
                                  MMMMMMMMMMMMMMMMMMMMMMM                  .;.                                                    ;'               M,,,,,,,,,,,,,,,,MMMMMMMMMMMMMMMMM          MM              .,
                                MMMMMMMMMMMMMMM                            .;.                                                    ;'              M,,,,,,,,,,,,,,,,MMMMMM  MMMMMMMMMMMM         MMM            .,
                              MMMMMMM           M                          .:.                                                    ;'              M,,,,,,,,,,,,MM MMMMMM  MMMMMMMMMMMMMM        MMMM           .,
                     M          MMMMMMM        MM                          .:.                                                    ;'              M,,,,,,MMMM MM MMMMMMMMMMMMMMMMMMMMMMM      MMMMMMM          .,
                     MM          MMMMMMM      MMM                          .:.                                                    ;'               M,,,,,,MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM MMMMM,,,MMMMM        .,
                     MMM       MMMMM         MMMM                          .:.                                                    ;'                M,,,,MM     MMMMMMMMMMM   MMMMMMMMMMMMM,,,,,,,MMMMMM       .,
                     MMMM         MMM       MMMMM                          .:.                                                    ;'                 M,,,M        MMMMMM     MMMMMMMMMMMMMMMM,,,,,MMMMMMM      .,
                      MMMM   MMMMMMMMMMMMMM MMMM                           .:.                                                    ;'                   M          MMMMM  MMMMMMMMMMMMMMMMMMMMMMMMM MMMMMMM     .,
                       MMM MMMMMMMMMMMMMMMMM MMM                           .:.                                                    ;'                           MMMMMMMMMMM  MM MMMMMMMMMMMMMMMMMMMM MMMMMM     .,
                       MMMM MMMMM,,,,,,,MM  MM MMMM                        .:.                                                    ;'                          MMMMMMMMMMM MMMMM MMMMMMMMMMMM     MMM MMMMMM    .,
                        MMMM MMM MMMMMMMMMM M MMMMMM                       .:.                                                    ;'                          MMMMMMMM MMMMMMM MMMMMMMMMMM       MMM MMMMMM    .,
                       M MMMM M MMMMMMMMMMM  M M MM MMM                    .:.                                                    ;'                   MMMMM MMMMMMM MMMMMMMM MMMMMMMMMMMM     MMMMM MMMMMMM   .,
                      MM M MM MMMMMMMMMMMMMMM MMMMMMMMMM                   .:.                                                    ;'              MMMMMMMMM MMMMMM MMMMMMMMM MMMMMMMMMMMMM       MMM MMMMMMM   .,
                     MMMM M M MMMMMMMMMMMMMMMMMMM MMMMMMMM                 .:.                                                    ;'           MMMMMMMMMM MMMMMMM MMMMMMMM MMMMMMMMMMMMMM        MMMMM MMMMM   .,
                     MMM M MMMMMM  MMMMMM  MMMMMM      MMM                 .:.                                                    ;'          MMMMMMMMMMM MMMMMMMM MMMMMM MMMMMM MMMM MMM       MM  MM MMMMM   .,
                     MMM M MMMMMM MMMMMMM MMMMMMMM                         .:.                                                    ;'         MMMMMMM      MMMM    MM MM MMMMMM MMMMMMM M            M MMMMMM   .,
                     MM MMM MMMMMMMMM MMMMMMMMMM                           .:.                                                    ;'        MMMMMM                    MMMMMM MMMMMMMMMMM             MMMMMM    .,
                         M MMM MMMMMMMMMMMMMM                              .:;...................................................'c'        MMMMM                       MMM MMMMMMMMMMMM             MMMMMM    .,
                          MMMM MMMMMMMMMMMM                                 .'......................................................         MMMM                        M MMMMMMMMMMMM              MMMMM     .,
                           MMMM   MMMMMM                                                                                                     MMMM                         MMMMMMMMMMMM                MMM      .,
                             MMM                                                                                                              MMMM                      MMMMMMMMMMMMM                 MM       .,
                                                                                                                                               MMM    MMM            MMMMMMMMMMMMMM                   MM       .,
                                                                                                                                                  MMMMMMMMMMMMMMM   MMMMMMMMMM                                 .,
                                                                                                                                                   MMMMMMMMMMMMM      MMMMMMM                                  .,                                                                                                                                              

        ";

    }

    private void DisplayOptions()
    {
        Console.Clear();
        ConsoleColor foregroundColor = ConsoleColor.Blue;
        ConsoleColor optionForegroundColor = ConsoleColor.Green;
        Console.ForegroundColor = foregroundColor;
        Console.Write(welcomeAscii);
        Console.ResetColor();
        Console.SetCursorPosition(95, 30);
        Console.WriteLine(Prompt);
        int y = 35;

        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;
            string spaces = @"                                                                                              ";

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
            Console.SetCursorPosition(97, y);
            Console.WriteLine($"{prefix} {currentOption.ToUpper()}");
            y += 2;
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

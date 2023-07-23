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
                                                                                         ....       ..',;lk0kdc;''..                                                                                           .,
                                                  ............                    .......'''...    .''':ool:,''...    ..............'....          .                                                           .,
                                             ...';:clllllcc;,'...           ..':lodxo;'''';:,'...  .'''''''''''........';::::;,';oxxd:''.       ..''.........                                                  .,
                                         ..';coxk0KKKKKKKKK0Oxl;'..        .':x0KKXXO:'',oO0xc,'....';lddxxxdoc;''''''':k00KKOc'o0XKKd,'.       .'';c::;,,'''...  .                                            .,
                                      ..':ok0KKKKXKKXXKKKXKKKKKOl'..      ..';cx0KKXOc,ckKXKK0x:'',cx0KK000KXXKOxc,''''l0XKKKKo:kKKKKk;'..      ..':x000Okxl,.....''......                                     .,
                                     ..',dKXKKKKKKXKKXKKKKKKKKKXOc'..      ....c0XKX0dd0KXKKXKkc';d00xl::::lkKXKOo,''.,dKKKKKKkd0KKXXOc''........'..:OXKKKXk;.'':ddolc;'''.                                    .,
                                     ..'';dKKXKXKKKKX0dc::cdOKKXKo''.   .......c0XKKKKKKXXKKOl,';xKKx;''''':xK0x:''''':kKKKXKK00KKKKX0l''.',:cc:;,'.:OKKKKKOc'.;xKXKKOc''..                                    .,
                                      ..'';oOO0KXKKKKKo,''''cOKKKo''...,:cc:;''cOKXKKKKKKKOo;'''l0KKd,'',:dOKkc,''''''l0XKXXKKKKKKKKXKo,,coodOKK0kd:;o0KKKK0l''c0XKKKd,'..                                     .,
                                       ..''',,cOKKKKKXOc'''':kXKO:'';loox0KKOxl;ckKKXKKKKk:'''''c0XK0dcdkOKOo;;cdo;'''cOKXKXXKKKKKKKKx:ckkl,:kKKKKK0o;l0XKKKd,;xKXKKk:''.                                      .,
                                        ..'''''lOKKKKKKx;'';d0KOc';oOd;'cOXKKKKkc:kKKKKKKOxoc;,',dKKXKKKKKKOxkOKXKOl'',o0X0kkKKKKKKKk:l0Kx;',ldookKX0c;xKKKKx;l0KKX0l''..                                      .,
                                         .....''l0XKKKK0dldOK0x:';xK0l'':dkdd0KKx;l0XKKKXKKKK0ko:;lOKKKKXXKKKXKKK0x:';d0KKO:;xKKOxO0lcOKXOl,'''':kKKKo,oKXXKOdxKKKKd,'..                                       .,
                                             ..',o0XKXKKKKK0xc,',oKXKx:''',;dKKXO::OXKxoxOKKKKXKOl;;lxkO0000OOkdl:,',dKKKKx;':k0l,dk:l0XKK0xooodOKKX0l;xK0KXKKKKKXk:''.                                        .,
                                              ..',d0KKKKKKkc'''.,xKKXKOdoodOKKKKx:l0X0l'';coxO0KXKkdlcccc:;;;,'''''';xKKKKd,.':l,'okccOKKXXKKKXXKKK0d:dKOk0XKKKKX0l''..                                        .,
                                               .'';dKKKKKKk:'''.,oKKKKKXXXXKKKKOcckKX0l'.'''',:ldk0KKK0Okl'''......',:cllo:'''''''lOx:lOKXKKKKKKKKkolxKKdd0XKKKKKd;'..                                         .,
                                                .'';xKKKKX0o''''';xKKKKKKXKKK0d:'l0XX0l''......'',:ldk00Oo'''..  ......''''''''''':OKxccokO000Okdc,lOKX0ll0XKKKKk:''.                                          .,
                                                 .'':kKKKKKx;''''',cdkO00Okxo:'''ck00Oc''.    ....''',;cl;'''.        .........''';x00Oo;',;;;,,'''oKXXk:cOXKKX0l''..                                          .,
                                                 ..'':kKKXX0c'''''''',;;;;,''''''';;;;,''.        .....''''''.                 ..'',;;;;,''''.....':looc'cOKKKKd;'..       ...                                 .,
                                                  ..''cOKKXKd,'''.........................           .........                   ........''''.. .'''.'''':kXXKO:''.  ...',;l:.                                 .,
                                                   ..''lO0kxl,'''..                                                                      .....   ......'',lkkkl,;:;::clloodd:.                                 .,
                                                    ..'';;,'''''..                                                                                     ..',:llcccc::;,,'',;coc.                                .,
                                                     ..'''......                                                                                        .;cl:;,''''''''''',,:ol'                               .,
                                                      ....                                                                                            .':c;''''''''.'''',cl,':oo,.                             .,
                                        .,cool;'.                                                                                                   .,;;,'''''''.'''''',ldc,'':od:.                            .,
                                     .,cxOOOOOOkxo:'.                       .......................................................               .;c;'''''''''''''''',ldd:',;ldxl.          ''.               .,
                                   .:dkOOOOOOOOOOOOkxl;..                  .::...................................................'c'              ,l;'''''''''''''''';ldxdllodxxxdl;.        'lc'              .,
                                 .cxOOOOOOOOOOOOOOOOOkkxo;.                .;.                                                    ;'             .:c'''''...''''''';codxxxxxxxxxxxxxo:.       'od:.            .,
                               .lxOOOOOOOOkxolc:;;,,'''....                .;.                                                    ;'             .c:'.....'....''',lxxxxxxxxxxxxxxxxxdl.       ;ddl'           .,
                             .cxOOOOkdoc;'..                               .:.                                                    ;'             .:;.   .oOo;',lxl:oxxxxdxkkxxxxxxxxxxxl.      ,oxxo;.         .,
                             .:oxOOko;.                                    .:.                                                    ;'              ,'    .cloxdxO0xodxxxdodkxxxoodxxxxxxd:...,;cdoldxd:.        .,
                             ..;lxOOOko,.    ,l:.                          .:.                                                    ;'                     'cllccloxxxxxxxxdoloddddxxxxxxxo;colcc:,;oxxxc.       .,
                             .:okOko:;;,.  .:xOk:                          .:.                                                    ;'                    .lo.   .lxxxxxdl:,,:oxxxxxxxxxxxxdl;''''''cdxxxl.      .,
                         'l;.  .':lc,'....'lkOOOo.                         .:.                                                    ;'                     ..     .:clo:;,.':oxxxxxxxxxxxxxdolc:::;;cdxxxxl.     .,
                        .dOkc'.'...''',;;cxOOOOk:.                         .:.                                                    ;'                            .;clolc;;cdxkkxxxxxxxxxxxxxxxxxxdddxxxxxxc.    .,
                        ;kOOOx:.......',;okOOOOkdc'                        .:.                                                    ;'                          .cdxxxxxddxOO0000Okxxxxxxxxxxxxdddddxxxxxxxd;    .,
                        ;kOOOko;''',;:cldkOOOOOOOOkl'                      .:.                                                    ;'                         .cxxxxxxxkO00000000Okxxxxxxxxoc:;;,;lxxxxxxxxo'   .,
                       ,dkOOOOklcoxkOOOOOOOOOOOOOOOOx:.                    .:.                                                    ;'                     ....;dxxxxxxO00000000000kxxxxxxxd:...,;;lxxxxxxxxx:.  .,
                      ;xOOOOOOOOOOOOOOOOOOOOOOOOOOxxxo'                    .:.                                                    ;'               .';:cloooddxxxxxxO000000000000kxxxxxxxd,  cxlodxxxxxxxxxo.  .,
                     ;xOOOOOOOOOOOOOOOOOOOOOOO0Odlcdkdlc;..                .:.                                                    ;'            .;ldxkkkOOkxxxxxxxxk000000000000Oxxxxxxxxl. .:' .lxxxxxxxxxd,  .,
                    .dOOOOOOOOOOOOOOOOOOOOkkkkkd,  ;xOOOOkdc.              .:.                                                    ;'          'cdxxkO00KXXKkxxxxxxxk000000000000kxxxxxxxd:.     'xOodxxxxxxd,  .,
                    ;kOOOOOOOOOOOOOkO0kkOkolxkkkl..'oxxdoc;'.              .:.                                                    ;'        .:dxxk00K0xoONNK0kxdxxxkO0000000000kxxxxxxxxl.     .cd;,d0kxxxxd,  .,
                    ;kOOkkOOOOOOOOklldoxOOkkkOOOOo'.....                   .:.                                                    ;'        ,dxxOOxc::..';lO0d;'',cdO00000000Okxxxxxxxxo,          .lxxxxxxl.  .,
                    'xOxloOOOOOOxc'..:kOOOOOOOko:.                         .:.                                                    ;'       .cxxkOo.        ..      .':dO0000kxxxxxxxxxxl.           :xxxxxd:   .,
                     .;',oOOOOOOl.   ;xOOOkxo:'.                           .:;...................................................'c'       .cxxOx'                    .;dO0Oxxxxxxxxxxxc.           ,dxxxxl.   .,
                        .cOOOOOOkdc,,:lc:;'.                                .'......................................................        :dxOd.                      .cxkxxxxxxxxxxd,            .lxxxl.    .,
                         .:xOOOOOOOxc.                                                                                                      .lxkx'                      ;odxxxxxxxxxxo;              :dxo.     .,
                           .;clool:,.                                                                                                        'oxkc.    ..             .;oxxxxxxxxxxdo,               'od;      .,
                                                                                                                                              'lxx:.,:cll:;,''...  .:dddxxxxxxdddlc,.                .cl.      .,
                                                                                                                                               .:dxoodddddddddoo:';d0X0kxxxxo:'...                    ,,       .,
                                                                                                                                                 'cdddddddddddo:.  .;ONKxddc.                         ..       .,
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

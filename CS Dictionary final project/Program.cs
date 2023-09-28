//Word word = new Word("name", "имя", "название");
//Word word1 = new Word("skill", "навык");
//Word word2 = new Word("car", "машина", "автомобиль", "транспорт");

//Dictionary dict = new("English - russian", word, word1, word2);
//Console.WriteLine(word);

//dict.show();

//dict.AddWord(new Word("key", "ключ", "ключевой"));
//dict.show();



string[] menu =
{
    "Create a new dictionary",
    "Open a dictionary", 
    "Exit"
};

showMenu(menu);


int showMenu(string[] menuName)
{
    int menuPos = 0;

    while (true)
    {
        Console.Clear();
        Console.CursorVisible = false;
        menuPos %= menuName.Length;
        if (menuPos < 0) menuPos = menuName.Length - 1;

        for (int i = 0; i < menuName.Length; i++)
        {
            if (i == menuPos)
            {
                Console.WriteLine($">> {menuName[i]}");
            }
            else
            {
                Console.WriteLine($"{menuName[i]}");
            }
        }


        var keyPressed = Console.ReadKey();

        if (keyPressed.Key == ConsoleKey.W || keyPressed.Key == ConsoleKey.UpArrow)
        {
            menuPos--;
        }
        else if (keyPressed.Key == ConsoleKey.S || keyPressed.Key == ConsoleKey.DownArrow)
        {
            menuPos++;
        }
        else if (keyPressed.Key == ConsoleKey.Enter)
        {
            return menuPos;
        }
    }
}



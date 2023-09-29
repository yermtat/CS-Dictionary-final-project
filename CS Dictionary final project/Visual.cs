

static class Visual
{
    public static int ShowMenu(string[] menuName)
    {
        int menuPos = 0;

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            menuPos %= menuName.Count();
            if (menuPos < 0) menuPos = menuName.Count() - 1;

            for (int i = 0; i < menuName.Count(); i++)
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

}


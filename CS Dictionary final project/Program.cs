//Word word = new Word("name", "имя", "название");
//Word word1 = new Word("skill", "навык");
//Word word2 = new Word("car", "машина", "автомобиль", "транспорт");

//Dictionary dict = new("English - russian", word, word1, word2);
//Console.WriteLine(word);

//dict.show();

//dict.AddWord(new Word("key", "ключ", "ключевой"));
//dict.show();


int menuItem, dictionaryItem;
Dictionary dictionary = new Dictionary();

string[] startMenu = 
{
    "Create a new dictionary",
    "Open a dictionary", 
    "Exit"
};

string[] openDictionaryMenu =
{
    "Add a word",
    "Find a word",
    "Show all words"
};

string[] dictionariesMenu;


while (true)
{
    menuItem = Visual.ShowMenu(startMenu);

    Console.CursorVisible = true;

    switch (menuItem)
    {
        case 0:
            
            Console.Write("\nEnter a languages (f.e. \"Russuan - English\", \"English - Russsian\"): ");
            dictionary.Type = Console.ReadLine();

            FileOperations.WriteADictionary(dictionary.Type);

            break;
        case 1:
            dictionariesMenu = File.ReadAllLines("dictionaries.txt");
            dictionaryItem = Visual.ShowMenu(dictionariesMenu);

            menuItem = Visual.ShowMenu(openDictionaryMenu);


            break;
        case 2:
            Console.WriteLine(dictionary.Type);
            return;
            break;


    }

}




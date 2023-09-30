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
Word word = new Word();
string translation = default;
bool escape;

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
    "Show all words",
    "Go back"
};

string[] dictionariesMenu;


while (true)
{
    menuItem = Visual.ShowMenu(startMenu);

    escape = false;
    Console.CursorVisible = true;

    switch (menuItem)
    {
        case 0:

            Console.Write("\nEnter a languages (f.e. \"Russian - English\", \"English - Russian\"): ");
            dictionary.Type = Console.ReadLine();

            FileOperations.WriteADictionary(dictionary.Type);

            break;
        case 1:
            dictionariesMenu = File.ReadAllLines("dictionaries.txt");
            dictionaryItem = Visual.ShowMenu(dictionariesMenu);

            dictionary.SetWords(FileOperations.readDictionaryCsv(dictionariesMenu[dictionaryItem]));
            dictionary.Type = dictionariesMenu[dictionaryItem];

            foreach (var item in dictionary.GetWords())
            {
                item.MakeList();
            }

            while (escape is not true)
            {
                menuItem = Visual.ShowMenu(openDictionaryMenu);
                Console.CursorVisible = true;

                switch (menuItem)
                {
                    case 0:
                        Console.Write("Type the word: ");
                        word.Meaning = Console.ReadLine();

                        Console.Write("Type the translations by one or type \"0\" to finish: ");

                        //word.Translations.Clear();
                        translation = default;
                        while (translation != "0")
                        {
                            translation = Console.ReadLine();
                            if (translation != "0") word.SetTranslation(translation);
                            //word.Translations.Append(translation);
                            //word.Translations.Append(Console.ReadLine());
                        }

                        word.MakeFull();
                        dictionary.AddWord(word);

                        break;
                    case 1:
                        break;
                    case 2:

                        dictionary.Show();
                        Console.WriteLine("Press any key to go back...");
                        Console.ReadKey();
                        break;
                    case 3:
                        escape = true;
                        break;

                }
            }

            //foreach (var item in dictionary.Words)
            //{
            //    item.MakeFull();
            //}

            FileOperations.writeDictionaryCsv(dictionary);


            break;
        case 2:
            Console.WriteLine(dictionary.Type);
            return;
            break;


    }

}






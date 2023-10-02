
int menuItem, dictionaryItem, wordItem;
Dictionary dictionary = new Dictionary();
Word word = new Word();
string type = default, translation = default, meaning = default, findWord = default;
bool escape, wordMenuEscape;

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

string[] wordOperationsMenu =
{
    "Change word",
    "Change translation",
    "Delete word",
    "Delete translation",
    "Save as file",
    "Go back"
};


while (true)
{
    menuItem = Visual.ShowMenu(startMenu);

    escape = false;
    Console.CursorVisible = true;

    switch (menuItem)  // Start menu switch
    {
        case 0: // new dictionary

            Console.Write("\nEnter a languages (f.e. \"Russian - English\", \"English - Russian\"): ");
            type = Console.ReadLine();
            if (type is not null)
            {
                dictionary.Type = type;

                FileOperations.WriteADictionary(dictionary.Type);

                Console.WriteLine("The dictionary is made successfully. Press any key to continue.");
                Console.ReadKey();
            }

            break;
        
        
        case 1: // open dictionary
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

                switch (menuItem) // open dictionary menu
                {
                    case 0: // add a word
                        Console.Write("\nType the word: ");
                        meaning = Console.ReadLine().ToLower();
                        if (meaning is not null)
                        {
                            word.Meaning = meaning;

                            Console.WriteLine("Type the translations by one or type \"0\" to finish: ");

                            word = addTranslations(word, ref translation);
                            dictionary.AddWord(word);
                        }
                        break;
                    
                    
                    case 1: // find a word
                        Console.Write("\nType a word: ");
                        findWord = Console.ReadLine().ToLower();

                        word = dictionary.FindWord(findWord);

                        
                        if (word is not null)
                        {
                            Console.WriteLine(word);
                            Console.WriteLine("\nPress \"m\" to open a word operations menu, or press any other key to go back.");

                            if (Console.ReadKey().Key == ConsoleKey.M)
                            {
                                wordMenuEscape = false;

                                while (wordMenuEscape is not true)
                                {

                                
                                    menuItem = Visual.ShowMenu(wordOperationsMenu);

                                    switch (menuItem) // Word operations switch
                                    {
                                        case 0: // change word
                                            Console.Write("\nType new word: ");
                                            meaning = Console.ReadLine().ToLower();
                                            if (meaning is not null) word.Meaning = meaning;
                                            
                                            break;
                                        
                                        
                                        case 1: // change translation
                                            Console.WriteLine("\nType new translations by one or type \"0\" to finish: ");

                                            word = addTranslations(word, ref translation);
                                            break;

                                        
                                        case 2: // delete word
                                            dictionary.RemoveWord(word.Meaning);
                                            Console.WriteLine("\nThe word is deleted, press any key to continue.");
                                            wordMenuEscape = true;
                                            Console.ReadKey();
                                            break;

                                        case 3: // delete translations
                                            if (word.Translations.Count() > 1)
                                            {
                                                wordItem = Visual.ShowMenu(word.Translations.ToArray());
                                                word.DeleteTranslation(wordItem);
                                                word.MakeFull();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nThere is only one translation left, you can't delete it.");
                                                Console.WriteLine("Press any key to continue");
                                                Console.ReadKey();
                                            }
                                            break;

                                        case 4: // save to file
                                            FileOperations.WriteWord(word);
                                            Console.WriteLine("\nFile is made successfully. Press any key to continue.");
                                            Console.ReadKey();
                                            break;

                                        case 5: 
                                            wordMenuEscape = true;
                                            break;


                                        default:
                                            break;
                                    }
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("\nSorry, there is no such word. Press any key to continue.");
                            Console.ReadKey();
                        }
                        break;
                    
                    
                    case 2: // show all the words

                        dictionary.Show();
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3: // go back
                        escape = true;
                        break;

                }
            }

            FileOperations.writeDictionaryCsv(dictionary);


            break;
        case 2: // exit
            return;



    }

}



Word addTranslations(Word word, ref string translation)
{
    word.Translations.Clear();
    translation = default;
    while (translation != "0")
    {
        translation = Console.ReadLine().ToLower();
        if (translation != "0" && translation is not null) word.SetTranslation(translation);
    }

    word.MakeFull();
    return word;
}




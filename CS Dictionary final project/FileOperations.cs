


using System.Runtime.CompilerServices;

static class FileOperations
{
    static public void WriteADictionary(string dictionaryType)
    {
        using FileStream fs = new("dictionaries.txt", FileMode.Append);
        using StreamWriter sw = new(fs);

        sw.WriteLine(dictionaryType);
    }

    static public void ReadDictionaries()
    {
        //using FileStream fs = new("dictionaries.txt", FileMode.OpenOrCreate);
        //using StreamReader sr = new(fs);

        //List<string> list = sr.Read


 
    }
}




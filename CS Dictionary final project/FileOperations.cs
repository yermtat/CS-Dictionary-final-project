


using CsvHelper;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Runtime.CompilerServices;

static class FileOperations
{
    static public void WriteADictionary(string dictionaryType)
    {
        using FileStream fs = new("dictionaries.txt", FileMode.Append);
        using StreamWriter sw = new(fs);

        sw.WriteLine(dictionaryType);
    }

    static public List<Word> readDictionaryCsv(string dictionaryType)
    {
        using FileStream fs = new(dictionaryType + ".csv", FileMode.OpenOrCreate);
        using var reader = new StreamReader(fs);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return csv.GetRecords<Word>().ToList();
    }

    static public void writeDictionaryCsv(Dictionary dictionary)
    {
        using FileStream fs = new(dictionary.Type + ".csv", FileMode.Truncate);
        using var writer = new StreamWriter(fs);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(dictionary.GetWords());
    }

    static public void WriteWord(Word word)
    {
        using FileStream fs = new(word.Meaning + ".csv", FileMode.Create);
        using var writer = new StreamWriter(fs);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecord(word);
    }
}




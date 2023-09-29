



class Dictionary
{
    public string Type { get; set; }
    private List<Word> _words;

    public Dictionary()
    {
        _words= new List<Word>();
    }

    //public Dictionary(string type, params Word[] words)
    //{
    //    Type = type;
    //    _words = new List<Word>(words);

    //}

    public void AddWord(Word word)
    {
        _words.Add(word);
    }


    public void show()
    {
        _words.ForEach(Console.WriteLine);
    }
}



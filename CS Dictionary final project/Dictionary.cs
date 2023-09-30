



class Dictionary
{
    public string Type { get; set; }
    private List<Word> _words;
    //public List<Word> Words { get; set; }

    //public List<Word> Words
    //{
    //    get { return _words; }
    //    set { _words = value; }
    //}


    public Dictionary()
    {
        _words = new List<Word>();
    }

    //public Dictionary(string type, params Word[] words)
    //{
    //    Type = type;
    //    _words = new List<Word>(words);

    //}

    public void SetWords(List<Word> words)
    {
        _words = words;
    }
    public List<Word> GetWords()
    {
        return _words;
    }

    public void AddWord(Word word)
    {
        _words.Add(new Word(word.Meaning, word.Translations, word.FullTranslations));
        //_words.Add(word);
    }


    public void Show()
    {
        _words.ForEach(Console.WriteLine);
    }
}



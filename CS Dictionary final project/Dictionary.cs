



class Dictionary
{
    public string Type { get; set; }
    private List<Word> _words;

    public Dictionary()
    {
        _words = new List<Word>();
    }


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
    }

    public Word FindWord(string word)
    {
        return _words.Find(w => w.Meaning == word);
    }

    public void RemoveWord(string word) 
    {
        foreach (var item in _words)
        {
            if (item.Meaning == word)
            {
                _words.Remove(item);
                break;
            }
        };
    }

    public void Show()
    {
        _words.ForEach(Console.WriteLine);
    }
}



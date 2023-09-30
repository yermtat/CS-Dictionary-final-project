



class Word
{
    public string Meaning { get; set; }
    //private List<string> _translation;
    //public List<string> Translations { get; set; }

    private List<string> _translation;

    public string FullTranslations { get; set; }
    public List<string> Translations
    {
        get { return _translation; }
        set { _translation = value; }
    }

    public Word(string meaning, List<string> translation, string fullTranslations)
    {
        Meaning = meaning;
        _translation = new List<string>(translation);
        FullTranslations = fullTranslations;
    }

    public Word() 
    {
        _translation = new List<string>();
    }
    //public Word(string meaning, params string[] translation)
    //{
    //    Meaning = meaning;
    //    _translation = new List<string>(translation);
    //}

    public void SetTranslation(string value)
	{
        _translation.Add(value);
	}

    public void MakeFull()
    {
        if (_translation.Count > 1) FullTranslations = string.Join(", ", _translation);
        else FullTranslations = _translation.First();
    }
    public void MakeList()
    {
        if (FullTranslations.Contains(", ")) _translation = FullTranslations.Split(", ").ToList();
        else _translation.Append(FullTranslations);
    }

    public override string ToString()
    {
        string str = Meaning + " - ";
        foreach (string s in _translation) { str += s + "; "; }
        return str;
    }

}



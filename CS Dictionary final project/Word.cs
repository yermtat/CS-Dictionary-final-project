



class Word
{
    public string Meaning { get; set; }
	private List<string> _translation;

    public Word(string meaning, params string[] translation)
    {
        Meaning = meaning;
        _translation = new List<string>(translation);
    }

    public void SetTranslation(string value)
	{
		_translation.Add(value);
	}

    public override string ToString()
    {
        string str = Meaning + " - ";
        foreach (string s in _translation) { str += s + "; "; }
        return str;
    }

}



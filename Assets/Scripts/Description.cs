using System.Collections.Generic;
using System;

[Serializable]
public class Description
{
    public List<CharacterText> statements = new List<CharacterText>();
}
[Serializable]
public class CharacterText
{
    public string text;
    public float timeTillNextText;
}
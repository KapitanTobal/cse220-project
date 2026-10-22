using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        LoadScriptures();
    }

    private void LoadScriptures()
    {
        string[] lines = File.ReadAllLines("doctrinal_mastery.txt");

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            {
                continue;
            }

            string[] parts = line.Split('|');

            string book = parts[0];
            if (!int.TryParse(parts[1], out int chapter) ||
    !int.TryParse(parts[2], out int startVerse) ||
    !int.TryParse(parts[3], out int endVerse))
            {
                continue;
            }
            string text = parts[4];

            Reference reference = new Reference(
                book,
                chapter,
                startVerse,
                endVerse);

            Scripture scripture = new Scripture(text, reference);

            _scriptures.Add(scripture);
        }
    }

    public int GetCount()
    {
        return _scriptures.Count;
    }

    public Scripture GetScripture(int index)
    {
        return _scriptures[index];
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int randomIndex = random.Next(_scriptures.Count);

        return _scriptures[randomIndex];
    }
}
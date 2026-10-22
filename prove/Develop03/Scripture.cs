using System;
using System.Collections.Generic;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;

    public Scripture(string rawText, Reference reference)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = rawText.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayString()
    {
        string displayText = _reference.GetDisplayString() + "\n";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayString() + " ";
        }

        return displayText.Trim();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = 3;

        List<int> availableIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndexes.Add(i);
            }
        }

        for (int i = 0; i < wordsToHide && availableIndexes.Count > 0; i++)
        {
            int randomPosition = random.Next(availableIndexes.Count);
            int wordIndex = availableIndexes[randomPosition];

            _words[wordIndex].Hide();
            availableIndexes.RemoveAt(randomPosition);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public string GetReferenceString()
    {
        return _reference.GetDisplayString();
    }
}
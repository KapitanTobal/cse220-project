using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no journal entries.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveJournal(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date}|{entry._prompt}|{entry._response}"
                );
            }
        }
    }

    public void LoadJournal(string fileName)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            if (parts.Length >= 3)
            {
                Entry entry = new Entry();

                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._response = parts[2];

                _entries.Add(entry);
            }
        }
    }

    public void EditEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to edit.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_entries[i]._date} - {_entries[i]._prompt}"
            );
        }

        Console.Write("Which entry would you like to edit? ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int entryNumber) &&
            entryNumber >= 1 &&
            entryNumber <= _entries.Count)
        {
            _entries[entryNumber - 1].Edit();
            Console.WriteLine("Entry updated.");
        }
        else
        {
            Console.WriteLine("Invalid entry number.");
        }
    }
}
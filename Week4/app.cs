using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Interface
interface ILibraryItem
{
    string Title { get; set; }
    void DisplayInfo();
    string ToFileString();
}

// Base Class (your Item, now abstract)
abstract class Item : ILibraryItem
{
    private string title;
    private string publisher;
    private int publicationYear;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public int PublicationYear
    {
        get { return publicationYear; }
        set { publicationYear = value; }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Year: " + PublicationYear);
    }

    public abstract string ToFileString();
}

// Book
class Book : Item
{
    public string Author { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine("Book Information:");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Year: " + PublicationYear);
        Console.WriteLine();
    }

    public override string ToFileString()
    {
        return $"Book,{Title},{Author},{Publisher},{PublicationYear}";
    }
}

// Magazine
class Magazine : Item
{
    public int IssueNumber { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine("Magazine Information:");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Issue Number: " + IssueNumber);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Year: " + PublicationYear);
        Console.WriteLine();
    }

    public override string ToFileString()
    {
        return $"Magazine,{Title},{IssueNumber},{Publisher},{PublicationYear}";
    }
}

// NEW CLASS 
class Newspaper : Item
{
    public string Date { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine("Newspaper:");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Date: " + Date);
        Console.WriteLine();
    }

    public override string ToFileString()
    {
        return $"Newspaper,{Title},{Date},{Publisher},{PublicationYear}";
    }
}

// Library class
class Library
{
    private List<Item> items = new List<Item>();
    private string file = "libraryData.txt";

    public void AddItem(Item item)
    {
        items.Add(item);
        Save();
    }

    public void DisplayAll()
    {
        foreach (var item in items)
        {
            item.DisplayInfo();
        }
    }

    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (var item in items)
        {
            lines.Add(item.ToFileString());
        }

        File.WriteAllLines(file, lines);
    }

    public void Load()
    {
        if (!File.Exists(file)) return;

        var lines = File.ReadAllLines(file);

        foreach (var line in lines)
        {
            var parts = line.Split(',');

            if (parts[0] == "Book")
            {
                items.Add(new Book
                {
                    Title = parts[1],
                    Author = parts[2],
                    Publisher = parts[3],
                    PublicationYear = int.Parse(parts[4])
                });
            }
            else if (parts[0] == "Magazine")
            {
                items.Add(new Magazine
                {
                    Title = parts[1],
                    IssueNumber = int.Parse(parts[2]),
                    Publisher = parts[3],
                    PublicationYear = int.Parse(parts[4])
                });
            }
            else if (parts[0] == "Newspaper")
            {
                items.Add(new Newspaper
                {
                    Title = parts[1],
                    Date = parts[2],
                    Publisher = parts[3],
                    PublicationYear = int.Parse(parts[4])
                });
            }
        }
    }

    public void Search(string keyword)
    {
        foreach (var item in items)
        {
            if (item.Title.ToLower().Contains(keyword.ToLower()))
                item.DisplayInfo();
        }
    }

    public void Sort()
    {
        items = items.OrderBy(i => i.Title).ToList();
    }
}
using System;
using System.Collections.Generic;

// Custom Exception
class InvalidItemDataException : Exception
{
    public InvalidItemDataException(string message) : base(message) { }
}

// Base Class
class Item
{
    private string title;
    private string publisher;
    private int publicationYear;

    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidItemDataException("Title cannot be empty.");
            title = value;
        }
    }

    public string Publisher
    {
        get { return publisher; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidItemDataException("Publisher cannot be empty.");
            publisher = value;
        }
    }

    public int PublicationYear
    {
        get { return publicationYear; }
        set
        {
            if (value < 0 || value > DateTime.Now.Year)
                throw new InvalidItemDataException("Invalid publication year.");
            publicationYear = value;
        }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Year: " + PublicationYear);
    }
}

// Book Class
class Book : Item
{
    private string author;

    public string Author
    {
        get { return author; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidItemDataException("Author cannot be empty.");
            author = value;
        }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Book Information:");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Year: " + PublicationYear);
        Console.WriteLine();
    }
}

// Magazine Class
class Magazine : Item
{
    private int issueNumber;

    public int IssueNumber
    {
        get { return issueNumber; }
        set
        {
            if (value <= 0)
                throw new InvalidItemDataException("Issue number must be positive.");
            issueNumber = value;
        }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Magazine Information:");
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Issue Number: " + IssueNumber);
        Console.WriteLine("Publisher: " + Publisher);
        Console.WriteLine("Year: " + PublicationYear);
        Console.WriteLine();
    }
}

// Main Program
class Program
{
    static void Main()
    {
        try
        {
            // Create Book
            Book book1 = new Book();
            book1.Title = "C#";
            book1.Author = "Price, M";
            book1.Publisher = "Packt Publishing";
            book1.PublicationYear = 2024;

            // Create Magazine
            Magazine magazine1 = new Magazine();
            magazine1.Title = "Iron Man";
            magazine1.IssueNumber = 105;
            magazine1.Publisher = "Marvel";
            magazine1.PublicationYear = 2001;

            // Polymorphism
            Item item1 = book1;
            Item item2 = magazine1;

            item1.DisplayInfo();
            item2.DisplayInfo();
        }
        catch (InvalidItemDataException ex)
        {
            Console.WriteLine("Input Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Program finished.");
        }
    }
}
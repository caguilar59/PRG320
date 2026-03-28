using System;

class Program
{
    static void Main()
    {
        Library library = new Library();
        library.Load();

        bool run = true;

        while (run)
        {
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. Add Magazine");
            Console.WriteLine("3. Add Newspaper");
            Console.WriteLine("4. View All");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Sort");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Book b = new Book();
                        Console.Write("Title: ");
                        b.Title = Console.ReadLine();
                        Console.Write("Author: ");
                        b.Author = Console.ReadLine();
                        library.AddItem(b);
                        break;

                    case "2":
                        Magazine m = new Magazine();
                        Console.Write("Title: ");
                        m.Title = Console.ReadLine();
                        Console.Write("Issue #: ");
                        m.IssueNumber = int.Parse(Console.ReadLine());
                        library.AddItem(m);
                        break;

                    case "3":
                        Newspaper n = new Newspaper();
                        Console.Write("Title: ");
                        n.Title = Console.ReadLine();
                        library.AddItem(n);
                        break;

                    case "4":
                        library.DisplayAll();
                        break;

                    case "5":
                        Console.Write("Search: ");
                        library.Search(Console.ReadLine());
                        break;

                    case "6":
                        library.Sort();
                        Console.WriteLine("Sorted!");
                        break;

                    case "7":
                        run = false;
                        library.Save();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
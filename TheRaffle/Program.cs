// Were going to do a CLI first (Command Line Interface) once this works fully well go into a gui
////TODO Before running make sure you run dotnet restore to install packages

using CsvHelper;
using System.Globalization;
do
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Welcome to CLI GoldenTicket\nContiune through the menu for more options.");
    Console.WriteLine("Press 1 on the keyboard");
    Console.WriteLine("-----------------------------\n");
    // What the ? means it'll return null google null-conditional operators for c#
    string? menuOption = Console.ReadLine();
    string? file = Console.ReadLine();
    using var reader = new StreamReader(file);

    switch (menuOption)
    {
        case "1":
            Console.WriteLine("This insert file: ");
            cleanFile(reader);
            break;
    }
} while (false);

void cleanFile(StreamReader file)
{
    Console.WriteLine(file);
    using (var csv = new CsvReader(file, CultureInfo.InvariantCulture))
    {
        var records = csv.GetRecords<getHeader>().ToList();
        List<getHeader> Tickets = new List<getHeader>();
        int counter = records.Count;
        int index = 0;
        while (counter != 0)
        {
            bool TrueOrFalse = true;

            if (Tickets.Count > 0)
            {
                foreach (getHeader item in Tickets)
                {
                    if (item.Name.Equals(records[index].Name))
                    {
                        TrueOrFalse = false;
                    }
                }
            }
            if (TrueOrFalse == true)
            {
                Tickets.Add(records[index]);
            }
            index++;
            counter--;
        }
        foreach(getHeader item in Tickets)
        {
            Console.WriteLine(item.Name);
        }
    }

}


// Were going to do a CLI first (Command Line Interface) once this works fully well go into a gui
////TODO Before running make sure you run dotnet restore to install packages
using System;
using CsvHelper;
using System.Globalization;


do
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Welcome to CLI GoldenTicket\nInsert a file that contains raffle tickets.");
    Console.WriteLine("-----------------------------\n");
    // What the ? means it'll return null google null-conditional operators for c#
    string? file = Console.ReadLine();
    using var reader = new StreamReader(file);
    List<getHeader> Tickets = new List<getHeader>();
    cleanFile(reader, Tickets);
    Console.WriteLine("Raffle has been cleaned of duplicates :)\n");
    Console.WriteLine("-----------------------------\n");
    Console.WriteLine("Would you like to choose names of winner(s) ;)?\n");
    Console.WriteLine("If yes, press (1)");
    Console.WriteLine("For random winners press (2)");
    string? randomOption = Console.ReadLine();
    List<getHeader> Winners = new List<getHeader>();
    switch(randomOption){
        case "1":
            SpecificWinner(Tickets, Winners);
            PrintWinner(Winners);
            break;
        case "2":
            RandomWinner(Tickets, Winners);
            PrintWinner(Winners);
            break;

    }
} while (false);

void cleanFile(StreamReader file, List<getHeader> Tickets)
{
    using (var csv = new CsvReader(file, CultureInfo.InvariantCulture))
    {
        var records = csv.GetRecords<getHeader>().ToList();
        int counter = records.Count;
        int index = 0;
        //Stores non duplicate submissions into a list of getHeader called Tickets
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
    }
    //Writes the data in Tickets into a new csv file called RaffleTickets.csv
    var csvPath = Path.Combine(Environment.CurrentDirectory, $"RaffleTickets.csv");
    using (var streamWriter = new StreamWriter(csvPath))
    {
        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteHeader<getHeader>();
            csvWriter.NextRecord();
            foreach (var record in Tickets)
            {
                csvWriter.WriteRecord(record);
                csvWriter.NextRecord();
            }
        }
    }
    Console.WriteLine("Updated file is saved in: {0}", csvPath);
}
void SpecificWinner(List<getHeader> Tickets, List<getHeader> Winners)
{
    Console.WriteLine("How many names do you want to choose?");
    string? number = Console.ReadLine();
    int numOfNames = Convert.ToInt32(number);
    bool doesNameExist = false;
    while (numOfNames > 0)
    {
        do
        {
            doesNameExist = false;

            Console.WriteLine("Number of names left to choose: {0} " +
                              "(If number of names does not decrease, the name does not exist)", numOfNames);
            Console.WriteLine("Input the full name of the desired winner");
            string? name = Console.ReadLine();
            foreach (getHeader item in Tickets)
            {
                if (name.Equals(item.Name))
                {
                    Winners.Add(item);
                    doesNameExist = true;
                    Tickets.Remove(item);
                    break;
                }
            }
        } while (!(doesNameExist));
        numOfNames--;
    }
}

void RandomWinner(List<getHeader> Tickets, List<getHeader> Winners)
{
    Random random = new Random();
    Console.WriteLine("How many winners do you want to choose from {0} submissions? " +
                      "(If names were chosen, how many winners do you want to choose on top of the chosen?)", Tickets.Count);
    string? number = Console.ReadLine();
    int numOfWinners = Convert.ToInt32(number);
    while(numOfWinners > 0)
    {
        int ranNum = random.Next(0, Tickets.Count);
        Winners.Add(Tickets[ranNum]);
        Tickets.Remove(Tickets[ranNum]);
        numOfWinners--;
    }
}
void PrintWinner(List<getHeader> Winners)
{
    int index = 1;
    foreach(getHeader item in Winners)
    {
        Console.WriteLine("Winner {0} is {1} :0", index, item.Name);
        index++;
    }
}


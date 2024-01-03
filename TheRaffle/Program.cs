// Were going to do a CLI first (Command Line Interface) once this works fully well go into a gui
////TODO Before running make sure you run dotnet restore to install packages

do
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine("Welcome to CLI GoldenTicket\nContiune through the menu for more options.");
    Console.WriteLine("Press 1 on the keyboard");
    Console.WriteLine("-----------------------------\n");
    // What the ? means it'll return null google null-conditional operators for c#
    string? menuOption = Console.ReadLine();
    switch (menuOption)
    {
        case "1":
            Console.WriteLine("This option does something: ");
            Console.Read();
            break;
    }
} while (true);

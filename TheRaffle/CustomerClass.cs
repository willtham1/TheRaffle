using CsvHelper.Configuration.Attributes;

public class Customer
{
    [Index(0)]
    public string Title { get; set; }
    [Index(1)]

    public string Source { get; set; }
    [Index(2)]

    public string Response { get; set; }
    [Index(3)]

    public string Full_Name { get; set; }
    [Index(4)]

    public string Name { get; set; }
    [Index(5)]

    public string Size { get; set; }
    [Index(6)]

    public string Location { get; set; }
    [Index(7)]

    public string Consent { get; set; }
    [Index(8)]

    public string IP_Adress { get; set; }
}


using CsvHelper.Configuration.Attributes;

public class getHeader
{
    [Name("Title")]
    public string Title { get; set; }
    
    [Name("Source")]

    public string Source { get; set; }

    [Name("Response Date")]

    public string Response { get; set; }

    [Name("1_Name")]
    public string Name { get; set; }

    [Name("1_Full Name")]
    public string Full_Name { get; set; }

    [Name("2_Email")]

    public string Email { get; set; }


    [Name("3_Size")]

    public string Size { get; set; }
    [Name("4_Location")]

    public string Location { get; set; }
    [Name("Consent")]

    public string Consent { get; set; }
    [Name("IP Address")]

    public string IP_Adress { get; set; }
}


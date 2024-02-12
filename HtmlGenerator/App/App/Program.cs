


public class Program
{
    const string FolderPath = "InputFiles\\";
    private static string TemplateFilePath { get; set; } = "";
    private static string DataFilePath { get; set; } = "";
    private static string OutputFilePath { get; set; } = "";

    private static void Main(string[] args)
    {
        GetArgs(args);
        CreateHtml();

        Console.ReadLine();
    }

    private static void GetArgs(string[] args)
    {
        if (CheckArguments(args) == false)
        {
            Print("Please check the arguments: TemplateFilePath, DataFilePath, OutputFilePath");
            Console.ReadLine();
            return;
        }
        Print($"TemplateFilePath: {TemplateFilePath}");
        Print($"DataFilePath: {DataFilePath}");
    }

    private static void CreateHtml()
    {
        var template = File.ReadAllText(TemplateFilePath);
        var jsonData = File.ReadAllText(DataFilePath);
        var htmlGenerator = new HtmlGenerator.HtmlGenerator();
        var resultHtml = htmlGenerator.CreateHtml(template, jsonData);

        File.WriteAllText(OutputFilePath, resultHtml);

        Print($"HTML file generated successfully: {OutputFilePath}");
    }

    private static bool CheckArguments(string[] args)
    {
        if (args.Length == 3)
        {
            TemplateFilePath = args[0];
            DataFilePath = args[1];
            OutputFilePath = args[2];
        }
        else if (Directory.Exists(FolderPath))
        {
            TemplateFilePath = Path.Combine(FolderPath + "template.html");
            DataFilePath = Path.Combine(FolderPath + "data.json");
            OutputFilePath = Path.Combine(FolderPath + "output.html");
        }

        return TemplateFilePath != "" && DataFilePath != "" && OutputFilePath != "";


    }

    private static void Print(string message)
    {
        Console.WriteLine(message);
    }
}
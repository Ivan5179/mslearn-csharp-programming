 // Log a new event
try
{
    LogEvent();
}
catch (FileNotFoundException)
{
    Console.WriteLine("O arquivo não foi encontrado.");
}
catch (DirectoryNotFoundException)
{
    Console.WriteLine("A pasta do arquivo não foi encontrada.");
}

 
 void LogEvent()
 {
 string logFile = "log.txt";
 string timestamp = DateTime.Now.ToString("HH:mm:ss");
 string logEntry = $"[{timestamp}] Application started{Environment.NewLine}";
 string choice;

while (true)
{
    Console.Write("Choose whether to append (A) or overwrite (S) the log file: ");
    choice = Console.ReadLine()?.Trim().ToUpperInvariant() ?? "";

    if (choice == "A" || choice == "S")
    {
        break;
    }

    Console.WriteLine("Please enter A to append or S to overwrite.");
}

if (choice == "A")
{
    File.AppendAllText(logFile, logEntry);
}
else
{
    File.WriteAllText(logFile, logEntry);
}

Console.WriteLine("Event logged.\n");

// Read back every logged event
Console.WriteLine("Event history:");

using StreamReader reader = new StreamReader(logFile);
string line;

while ((line = reader.ReadLine()!) != null)
{
    Console.WriteLine(line);
}

// Count the logged events
string[] allLines = File.ReadAllLines(logFile);
Console.WriteLine($"\nTotal events logged: {allLines.Length}");
}
using System;
using System.IO;
using System.Threading.Tasks;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var kS = new KioskSystem(); 
        await kS.RunAsync();
    }
}

public class BackgroundOperation
{
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("tmp.txt", message); //Output file
    }
}

public class KioskSystem
{
    public async Task RunAsync()
    {
        BackgroundOperation BgOperation = new BackgroundOperation(); //Making object 
        
        while (true)
        {
            //Menubar
            Console.WriteLine("1. Write Hello World");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("4. To exit the program");

            string inp = Console.ReadLine(); // Reading the user input
            if(inp == "4") { break; }
            else
            {
                switch (inp)
                {
                    case "1":
                        Task t1 =  BgOperation.WriteToFileAsync("Hello World");
                        Console.WriteLine("Task completed");
                        break;
                    case "2":
                        Task t2 = BgOperation.WriteToFileAsync(DateTime.Now.ToString());
                        Console.WriteLine("Task completed");
                        break;
                    case "3":
                        Task t3 = BgOperation.WriteToFileAsync(Environment.OSVersion.VersionString);
                        Console.WriteLine("Task completed");
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                   await Task.WhenAll(t1, t2, t3);
                }
                
            }
            
        }
        
    }
}
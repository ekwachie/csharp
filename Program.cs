namespace csharp;

class Program
{
    // commenting single line
    /* commenting mutiple lines */
    static void Main(string[] args)
    {
        User user = new User();
        Console.WriteLine("Welcome! what is your name ?");
        string name = Console.ReadLine();
        user.Print(name);

    }
    
}

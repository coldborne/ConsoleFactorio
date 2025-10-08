namespace ConsoleFactorio.Models;

public class InputReader
{
    public ConsoleKeyInfo Read()
    {
        return Console.ReadKey(true);
    }
}
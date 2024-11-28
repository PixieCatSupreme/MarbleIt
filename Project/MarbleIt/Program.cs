namespace MarbleIt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonToMarbleList converter = new();

            converter.ConvertJson();

            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
        }
    }
}

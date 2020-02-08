using System;
using ComponentApi;

namespace ComponentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageApi api = new MessageApi();

            var greeting = api.Greet();

            Console.WriteLine(greeting);

            Console.ReadKey();
        }
    }
}

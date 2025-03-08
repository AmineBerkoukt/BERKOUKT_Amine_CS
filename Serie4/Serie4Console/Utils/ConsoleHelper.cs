namespace Serie4Console.Utils
{
    using System;

    public static class ConsoleHelper
    {
        public static int GetIntInput(string message)
        {
            Console.Write(message);
            int result; // Declare the result variable here, outside the loop
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Try again: ");
            }

            return result;
        }

        public static string GetStringInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
using System;

namespace Convert {
    class Program {
        static void Main(string[] args) {
            int answer = 0;
            int column = 8;

            while (column >= 1) {
                Console.Write("Enter bit value: ");
                int bit = Int32.Parse(Console.ReadLine());
                answer = answer + (column * bit);
                column = column / 2;
            }
            Console.WriteLine("Decimal value is: {0}", answer);
        }
    }
}

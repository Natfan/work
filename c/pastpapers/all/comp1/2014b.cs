using System;

namespace isbn {
    class Program {
        static void Main(string[] args) {
            int[] ISBN = new int[13];
            int count;
            int calculatedDigit;

            for (count = 1; count < 14; count++) {
                Console.Write("Please enter the next digit of the ISBN: ");
                ISBN[count] = Int32.Parse(Console.ReadLine());
            }
            calculatedDigit = 0;
            count = 1;
            while (count < 15) {
                calculatedDigit = calculatedDigit + ISBN[count];
                count++;
                calculatedDigit = calculatedDigit + ISBN[count] * 3;
                count++;
            }
            while (calculatedDigit >= 10) {
                calculatedDigit = calculatedDigit - 10;
            }
            calculatedDigit = 10 - calculatedDigit;
            if (calculatedDigit == 10) {
                calculatedDigit = 0;
            }
            if (calculatedDigit == ISBN[13]) {
                Console.WriteLine("Valid ISBN");
            } else {
                Console.WriteLine("Invalid ISBN");
            }
        }
    }
}

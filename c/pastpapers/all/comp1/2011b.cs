using System;
namespace english {
    class Program {
        static void Main(string[] args) {
           string[] names = new string[4];
           int max = 3;
           int current = 1;
           bool found = false;

           names[0] = "Ben";
           names[1] = "Thor";
           names[2] = "Zoe";
           names[3] = "Kate";

           Console.Write("What player are you looking for? ");
           string playerName = Console.ReadLine();
           while ((found == false) && (current <= max)) {
               if (names[current] == playerName) {
                   found = true;
               } else {
                   current++;
               }
           }
           if (found == true) {
               Console.WriteLine("Yes, they have a top score.");
           } else {
               Console.WriteLine("No, they do not have a top score.");
           }
        }
    }
}

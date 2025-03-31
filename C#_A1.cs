using System;
using System.Windows.Forms;
using System.IO;

class Program {

    static void Main() {
        Console.WriteLine("Hello, what would you like to do!");
        string operation = "0";
        while (operation != "1" && operation != "2") {
            Console.WriteLine("(1) Write a file");
            Console.WriteLine("(2) Read a file");
            operation = Console.ReadLine();
            if (operation != "1" && operation != "2") {
                Console.WriteLine("Invalid input, please try again");
            }
        }
        if (operation == "1") {
            Write();
        }
        else if (operation == "2") {
            Read();
        }
    }

    static void Write() {
        
    }
    static void Read() {

    }
}

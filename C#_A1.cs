using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

class Program
{

    static void Main()
    {
        Console.WriteLine("Hello, what would you like to do!");
        string operation = "0";
        while (operation != "1" && operation != "2")
        {
            Console.WriteLine("(1) Write a file");
            Console.WriteLine("(2) Read a file");
            operation = Console.ReadLine();
            if (operation != "1" && operation != "2")
            {
                Console.WriteLine("Invalid input, please try again");
            }
        }
        if (operation == "1")
        {
            Console.WriteLine("How many random numbers do you want to include?");
            string num = Console.ReadLine();
            try
            {
                Write(Convert.ToInt32(num));
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else if (operation == "2")
        {
            Read();
        }
    }

    static void Write(int total)
    {
        Random random = new Random();

        int[] rand = new int[total];

        for (int i = 0; i < total; i++)
        {
            rand[i] = random.Next(1, 101);
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text Files |*.txt";
        saveFileDialog.Title = "Save Random Numbers to File";
        saveFileDialog.ShowDialog();
    }
    static void Read()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        openFileDialog.Title = "Select a File to Read";
        openFileDialog.ShowDialog();

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine($"Total numbers in the file: {lines.Length}");

                Console.WriteLine("File Contents:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }

                ListBox listBox = new ListBox();
                listBox.Items.AddRange(lines);

                Label totalLabel = new Label
                {
                    Text = $"Total numbers: {lines.Length}"
                };

                Form form = new Form
                {
                    Text = "File Reader",
                    Width = 400,
                    Height = 300
                };
                form.Controls.Add(totalLabel);
                form.Controls.Add(listBox);

                Application.Run(form);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
        }
    }

using System;
using System.Collections.Generic;
using System.IO;

namespace ShoppingListWithFileIO
{
    class ShoppingList
    {

        static void Main(string[] args)
        {
            string filepath = @"C:\Users\Sampsa\source\repos\ShoppingListWithFileIO\ShoppingListWithFileIO\files\list_to_alepa1.txt";

            ShoppingList listToAlepa = new ShoppingList(filepath);

            listToAlepa.Start();

        }

        public List<string> ShoppingItems;
        public string FilePath;


        public ShoppingList(string filePath)
        {
            this.ShoppingItems = ReadAllLinesFromFile(filePath);
            this.FilePath = filePath;
        }


        public void Start()
        {
            PrintShoppingList(this.ShoppingItems);

            while (true)
            {

                PrintInstructions();
                string userInput = Console.ReadLine();

                if (userInput == "0")
                {
                    Console.WriteLine("Exiting");
                    break;
                }
                else
                {
                    SaveLineToFile(this.FilePath, userInput);

                }
            }

        }


        public void PrintInstructions()
        {
            Console.WriteLine("Please input shopping list item");
            Console.WriteLine("Exit with 0");
        }

        public void PrintShoppingList(List<string> shoppingList)
        {
            if (shoppingList.Count > 0)
            {
                Console.WriteLine("Items in shopping list:");
                foreach (string item in shoppingList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No items in shoppinglist");
            }

        }

        public List<string> ReadAllLinesFromFile(string filepath)
        {

            if (File.Exists(filepath))
            {

                string[] readFromFile = File.ReadAllLines(filepath);
                List<string> listReadFromFile = new List<string>(readFromFile);

                return listReadFromFile;
            }
            else
            {
                return new List<string>();
            }

        }

        public void SaveLineToFile(string filepath, string text)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"File not found, trying to create it");
            }
            try
            {
                using (StreamWriter shoppingListFile = File.AppendText(filepath))
                {
                    shoppingListFile.WriteLine(text);
                    Console.WriteLine("");
                    Console.WriteLine($"Product added: {text}");
                    Console.WriteLine("");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }

    }


}

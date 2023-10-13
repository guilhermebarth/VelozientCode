using Dapper;
using Microsoft.Extensions.Configuration;
using SmartVault.Program.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartVault.Program
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            // Initialize DataBase
            SmartVault.DataGeneration.Program.Main(args);

            Console.WriteLine();
            Console.WriteLine("Verifying the total size");

            // 4 - Requirement
            Console.WriteLine($"The size of all files is {GetAllFileSizes()} bytes");
            Console.WriteLine();


            // 3 - Requirement
            AskingQuestions();


            Console.WriteLine("Finished...");
            Console.ReadLine();

        }

        private static void AskingQuestions()
        {
            Console.WriteLine("Do you want to add a file (y/n)?");
            string letter = Console.ReadLine().ToString();

            if (letter == "y")
            {
                Console.WriteLine("What is the number of your account?");
                string accountNumber = Console.ReadLine().ToString();
                // I will assume it always digit correctly.

                Console.WriteLine("Write the path where the file is. For Example: C:\\users\\myfile.txt");
                string path = Console.ReadLine().ToString();

                try
                {
                    StreamReader sr = new StreamReader(path);
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        if (line.Contains("Smith Property"))
                        {
                            sr.Close();
                            line = null;

                            WriteEveryThirdFileToFile(path, accountNumber);
                        }
                        else
                        {
                            line = sr.ReadLine();
                        }
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    throw new Exception($"Some unexpected error occurred. {e.Message}");
                }
            }
        }

        public static void WriteEveryThirdFileToFile(string pathRandomFile, string accountID)
        {
            try
            {
                Document myThirdDocument = GetThirdDocumentFromSQL(accountID);

                string path = myThirdDocument.FilePath;
                StreamReader thirdDocument = new StreamReader(path);

                string line = thirdDocument.ReadLine();

                StringBuilder myText = new StringBuilder();

                while (line != null)
                {
                    myText.Append(line);
                    line = thirdDocument.ReadLine();
                }

                thirdDocument.Close();

                File.WriteAllText(pathRandomFile, myText.ToString());

                Console.WriteLine("Content changed.");
            }
            catch (Exception e)
            {
                throw new Exception($"Some unexpected error occurred. {e.Message}");
            }
        }

        public static long GetAllFileSizes()
        {
            // TODO: Implement functionality
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            using (var connection = new SQLiteConnection(string.Format(configuration?["ConnectionStrings:DefaultConnection"] ?? "", configuration?["DatabaseFileName"])))
            {
                IEnumerable<Document> myDocs = connection.Query<Document>($"SELECT FILEPATH FROM (SELECT DISTINCT FILEPATH FROM DOCUMENT)");

                long totalSize = 0;

                foreach (Document item in myDocs)
                {
                    // Only in the main text base.
                    FileInfo fileInfo = new FileInfo(item.FilePath);
                    totalSize += fileInfo.Length;
                }

                return totalSize;                
            }
        }

        public static Document GetThirdDocumentFromSQL(string accountId)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            using (var connection = new SQLiteConnection(string.Format(configuration?["ConnectionStrings:DefaultConnection"] ?? "", configuration?["DatabaseFileName"])))
            {
                IEnumerable<Document> myDocs = connection.Query<Document>($"SELECT * FROM Document WHERE AccountId = '{accountId}' LIMIT 3");

                Document myThirdDocument = myDocs.Last();

                return myThirdDocument;
            }
        }
    }
}
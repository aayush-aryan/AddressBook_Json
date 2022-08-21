using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class FileOperation
    {
        public static void ReadFromStreamReader()
        {
            String path = "F:\\bridgelabz_practice\\AddressBook_Json\\AddressBookSystem\\AddressBookFile.txt";
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        String s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
                else
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.FILE_NOT_EXIST, "File Not Exists");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void WriteUsingStreamWriter()
        {
            String path = "F:\\bridgelabz_practice\\AddressBook_Json\\AddressBookSystem\\AddressBookFile.txt";
            try
            {
                if (File.Exists(path))
                {
                    using (StreamWriter sr = File.AppendText(path))
                    {
                        Console.WriteLine("Book Name");
                        sr.Write("Book Name  : ");
                        string bookName = Console.ReadLine();
                        sr.WriteLine(bookName);
                        Console.WriteLine("Enter First Name");
                        sr.Write("First Name  : ");
                        string name = Console.ReadLine();
                        sr.WriteLine(name);
                        Console.WriteLine("Enter Last Name");
                        sr.Write("Last Name  : ");
                        string lname = Console.ReadLine();
                        sr.WriteLine(lname);

                        sr.Close();
                        Console.WriteLine(File.ReadAllText(path));
                    }
                }

                else
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.FILE_NOT_EXIST, "File Not Exists");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void ReadFromCSVReader()
        {
            string importFilePath = "F:\\bridgelabz_practice\\AddressBook_Json\\AddressBookSystem\\ContactData.csv";
            string exportFilePath = "F:\\bridgelabz_practice\\AddressBook_Json\\AddressBookSystem\\exportData.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Read data successfully from contaceData csv.");
                foreach (Contact contactData in records)
                {
                    Console.Write("\t" + contactData.first_name);
                    Console.Write("\t" + contactData.last_name);
                    Console.Write("\t" + contactData.address);
                    Console.Write("\t" + contactData.city);
                    Console.Write("\t" + contactData.state);
                    Console.Write("\t" + contactData.zip);
                    Console.Write("\t" + contactData.phone_number);
                    Console.Write("\t" + contactData.email);
                    Console.WriteLine();
                    Console.WriteLine("*******************************Readin from csv file and Write to csv file **********************************");
                    //Writing csv file

                    using (var writer = new StreamWriter(exportFilePath))
                    using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvExport.WriteRecords(records);
                    }
                }

            }
        }

        static string jsonFilePath = "F:\\bridgelabz_practice\\AddressBook_Json\\AddressBookSystem\\jsonFile.json";
        public static void ReadFromJSONFile()
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            Console.WriteLine(jsonData);
        }
        public static void WriteIntoJSONFile()
        {
            Contact person = new Contact();
            Console.WriteLine("Enter All Details Like: ");
            Console.WriteLine("Enter First_Name: ");
            person.first_name = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            person.last_name = Console.ReadLine();
            Console.WriteLine("Enter Addree :");
            person.address = Console.ReadLine();
            Console.WriteLine("Enter City Name:");
            person.city = Console.ReadLine();
            Console.WriteLine("Enter State Name:");
            person.state = Console.ReadLine();
            Console.WriteLine("Enter pin Number:");
            person.zip = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            person.phone_number = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            person.email = Console.ReadLine();

            var jsonData = JsonConvert.SerializeObject(person);
            if (File.Exists(jsonFilePath))
            {
                File.AppendAllText(jsonFilePath, jsonData + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("File doesn't exists");
            }
        }
    }
}

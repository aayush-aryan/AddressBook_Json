using System;
using System.Collections.Generic;
using System.IO;
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

    }
}

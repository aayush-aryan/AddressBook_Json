using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public static void addBook(string bookName)
        {
            if (!Program.addressBookStore.ContainsKey(bookName))
            {
                Program.addressBookStore.Add(bookName, new List<Contact>());
            }
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

            List<Contact> book = Program.addressBookStore[bookName];
            if (book.Exists(x => x.Equals(person.first_name)))
            {
                Console.WriteLine("Person Allready exist");
            }
            else
            {
                book.Add(person);
                Console.WriteLine("***************************************");
                Console.WriteLine("Your Record Added To :[" + bookName + " Book]");
                Console.WriteLine(person.toString());
            }

        }



        public static void edit(string bookName, string recordNameToEdit)
        {
            if (Program.addressBookStore.ContainsKey(bookName))
            {
                List<Contact> book = Program.addressBookStore[bookName];
                if (book.Exists(x => x.Equals(recordNameToEdit)))
                {
                    Contact record = book.Find(x => x.Equals(recordNameToEdit));
                    Console.WriteLine("Select Which Data You Want To Update \n1.First_Name \n2.Last_Name \n3.Address" +
                                         "\n4.City \n5.State \n6.Zip \n7.PhoneNumber \n8.Email");

                    string selection = Console.ReadLine();
                    string newData;
                    switch (selection)
                    {
                        case "1":
                            Console.WriteLine("Enter First_Name");
                            newData = Console.ReadLine();
                            record.first_name = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "2":
                            Console.WriteLine("Enter Last_Name");
                            newData = Console.ReadLine();
                            record.last_name = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "3":
                            Console.WriteLine("Enter Address");
                            newData = Console.ReadLine();
                            record.address = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "4":
                            Console.WriteLine("Enter City");
                            newData = Console.ReadLine();
                            record.city = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "5":
                            Console.WriteLine("Enter State");
                            newData = Console.ReadLine();
                            record.state = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "6":
                            Console.WriteLine("Enter Zip");
                            newData = Console.ReadLine();
                            record.zip = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "7":
                            Console.WriteLine("Enter PhoneNumber");
                            newData = Console.ReadLine();
                            record.phone_number = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        case "8":
                            Console.WriteLine("Enter Email");
                            newData = Console.ReadLine();
                            record.email = newData;
                            Console.WriteLine("Your Updated  Records :\n" + record.toString());

                            break;
                        default:
                            Console.WriteLine("Invalid Selection Input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("First_Name: " + recordNameToEdit + " not Exist");
                }
            }
            else
            {
                Console.WriteLine("No Such BookAddress Found");
            }
        }


        public static void delete(string bookName)
        {
            if (Program.addressBookStore.ContainsKey(bookName))
            {
                List<Contact> book = Program.addressBookStore[bookName];
                Console.WriteLine("Enter First Name Of Person:");
                string name = Console.ReadLine();
                Contact record = book.Find(x => x.Equals(name));

                if (book.Exists(x => x.Equals(name)))
                {
                    Console.WriteLine("Record Deleted");
                    book.Remove(record);
                }
                else
                {
                    Console.WriteLine("Person not Exist!");
                }
            }
            else
            {
                Console.WriteLine("Book Not Found!");
            }
        }

        public static void searchPersonUsingCityOrStateInMultipleBooks(string cityOrState)
        {
            List<Contact> record = new List<Contact>();
            foreach (string bookName in Program.addressBookStore.Keys)
            {
                record = Program.addressBookStore[bookName];
                foreach (Contact person in record)
                {
                    if (record.Exists(x => x.city == cityOrState || x.state == cityOrState))
                    {
                        Console.WriteLine("Book Name : " + bookName);
                        Console.WriteLine("All Details :" + person.toString());
                    }
                }
            }
        }

        public static int searchNumberOfPersonUsingCityOrStateInMultipleBooks(string cityOrState)
        {
            int count = 0;
            List<Contact> record = new List<Contact>();
            foreach (string bookName in Program.addressBookStore.Keys)
            {
                record = Program.addressBookStore[bookName];
                foreach (Contact person in record)
                {
                    if (person.city == cityOrState || person.state == cityOrState)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static void PrintNameInAlphabeticalOrder(string bookName)
        {
            if (Program.addressBookStore.ContainsKey(bookName))
            {
                List<Contact> book = Program.addressBookStore[bookName];
                //   book.Sort((x, y) => string.Compare(x.first_name, y.first_name));
                Console.WriteLine("Book Name : " + bookName);
                var peopleInOrder = book.OrderBy(person => person.first_name);
                foreach (Contact person in peopleInOrder)
                {
                    Console.WriteLine("All Details :" + person.toString());
                }
            }
            else
            {
                Console.WriteLine("Book Not Found!");
            }
        }

        public static void sortEntriesInAlphabeticalOrderUsingCityStateOrZip(string cityOrStateOrZip, string bookName)
        {
            if (Program.addressBookStore.ContainsKey(bookName))
            {
                List<Contact> record = Program.addressBookStore[bookName];
                Console.WriteLine("Book Name : " + bookName);
                // var orderedRecords = record.OrderBy(c => c.city).ThenBy(c => c.state).ThenBy(c => c.zip);
                switch (cityOrStateOrZip)
                {
                    case "city":
                        var orderedRecords1 = record.OrderBy(person => person.city);
                        foreach (Contact person in orderedRecords1)
                        {
                            Console.WriteLine("All Details :" + person.toString());
                        }
                        break;
                    case "state":
                        var orderedRecords2 = record.OrderBy(person => person.state);
                        foreach (Contact person in orderedRecords2)
                        {
                            Console.WriteLine("All Details :" + person.toString());
                        }
                        break;
                    case "zip":
                        var orderedRecords3 = record.OrderBy(person => person.zip);
                        foreach (Contact person in orderedRecords3)
                        {
                            Console.WriteLine("All Details :" + person.toString());
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
    }
}

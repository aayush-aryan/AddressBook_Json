using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        public static Dictionary<string, List<Contact>> addressBookStore = new Dictionary<string, List<Contact>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBookSystem");
            Console.WriteLine("Wellcome To Address Book System Program!");
            Console.WriteLine("*****************************************");
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine("1.Add Contacts");
                Console.WriteLine("2.Edit Existing Contact");
                Console.WriteLine("3.Delete Person Details");
                Console.WriteLine("5.Search persons using city or state");
                Console.WriteLine("6.Search Number of persons in city or state");
                Console.WriteLine("7.Enter name of the address book you want to  record in sorting order");
                Console.WriteLine("8.To ordered the record by city or state or zip Please enter book name");
                Console.WriteLine("9.To Read Data from file");
                Console.WriteLine("10.To Append Data into file");
                Console.WriteLine("11.To Read Data from CSV file");
                Console.WriteLine("4.close");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of the address book in which you want to add record.");
                        String bookName = Console.ReadLine();
                        AddressBook.addBook(bookName);
                        break;
                    case 2:
                        Console.WriteLine("Enter the book name in which you want to Edit data:");
                        string bookNameHasReocrd = Console.ReadLine();
                        Console.WriteLine("Enter Person's FirstName to edit data:");
                        string recordNameToEdit = Console.ReadLine();
                        AddressBook.edit(bookNameHasReocrd, recordNameToEdit);
                        break;
                    case 3:
                        Console.WriteLine("Enter name of the address book you want to delete record in.");
                        String bookName1 = Console.ReadLine();
                        AddressBook.delete(bookName1);
                        break;
                    case 4:
                        choice = 4;
                        break;
                    case 5:
                        Console.WriteLine("Enter city or state to find a person");
                        string cityOrState = Console.ReadLine();
                        AddressBook.searchPersonUsingCityOrStateInMultipleBooks(cityOrState);
                        break;
                    case 6:
                        Console.WriteLine("Enter city or state to get total number of persons");
                        string cityOrState1 = Console.ReadLine();
                        int numberOfPerson = AddressBook.searchNumberOfPersonUsingCityOrStateInMultipleBooks(cityOrState1);
                        Console.WriteLine("Total number of persons are :" + numberOfPerson);
                        break;
                    case 7:
                        Console.WriteLine("Enter name of the address book you want to  record in sorting order");
                        String bookName2 = Console.ReadLine();
                        AddressBook.PrintNameInAlphabeticalOrder(bookName2);
                        break;
                    case 8:
                        Console.WriteLine("8.To ordered the record by city or state or zip Please enter any one city,state or zip");
                        String cityOrStateOrZip = Console.ReadLine();
                        Console.WriteLine("Enter bookName");
                        string bookName3 = Console.ReadLine();
                        AddressBook.sortEntriesInAlphabeticalOrderUsingCityStateOrZip(cityOrStateOrZip, bookName3);
                        break;
                    case 9:
                        FileOperation.ReadFromStreamReader();
                        break;
                    case 10:
                        FileOperation.WriteUsingStreamWriter();
                        break;
                    case 11:
                        FileOperation.ReadFromCSVReader();
                        break;

                    default:
                        Console.WriteLine("Invalid choice !");
                        break;
                }



            }
        }
    }
}
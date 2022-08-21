using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class Contact
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }

        public string toString()
        {
            return "First_Name: " + first_name + "\nLast_Name: " + last_name + "\nAddress: "
                + address + "\nCity: " + city + "\nState: " + state +
       "\nZIP: " + zip + "\nPhone_Number: " + phone_number + " \nEmail: " + email;

        }
        public bool Equals(string name)
        {
            return this.first_name == name;
        }
    }
}

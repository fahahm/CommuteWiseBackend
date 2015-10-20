using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommuteWise.Model
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string password;
        private string userid;
        private string phone;
        private string streetAddress;
        private string zipCode;
        private string city;
        private string state;

        public User() { }

        /// <summary>
        /// Property First Name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Property Last Name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Property Password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Property UserID
        /// </summary>
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        /// <summary>
        /// Property Phone
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// Property Street Address
        /// </summary>
        public string StreetAddress
        {
            get { return streetAddress; }
            set { firstName = value; }
        }

        /// <summary>
        /// Property Zip Code
        /// </summary>
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        /// <summary>
        /// Property City
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// Property State
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string getUserName()
        {
            return FirstName + ' ' + LastName;
        }
    }
}
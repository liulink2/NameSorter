using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameSorter.Entities
{
    public class Person
    {
        private string GivenName { get; set; }
        private string LastName { get; set; }

        /// <summary>
        /// Get the Last Name and Given Name based on the full name
        /// </summary>
        /// <param name="name">Full Name with format of Given Name - Last Name</param>
        public Person(string name)
        {
            // Split the name by space " "
            var nameParts = name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            // Last part is Last Name
            LastName = nameParts[nameParts.Length - 1];
            // The rest is Given Name
            GivenName = string.Join(" ", nameParts.Take(nameParts.Length - 1).ToArray());
        }

        /// <summary>
        /// Constructor with first name and last name
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        public Person(string firstname, string lastname)
        {
            LastName = lastname.Trim();
            GivenName = firstname.Trim();
        }

        public string GetFullName()
        {
            return $"{GivenName} {LastName}";
        }

        /// <summary>
        /// Return the name by format Last Name - Given Name
        /// </summary>
        /// <returns></returns>
        public string LastNameGivenName()
        {
            return $"{LastName} {GivenName}";
        }

        /// <summary>
        /// To check if a name is valid
        /// Must have last name
        /// Must have given name
        /// Given Name Length <= 3
        /// </summary>
        /// <returns></returns>
        public bool IsValidName()
        {
            return !string.IsNullOrEmpty(LastName) 
                && !string.IsNullOrEmpty(GivenName) 
                && GivenName.Split(' ').Length <= 3;
        }
    }
}

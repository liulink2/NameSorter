using NameSorter.Entities;
using NameSorter.Repo;
using System;
using System.Collections.Generic;

namespace NameSorter.Repo
{
    /// <summary>
    /// Implement the Write Function to Console
    /// </summary>
    public class PersonConsoleData : IWritePerson
    {
        public bool Write(List<Person> persons, string fileName)
        {
            persons.ForEach(person => Console.WriteLine(person.GetFullName()));
            return true;
        }
    }
}

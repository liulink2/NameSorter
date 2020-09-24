using NameSorter.Entities;
using NameSorter.Exceptions;
using NameSorter.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NameSorter.Repo
{
    /// <summary>
    /// Abstract class to implement Read Data from file
    /// Leave the Write abtract to separate between write to file and write to console
    /// </summary>
    public abstract class PersonRepo : IWritePerson, IReadPerson
    {
        /// <summary>
        /// Abstract Write Function
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public abstract bool Write(List<Person> persons, string filename);

        /// <summary>
        /// Implement Read Person from file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of Person</returns>
        public List<Person> Read(string fileName)
        {
            List<Person> persons = new List<Person>();
            var fileText = ReadFileText(fileName);
            //
            if (fileText.Length <= 0)
            {
                Console.WriteLine($"File is empty: {fileName}");
                return persons;
            }
            //
            var rawNames = fileText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (rawNames.Length > 0)
            {
                rawNames = rawNames.Select(p => p.Trim()).ToArray();
            }
            //
            foreach (var name in rawNames)
            {
                persons.Add(new Person(name));
            }
            return persons;
        }

        /// <summary>
        /// Read the text file with given file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>string content of the file</returns>
        private string ReadFileText(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    throw new AppException($"File Not Found: {fileName}");

                return File.ReadAllText(fileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

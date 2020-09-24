using NameSorter.Entities;
using NameSorter.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter.Repo
{
    /// <summary>
    /// This class will inherit the same read function from Person Repo and Override the Write function to file
    /// </summary>
    public class PersonFileData: PersonRepo
    {
        /// <summary>
        /// Override the Write function to file
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public override bool Write(List<Person> persons, string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                    throw new AppException("No provided filename to write to.");

                using (var writer = File.CreateText(fileName))
                {
                    persons.ForEach(person => writer.WriteLine(person.GetFullName()));
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

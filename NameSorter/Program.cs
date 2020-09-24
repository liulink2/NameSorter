using NameSorter.Exceptions;
using NameSorter.Repo;
using NameSorter.Services;
using System;

namespace NameSorter1
{
    class Program
    {
        /// <summary>
        /// Default input and output filename
        /// </summary>
        const string defInputFile = "unsorted-names-list.txt";
        const string defOutputFile = "sorted-names-list.txt";

        static void Main(string[] args)
        {
            string inputFile = "";
            string outputFile = "";
            if (args.Length == 0)
            {
                inputFile = defInputFile;
                outputFile = defOutputFile;
            }
            else if (args.Length == 1)
            {
                inputFile = args[0];
            }
            else
            {
                inputFile = args[0];
                outputFile = args[1];
            }
            //// Main Running Here
            try
            {
                // Read data file
                PersonRepo repo = new PersonFileData();
                var persons = repo.Read(inputFile);
                // Validation
                int invalidCount = 0;
                foreach (var person in persons)
                {
                    if (!person.IsValidName())
                    {
                        Console.WriteLine($"Invalid name: {person.GetFullName()}");
                        invalidCount++;
                    }
                }
                if (invalidCount > 0)
                    throw new AppException($"There are {invalidCount} invalid name(s).");
                // Sort
                ISorter service = new NameSorterSv();
                service.Sort(persons);
                // Write to File
                repo.Write(persons, outputFile);
                // Write to Console
                IWritePerson console = new PersonConsoleData();
                console.Write(persons, "");
            }
            // Catch Custom Exception Here 
            catch (AppException ex)
            {
                Console.WriteLine($"!!!ERROR: {ex.Message}");
            }
            // Other Exception
            catch (Exception)
            {
                throw;
            }
        }
    }
}

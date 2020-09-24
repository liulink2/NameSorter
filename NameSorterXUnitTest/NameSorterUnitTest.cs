using NameSorter.Entities;
using NameSorter.Repo;
using NameSorter.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NameSorter1.Test
{
    public class NameSorterUnitTest
    {
        [Fact]
        public void TestInputCount()
        {
            PersonRepo repo = new PersonFileData();
            var persons = repo.Read("unsorted-names-list.txt");
            Assert.Equal(11, persons.Count);

            persons = repo.Read("unsorted-5000-names-list.txt");
            Assert.Equal(5000, persons.Count);

            persons = repo.Read("unsorted-0-names-list.txt");
            Assert.Empty(persons);
        }

        [Fact]
        public void TestSortName()
        {
            var Janet = "Janet Parsons";
            var Frankie = "Frankie Conner Ritter";
            var Marin = "Marin Alvarez";
            // Create List and Sort
            var persons = new List<Person>() {
                new Person(Frankie),
                new Person(Janet),
                new Person(Marin),
            };
            ISorter service = new NameSorterSv();
            service.Sort(persons);
            // Expected
            Assert.Equal(Marin, persons[0].GetFullName());
            Assert.Equal(Janet, persons[1].GetFullName());
            Assert.Equal(Frankie, persons[2].GetFullName());
        }

        [Fact]
        public void TestSortNameFromFile()
        {
            // Load
            PersonRepo repo = new PersonFileData();
            var persons = repo.Read("unsorted-names-list.txt");            
            Assert.Equal(11, persons.Count);
            // Sort
            ISorter service = new NameSorterSv();
            service.Sort(persons);
            // Expected
            Assert.Equal("Marin Alvarez", persons[0].GetFullName());
            Assert.Equal("Adonis Julius Archer", persons[1].GetFullName());
            Assert.Equal("Beau Tristan Bentley", persons[2].GetFullName());
            Assert.Equal("Hunter Uriah Mathew Clarke", persons[3].GetFullName());
            Assert.Equal("Leo Gardner", persons[4].GetFullName());
            Assert.Equal("Vaughn Lewis", persons[5].GetFullName());
            Assert.Equal("London Lindsey", persons[6].GetFullName());
            Assert.Equal("Mikayla Lopez", persons[7].GetFullName());
            Assert.Equal("Janet Parsons", persons[8].GetFullName());
            Assert.Equal("Frankie Conner Ritter", persons[9].GetFullName());
            Assert.Equal("Shelby Nathan Yoder", persons[10].GetFullName());
        }


        [Fact]
        public void TestOutPutCount()
        {
            PersonRepo repo = new PersonFileData();
            // Test Original File
            var persons = repo.Read("unsorted-names-list.txt");
            Assert.Equal(11, persons.Count);
            //
            ISorter service = new NameSorterSv();
            service.Sort(persons);
            repo.Write(persons, "sorted-names-list.txt");
            //
            var persons2 = repo.Read("sorted-names-list.txt");
            Assert.Equal(11, persons2.Count);

            // Test 5000 names File
            persons = repo.Read("unsorted-5000-names-list.txt");
            Assert.Equal(5000, persons.Count);
            service.Sort(persons);
            repo.Write(persons, "sorted-5000-names-list.txt");
            //
            persons2 = repo.Read("sorted-5000-names-list.txt");
            Assert.Equal(5000, persons2.Count);

            // Test Empty File
            persons = repo.Read("unsorted-0-names-list.txt");
            Assert.Empty(persons);
            service.Sort(persons);
            repo.Write(persons, "sorted-0-names-list.txt");
            //
            persons2 = repo.Read("sorted-0-names-list.txt");
            Assert.Empty(persons2);
        }
    }
}

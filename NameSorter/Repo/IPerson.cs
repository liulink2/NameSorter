using NameSorter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Repo
{
    public interface IPerson
    {
        public List<Person> ReadData(string fileName);
        public void WriteData(List<Person> persons, string fileName);
    }
}

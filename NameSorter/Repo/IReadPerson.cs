using NameSorter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Repo
{
    public interface IReadPerson
    {
        public List<Person> Read(string fileName);
    }
}

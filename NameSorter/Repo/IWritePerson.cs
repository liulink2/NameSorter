using NameSorter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Repo
{
    public interface IWritePerson
    {
        public bool Write(List<Person> persons, string fileName);
    }
}

using NameSorter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public interface ISorter
    {
        public void Sort(List<Person> persons);
    }
}

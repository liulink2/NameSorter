using NameSorter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    public class NameSorterSv : ISorter
    {
        public void Sort(List<Person> persons)
        {
            var nameComparer = Comparer<Person>.Create(
                    (x, y) => string.Compare(x.LastNameGivenName(), y.LastNameGivenName()));
            //
            persons.Sort(nameComparer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_2020_12_08.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual City City { get; set; }
    }
}

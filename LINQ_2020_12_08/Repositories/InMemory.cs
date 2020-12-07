using LINQ_2020_12_08.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_2020_12_08.Repositories
{
    class InMemory
    {
        public List<Person> People { get; set; }
        public List<City> Cities { get; set; }
        public InMemory()
        {
            Cities = new List<City>
            {
                new City{ Id = 1, CityName = "Kraków" },
                new City{ Id = 2, CityName = "Wrocław" },
                new City{ Id = 3, CityName = "Poznań" },
                new City{ Id = 4, CityName = "Warszawa" }
            };
            People = new List<Person>
            {
                new Person { Id = 1, Name = "Krzysztof", LastName = "Sauermann", BirthDate = new DateTime(1984, 04, 14) },
                new Person { Id = 2, Name = "Roman", LastName = "Niepołomski", BirthDate = new DateTime(2000, 04, 14) },
                new Person { Id = 3, Name = "Kasia", LastName = "Stankiewicz", BirthDate = new DateTime(1977, 06, 02) },
                new Person { Id = 4, Name = "Rafał", LastName = "Nowak", BirthDate = new DateTime(1988, 12, 11) },
                new Person { Id = 5, Name = "Konrad", LastName = "Walenrod", BirthDate = new DateTime(1949, 04, 01) },
                new Person { Id = 6, Name = "Norbert", LastName = "Biłgorajski", BirthDate = new DateTime(1984, 03, 20) },
                new Person { Id = 7, Name = "Natalia", LastName = "Bielska", BirthDate = new DateTime(1994, 01, 01) },
                new Person { Id = 8, Name = "Monika", LastName = "Nowak", BirthDate = new DateTime(2005, 03, 14) },
                new Person { Id = 9, Name = "Ewelina", LastName = "Kowalska", BirthDate = new DateTime(2007, 11, 13) },
                new Person { Id = 10, Name = "Łukasz", LastName = "Górski", BirthDate = new DateTime(2007, 11, 13) },
                new Person { Id = 11, Name = "Konstancja", LastName = "Wielicka", BirthDate = new DateTime(1948, 02, 25) }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static System.Console;
using System.Text.Json;
using System.Xml.Linq;

namespace Seryalized
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID;
        const string group = "PV-333";
        public Person() { }
        public Person(int ID)
        {
            this.ID = ID;
        }
        public override string ToString()
        {
            return $"{Name} {Age} {ID} {group}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person(10) { Name = "Sasha", Age = 33 },
                new Person(20) { Name = "Pasha", Age = 30 },
                new Person(45) { Name = "Vasya", Age = 48 }
            };
            string fname = "Person.json";

            foreach (var item in persons)
                WriteLine(item);
            //Serialize
            string p1_json = JsonSerializer.Serialize(persons);
            File.WriteAllText(fname, p1_json);
            WriteLine("Serialize OK");

            WriteLine("********************************************");

            //Deserialize
            string p1_new_str = File.ReadAllText(fname);
            List<Person> p1_new = JsonSerializer.Deserialize<List<Person>>(p1_new_str);
            foreach (var item in p1_new)
                WriteLine(item);
            WriteLine("Deserialize OK");
        }
    }
}
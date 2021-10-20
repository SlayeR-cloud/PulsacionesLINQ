using System;
using System.Collections.Generic;
using Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public class PersonService
    {
        public static List<Person> GetPeople()
        {
            return new List<Person> { new Person("Dave", "123", 28, 'M', 12),
                new Person("Anthony", "124", 29, 'M', 21),
                new Person("Dave", "125", 38, 'M', 12)};
        }
        public static int GetAgeSum()
        {
            var people = GetPeople();
            return (from person in people select person.Age).Sum();
        }
        public static double GetAgeAverage()
        {
            var people = GetPeople();
            return Math.Round((from person in people select person.Age).Average(), 0);
        }
        public static string GetMostSex()
        {
            var people = GetPeople();
            var counter = people.Where(person => person.Sex == 'F').Count();
            var counter2 = people.Where(person => person.Sex == 'M').Count();

            if (counter > counter2)
            {
                return "F";
            }
            else if (counter2 > counter)
            {
                return "M";
            }
            else
            {
                return "F & M";
            }
        }
    }
}
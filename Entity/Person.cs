using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person
    {
        // This class handles all the methods it can, it is an expert in its own field.
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public int Pulsation { get; set; }

        public Person(string name, string id, int age, char sex)
        {
            Name = name;
            Id = id;
            Age = age;
            Sex = sex;
            Pulsation = 0;
        }
        public Person(string name, string id, int age, char sex, int pulsation)
        {
            Name = name;
            Id = id;
            Age = age;
            Sex = sex;
            Pulsation = pulsation;
        }

        public void CalculatePulsation()
        {
            if (Sex == 'M' || Sex == 'm')
            {
                Pulsation = CalculateWithFormule(210, Age);
            }
            else if (Sex == 'F' || Sex == 'f')
            {
                Pulsation = CalculateWithFormule(220, Age);
            }
        }
        public int CalculateWithFormule(int value, int age)
        {
            return (value - age) / 10;
        }
    }
}
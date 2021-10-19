using System;
using System.Collections.Generic;
using System.IO;
using Entity;

namespace DataAccessLayer
{
    // Class in charge of CRUD operations, needs to have Repository in the name
    // name will be EntityRepository
    public class PersonRepository
    {
        private string path = "person.txt";

        public void Save(Person person)
        {
            List<Person> people;
            try
            {
                people = GetQuery();
                if (!ValidateUser(person.Id, people))
                {
                    WriteStream(person);
                }
                else
                {
                    throw new Exception("This person has already exists");
                }
            }
            catch (FileNotFoundException)
            {
                WriteStream(person);
            }
        }
        private void WriteStream(Person person)
        {
            FileStream file = new FileStream(path, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{person.Name};{person.Id};{person.Age}" +
                $";{person.Sex};{person.Pulsation}");
            writer.Close();
            file.Close();
        }

        public void Delete(string id)
        {
            List<Person> people = new List<Person>();
            people = GetQuery();

            FileStream file = new FileStream(path, FileMode.Create);
            file.Close();

            foreach (var item in people)
            {
                if (!item.Id.Equals(id))
                {
                    Save(item);
                }
            }
        }
        public void Modify(string id, Person person)
        {
            bool modify = false;
            List<Person> personas = new List<Person>();
            personas = GetQuery();

            FileStream file = new FileStream(path, FileMode.Create);
            file.Close();

            foreach (var item in personas)
            {
                if (!item.Id.Equals(id))
                {
                    Save(item);
                    continue;
                }
                Save(person);
                modify = true;
            }
            if (!modify)
            {
                throw new Exception("Not found Person");
            }
        }
        public Person Search(string id)
        {
            Person person = null;
            List<Person> people;
            people = GetQuery();

            foreach (var item in people)
            {
                if (item.Id.Equals(id))
                {
                    person = item;
                    break;
                }
            }
            return person;
        }

        public List<Person> GetQuery()
        {
            StreamReader reader = new StreamReader(path);
            List<Person> people = BuildPersonFromStream(reader);
            reader.Close();
            return people;
        }
        private List<Person> BuildPersonFromStream(StreamReader reader)
        {
            List<Person> people = new List<Person>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(";");
                Person person = new Person(data[0], data[1], int.Parse(data[2]),
                    char.Parse(data[3]), int.Parse(data[4]));
                people.Add(person);
            }
            return people;
        }
        private bool ValidateUser(string id, List<Person> people)
        {
            if (people.Count != 0)
            {
                foreach (var person in people)
                {
                    if (person.Id.Equals(id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
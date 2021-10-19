using System;
using Entity;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /*                              Services will help in the next cases:
     * 
     * 1. When we going to do a process with the data:
     * - Verify if the data is completed
     * - Verify if the data satisfy the conditions we
     * need to save them.
     * 
     * 2. When a method is shared (the method has attributes from a class
     * and has other attributes from other class) in this case any of that classes
     * are experts, so we're going to do that method here.
     * 
     * Services will only do calculations when the Entity class is not ready.
     * As long as the Entity class is ready, it will do all the calculations 
     * 
     */

    // This class also has a standard: EntityService
    public class PersonService
    {
        public PersonRepository PersonRepository { get; set; }

        public PersonService()
        {
            PersonRepository = new PersonRepository();
        }

        public string Save(Person person)
        {
            string message;
            try
            {
                PersonRepository.Save(person);
                message = "Saved succesfull";
            }
            catch (Exception e)
            {
                message = "An error ocurred: " + e.Message;
            }
            return message;
        }
        public string Delete(string id)
        {
            string message;

            try
            {
                PersonRepository.Delete(id);
                message = "Deleted succesfull";
            }
            catch (Exception e)
            {
                message = "An error ocurred: " + e.Message;
            }
            return message;
        }
        public string Modify(string id, Person person)
        {
            string message;

            try
            {
                PersonRepository.Modify(id, person);
                message = "Modified succesfull";
            }
            catch (Exception e)
            {
                message = "An error ocurred: " + e.Message;
            }
            return message;
        }
        public Person Search(string id)
        {
            Person person;

            try
            {
                person = PersonRepository.Search(id);
            }
            catch (Exception)
            {
                person = null;
            }
            return person;
        }
        public PersonConsultResponse ConsultResponse()
        {
            try
            {
                return new PersonConsultResponse(PersonRepository.GetQuery());
            }
            catch (Exception e)
            {
                return new PersonConsultResponse("An error ocurred: " + e.Message);
            }
        }
    }
}
using RESTAspNetCore.Model;
using RESTAspNetCore.Services.Interface;

namespace RESTAspNetCore.Services
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;

        }
        private Person MockPerson(int id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "gui" +id,
                Adress = "jd floridiana rio claro" + id,
                LastName = "Silva" + id,
                Gender = "Masculino" + id,
            };
        }

        public Person GetById(int id)
        {
            return new Person()
            {
                Id = 1,
                FirstName = "gui",
                Adress = "jd floridiana rio claro",
                LastName = "Silva",
                Gender = "Masculino",

            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}

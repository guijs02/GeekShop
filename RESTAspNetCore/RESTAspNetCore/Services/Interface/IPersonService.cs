using RESTAspNetCore.Model;

namespace RESTAspNetCore.Services.Interface
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person GetById(int id);
        List<Person> GetAll();
        Person Update(Person person);
        void Delete(int id);
    }
    
}

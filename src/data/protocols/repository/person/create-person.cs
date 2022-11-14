using csharp_crud.Models;
using System.Threading.Tasks;

public interface CreatePersonRepository { 
    Task<PersonResponse> createPerson(PersonRequest personRequest);
}

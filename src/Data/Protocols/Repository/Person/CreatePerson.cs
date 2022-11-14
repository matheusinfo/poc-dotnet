using csharp_crud.Models;

public interface CreatePersonRepository { 
    Task<PersonResponse> createPerson(PersonRequest personRequest);
}

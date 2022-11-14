using csharp_crud.Models;

public interface ICreatePersonRepository { 
    Task<PersonResponse> createPerson(PersonRequest personRequest);
}

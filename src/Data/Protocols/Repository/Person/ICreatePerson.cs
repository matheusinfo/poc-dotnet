using csharp_crud.Models;

public interface ICreatePersonRepository { 
    void createPerson(PersonRequest personRequest);
}

using csharp_crud.Models;

public interface IUpdatePersonRepository { 
    PersonResponse updatePerson(int id, PersonRequest personRequest);
}

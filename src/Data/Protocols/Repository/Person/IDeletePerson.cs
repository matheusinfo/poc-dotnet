using csharp_crud.Models;

public interface IDeletePersonRepository { 
    Task<bool> deletePerson(PersonResponse person);
}

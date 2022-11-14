using csharp_crud.Models;

public interface ILoadPersonsRepository { 
    List<PersonResponse> loadPersons();
}

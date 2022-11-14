using csharp_crud.Models;

public interface ILoadPersonByIdRepository { 
   PersonResponse? loadPersonById(int id);
}

using csharp_crud.Models;
using System.Threading.Tasks;

public interface LoadPersonByIdRepository { 
    Task<PersonResponse> loadPersonById(int id);
}

using System.Threading.Tasks;

public interface DeletePersonRepository { 
    Task<bool> deletePerson(int id);
}

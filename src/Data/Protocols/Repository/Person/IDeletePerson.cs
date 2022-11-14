public interface IDeletePersonRepository { 
    Task<bool> deletePerson(int id);
}

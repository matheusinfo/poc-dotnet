public interface DeletePersonRepository { 
    Task<bool> deletePerson(int id);
}

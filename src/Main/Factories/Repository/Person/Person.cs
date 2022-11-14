using csharp_crud.Repository;

namespace MakePersonRepositoryFactory
{
    public static class PersonRepositoryFactory
    {
        public static void Make(IServiceCollection personRepositoryFactory)
        {
            personRepositoryFactory.AddScoped<ILoadPersonsRepository, PersonRepository>();
            personRepositoryFactory.AddScoped<ILoadPersonByIdRepository, PersonRepository>();
            personRepositoryFactory.AddScoped<ICreatePersonRepository, PersonRepository>();
            personRepositoryFactory.AddScoped<IUpdatePersonRepository, PersonRepository>();
            personRepositoryFactory.AddScoped<IDeletePersonRepository, PersonRepository>();
        }
    }
}
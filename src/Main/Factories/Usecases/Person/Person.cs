using csharp_crud.src.Data.Services.Person;
using csharp_crud.src.Data.Usecases.Person;

namespace MakePersonUsecaseFactory
{
    public static class PersonUsecaseFactory
    {
        public static void Make(IServiceCollection personUsecaseFactory)
        {
            personUsecaseFactory.AddScoped<ILoadPersons, LoadPersonsService>();
            personUsecaseFactory.AddScoped<ILoadPersonById, LoadPersonByIdService>();
            personUsecaseFactory.AddScoped<ICreatePerson, CreatePersonService>();
            personUsecaseFactory.AddScoped<IUpdatePerson, UpdatePersonService>();
            personUsecaseFactory.AddScoped<IDeletePerson, DeletePersonService>();
        }
    }
}
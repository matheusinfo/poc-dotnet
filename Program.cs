using csharp_crud.Repository;
using csharp_crud.src.Data.Services.Person;
using csharp_crud.src.Data.Usecases.Person;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoadPersonsRepository, PersonRepository>();
builder.Services.AddScoped<ILoadPersonByIdRepository, PersonRepository>();
builder.Services.AddScoped<ICreatePersonRepository, PersonRepository>();
builder.Services.AddScoped<IUpdatePersonRepository, PersonRepository>();
builder.Services.AddScoped<IDeletePersonRepository, PersonRepository>();
builder.Services.AddScoped<ILoadPersons, LoadPersonsService>();
builder.Services.AddScoped<ILoadPersonById, LoadPersonByIdService>();
builder.Services.AddScoped<ICreatePerson, CreatePersonService>();
builder.Services.AddScoped<IUpdatePerson, UpdatePersonService>();
builder.Services.AddScoped<IDeletePerson, DeletePersonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

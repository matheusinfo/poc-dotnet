using csharp_crud.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoadPersonsRepository, PersonRepository>();
builder.Services.AddScoped<LoadPersonByIdRepository, PersonRepository>();
builder.Services.AddScoped<CreatePersonRepository, PersonRepository>();
builder.Services.AddScoped<UpdatePersonRepository, PersonRepository>();
builder.Services.AddScoped<DeletePersonRepository, PersonRepository>();

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

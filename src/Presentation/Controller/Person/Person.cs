using csharp_crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace csharp_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly LoadPersonsRepository _loadPersonsRepository;
    private readonly LoadPersonByIdRepository _loadPersonByIdRepository;
    private readonly CreatePersonRepository _createPersonRepository;
    private readonly UpdatePersonRepository _updatePersonRepository;
    private readonly DeletePersonRepository _deletePersonRepository;

    public PersonController(
        LoadPersonsRepository loadPersonsRepository,
        LoadPersonByIdRepository loadPersonByIdRepository,
        CreatePersonRepository createPersonRepository,
        UpdatePersonRepository updatePersonRepository,
        DeletePersonRepository deletePersonRepository
    )
    {
        _loadPersonsRepository = loadPersonsRepository;
        _loadPersonByIdRepository = loadPersonByIdRepository;
        _createPersonRepository = createPersonRepository;
        _updatePersonRepository = updatePersonRepository;
        _deletePersonRepository = deletePersonRepository;
    }

    [HttpGet]
    public async Task<IActionResult> LoadPersons()
    {
        try
        {
            var persons = await _loadPersonsRepository.loadPersons();
            return persons.Any() ? Ok(persons) : NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> LoadPersonById(int id)
    {
        try
        {
            var person = await _loadPersonByIdRepository.loadPersonById(id);
            return Ok(person);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] PersonRequest personRequest)
    {
        var person = await _createPersonRepository.createPerson(personRequest);
        return CreatedAtAction(nameof(LoadPersonById), new { id = person.id }, person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonRequest personRequest)
    {
        try
        {
            var person = await _updatePersonRepository.updatePerson(id, personRequest);
            return Ok(person);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        try
        {
            await _deletePersonRepository.deletePerson(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}

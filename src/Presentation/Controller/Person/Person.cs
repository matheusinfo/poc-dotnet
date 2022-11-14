using csharp_crud.Models;
using Microsoft.AspNetCore.Mvc;
using csharp_crud.src.Data.Usecases.Person;

namespace csharp_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILoadPersons _loadPersons;
    private readonly ILoadPersonById _loadPersonById;
    private readonly ICreatePerson _createPerson;
    private readonly IUpdatePerson _updatePerson;
    private readonly IDeletePerson _deletePerson;

    public PersonController(
        ILoadPersons loadPersons,
        ILoadPersonById loadPersonById,
        ICreatePerson createPerson,
        IUpdatePerson updatePerson,
        IDeletePerson deletePerson
    )
    {
        _loadPersons = loadPersons;
        _loadPersonById = loadPersonById;
        _createPerson = createPerson;
        _updatePerson = updatePerson;
        _deletePerson = deletePerson;
    }

    [HttpGet]
    public async Task<IActionResult> LoadPersons()
    {
        try
        {
            var persons = await _loadPersons.loadPersons();
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
            var person = await _loadPersonById.loadPersonById(id);
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
        var person = await _createPerson.createPerson(personRequest);
        return CreatedAtAction(nameof(LoadPersonById), new { id = person.id }, person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonRequest personRequest)
    {
        try
        {
            var person = await _updatePerson.updatePerson(id, personRequest);
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
            await _deletePerson.deletePerson(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}

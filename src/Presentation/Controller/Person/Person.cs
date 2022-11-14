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
    public IActionResult LoadPersons()
    {
        try
        {
            var persons = _loadPersons.loadPersons();
            return Ok(persons);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult LoadPersonById(int id)
    {
        try
        {
            var person = _loadPersonById.loadPersonById(id);
            return Ok(person);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult CreatePerson([FromBody] PersonRequest personRequest)
    {
        _createPerson.createPerson(personRequest);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePerson(int id, [FromBody] PersonRequest personRequest)
    {
        try
        {
            var person = _updatePerson.updatePerson(id, personRequest);
            return Ok(person);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        try
        {
            _deletePerson.deletePerson(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}

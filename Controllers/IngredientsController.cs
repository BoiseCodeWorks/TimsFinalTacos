using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using timsfinaltacos.Models;
using timsfinaltacos.Services;

namespace timsfinaltacos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _service;
    public IngredientsController(IngredientsService service)
    {
      _service = service;
    }

    //GET
    [HttpGet]
    public ActionResult<IEnumerable<Ingredient>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //GETBYID
    [HttpGet("{Id}")]
    public ActionResult<Ingredient> Get(int Id)
    {
      try
      {
        return Ok(_service.Get(Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Ingredient> Post([FromBody] Ingredient newIngredient)
    {
      try
      {
        return Ok(_service.Create(newIngredient));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<Ingredient> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //PUT
    [HttpPut("{id}")]
    public ActionResult<Ingredient> Edit([FromBody] Ingredient newIngredient, int id)
    {
      try
      {
        newIngredient.Id = id;
        return Ok(_service.Edit(newIngredient));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using timsfinaltacos.Models;
using timsfinaltacos.Services;

namespace timsfinaltacos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TacoIngredientsController : ControllerBase
  {
    private readonly TacoIngredientsService _service;
    public TacoIngredientsController(TacoIngredientsService service)
    {
      _service = service;
    }

    //POST
    [HttpPost]
    public ActionResult<DTOTacoIngredient> Post([FromBody] DTOTacoIngredient newDTOTacoIngredient)
    {
      try
      {
        return Ok(_service.Create(newDTOTacoIngredient));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<DTOTacoIngredient> Delete(int id)
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


  }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using timsfinaltacos.Models;
using timsfinaltacos.Services;

namespace timsfinaltacos.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TacosController : ControllerBase
  {
    private readonly TacosService _service;
    private readonly TacoIngredientsService _tis;
    public TacosController(TacosService service, TacoIngredientsService tis)
    {
      _service = service;
      _tis = tis;
    }

    //GET
    [HttpGet]
    public ActionResult<IEnumerable<Taco>> Get()
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
    [HttpGet("{tacoId}")]
    public ActionResult<Taco> Get(int tacoId)
    {
      try
      {
        return Ok(_service.Get(tacoId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //GETIngredientsByTacoID
    [HttpGet("{tacoId}/ingredients")]
    public ActionResult<IEnumerable<TacoIngredient>> GetIngsByTacoId(int tacoId)
    {
      try
      {
        return Ok(_tis.GetIngsByTacoId(tacoId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //POST
    [HttpPost]
    public ActionResult<Taco> Post([FromBody] Taco newTaco)
    {
      try
      {
        return Ok(_service.Create(newTaco));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<Taco> Delete(int id)
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
    public ActionResult<Taco> Edit([FromBody] Taco newTaco, int id)
    {
      try
      {
        newTaco.Id = id;
        return Ok(_service.Edit(newTaco));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
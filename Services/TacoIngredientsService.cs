using System;
using System.Collections.Generic;
using timsfinaltacos.Models;
using timsfinaltacos.Repositories;

namespace timsfinaltacos.Services
{
  public class TacoIngredientsService
  {
    private readonly TacoIngredientsRepository _repo;
    public TacoIngredientsService(TacoIngredientsRepository repo)
    {
      _repo = repo;
    }

    public DTOTacoIngredient Get(int Id)
    {
      DTOTacoIngredient exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid tacoingredient mi amigo"); }
      return exists;
    }
    public DTOTacoIngredient Create(DTOTacoIngredient newTacoIngredient)
    {
      int id = _repo.Create(newTacoIngredient);
      newTacoIngredient.Id = id;
      return newTacoIngredient;
    }

    public DTOTacoIngredient Delete(int id)
    {
      DTOTacoIngredient exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public IEnumerable<TacoIngredient> GetIngsByTacoId(int id)
    {
      return _repo.GetIngsByTacoId(id);
    }
  }
}
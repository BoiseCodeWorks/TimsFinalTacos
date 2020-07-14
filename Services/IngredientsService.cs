using System;
using System.Collections.Generic;
using timsfinaltacos.Models;
using timsfinaltacos.Repositories;

namespace timsfinaltacos.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;
    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Ingredient> Get()
    {
      return _repo.Get();
    }

    public Ingredient Get(int Id)
    {
      Ingredient exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("Invalid ingredient mi amigo"); }
      return exists;
    }

    public Ingredient Create(Ingredient newIngredient)
    {
      int id = _repo.Create(newIngredient);
      newIngredient.Id = id;
      return newIngredient;
    }

    public Ingredient Delete(int id)
    {
      Ingredient exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Ingredient Edit(Ingredient editIngredient)
    {
      Ingredient original = Get(editIngredient.Id);
      original.Name = editIngredient.Name.Length > 0 ? editIngredient.Name : original.Name;
      original.KCal = editIngredient.KCal > 0 ? editIngredient.KCal : original.KCal;
      return _repo.Edit(original);
    }
  }
}
using System;
using System.Collections.Generic;
using timsfinaltacos.Models;
using timsfinaltacos.Repositories;

namespace timsfinaltacos.Services
{
  public class TacosService
  {
    private readonly TacosRepository _repo;
    public TacosService(TacosRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Taco> Get()
    {
      return _repo.Get();
    }

    public Taco Get(int tacoId)
    {
      Taco exists = _repo.GetById(tacoId);
      if (exists == null) { throw new Exception("Invalid taco mi amigo"); }
      return exists;
    }

    public Taco Create(Taco newTaco)
    {
      int id = _repo.Create(newTaco);
      newTaco.Id = id;
      return newTaco;
    }

    public Taco Delete(int id)
    {
      Taco exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public Taco Edit(Taco editTaco)
    {
      Taco original = Get(editTaco.Id);
      original.Name = editTaco.Name.Length > 0 ? editTaco.Name : original.Name;
      original.Price = editTaco.Price > 0 ? editTaco.Price : original.Price;
      original.Description = editTaco.Description.Length > 0 ? editTaco.Description : original.Description;
      return _repo.Edit(original);
    }
  }
}
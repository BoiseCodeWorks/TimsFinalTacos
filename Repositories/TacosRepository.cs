using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using timsfinaltacos.Models;

namespace timsfinaltacos.Repositories
{
  public class TacosRepository
  {
    private readonly IDbConnection _db;
    public TacosRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Taco> Get()
    {
      string sql = "SELECT * FROM tacos";
      return _db.Query<Taco>(sql);
    }

    internal Taco GetById(int tacoId)
    {
      string sql = "SELECT * FROM tacos WHERE id = @tacoId";
      return _db.QueryFirstOrDefault<Taco>(sql, new { tacoId });
    }

    internal int Create(Taco newTaco)
    {
      string sql = @"
        INSERT INTO tacos
        (description, name, price)
        VALUES
        (@Description, @Name, @Price);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newTaco);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM tacos WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal Taco Edit(Taco original)
    {
      string sql = @"
        UPDATE tacos
        SET
            name = @Name,
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM tacos WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Taco>(sql, original);
    }
  }
}
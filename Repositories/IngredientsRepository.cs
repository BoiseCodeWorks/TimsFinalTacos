using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using timsfinaltacos.Models;

namespace timsfinaltacos.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Ingredient> Get()
    {
      string sql = "SELECT * FROM ingredients";
      return _db.Query<Ingredient>(sql);
    }

    internal Ingredient GetById(int Id)
    {
      string sql = "SELECT * FROM ingredients WHERE id = @Id";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new { Id });
    }

    internal int Create(Ingredient newIngredient)
    {
      string sql = @"
        INSERT INTO ingredients
        (kcal, name)
        VALUES
        (@Kcal, @Name);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newIngredient);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM ingredients WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal Ingredient Edit(Ingredient original)
    {
      string sql = @"
        UPDATE ingredients
        SET
            name = @Name,
            kcal = @Kcal
        WHERE id = @Id;
        SELECT * FROM ingredients WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Ingredient>(sql, original);
    }
  }
}
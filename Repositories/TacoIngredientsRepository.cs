using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using timsfinaltacos.Models;

namespace timsfinaltacos.Repositories
{
  public class TacoIngredientsRepository
  {
    private readonly IDbConnection _db;
    public TacoIngredientsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal DTOTacoIngredient GetById(int Id)
    {
      string sql = "SELECT * FROM tacoingredients WHERE id = @Id";
      return _db.QueryFirstOrDefault<DTOTacoIngredient>(sql, new { Id });
    }

    internal int Create(DTOTacoIngredient newDTOTacoIngredient)
    {
      string sql = @"
        INSERT INTO tacoingredients
        (tacoId, ingId)
        VALUES
        (@TacoId, @IngId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newDTOTacoIngredient);
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM tacoingredients WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal IEnumerable<TacoIngredient> GetIngsByTacoId(int id)
    {
      string sql = @"
        SELECT
            i.*,
            ti.id as tacoIngId
        FROM tacoingredients ti
        INNER JOIN ingredients i ON i.id = ti.ingId
        WHERE(ti.tacoId = @id)
        ";
      return _db.Query<TacoIngredient>(sql, new { id });
    }
  }
}
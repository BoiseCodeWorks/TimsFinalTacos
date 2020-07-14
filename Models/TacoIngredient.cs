using System.Collections.Generic;

namespace timsfinaltacos.Models
{

  //data transfer object
  public class DTOTacoIngredient
  {
    public int Id { get; set; }
    public int TacoId { get; set; }
    public int IngId { get; set; }
  }

  //   public class TacoIngredient : DTOTacoIngredient
  //   {
  // public Taco Taco { get; set; }
  // public Ingredient Ingredient { get; set; }
  //   }
}
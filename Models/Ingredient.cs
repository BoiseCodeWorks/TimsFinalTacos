namespace timsfinaltacos.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    public int KCal { get; set; }
    public string Name { get; set; }
  }


  public class TacoIngredient : Ingredient
  {
    public int TacoIngId { get; set; }
  }
}
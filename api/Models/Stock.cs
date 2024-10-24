using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Stock
{
   public int Id { get; set; }
   public string Symbol { get; set; } = String.Empty;
   public string CompanyName { get; set; } = String.Empty;
   
   // Limit the number of decimal places to 2.
   [Column(TypeName = "decimal(18,2)")]
   public decimal Price { get; set; }
   
   public decimal LastDividend { get; set; }
   public string Industry { get; set; } = String.Empty;
   public long MarketCap { get; set; }
   
   // Relationship with Comment.
   public List<Comment> Comments { get; set; } = new List<Comment>();
   
}
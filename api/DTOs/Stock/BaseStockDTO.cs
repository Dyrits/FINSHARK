using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Stock;

public class BaseStockDTO: PartialStockDTO
{
    [Required]
    [MaxLength(8, ErrorMessage = "Symbol must not be more than 8 characters long.")]
    public new string Symbol { get; set; } = String.Empty;
    
    [Required]
    [MaxLength(64, ErrorMessage = "Company name must not be more than 64 characters long.")]
    public new string CompanyName { get; set; } = String.Empty;
    
    [Required]
    [Range(1, 1_000_000_000)]
    public new decimal Price { get; set; }
    
    [Required]
    [Range(0.001, 100)]
    public new decimal LastDividend { get; set; }
    
    [Required]
    [MaxLength(16, ErrorMessage = "Industry must not be more than 16 characters long.")]
    public new string Industry { get; set; } = String.Empty;
    
    [Required]
    [Range(1, 10_000_000_000)]
    public new long MarketCap { get; set; }
}
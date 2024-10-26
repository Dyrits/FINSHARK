namespace api.DTOs.Stock;

public class PartialStockDTO
{
    public string? Symbol { get; set; }
    public string?  CompanyName { get; set; }
    public decimal? Price { get; set; }
    public decimal? LastDividend { get; set; }
    public string?  Industry { get; set; }
    public long? MarketCap { get; set; }
}
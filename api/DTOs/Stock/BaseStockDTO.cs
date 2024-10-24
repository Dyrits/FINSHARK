namespace api.DTOs.Stock;

public class BaseStockDTO
{
    public string Symbol { get; set; } = String.Empty;
    public string CompanyName { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public decimal LastDividend { get; set; }
    public string Industry { get; set; } = String.Empty;
    public long MarketCap { get; set; }
}
namespace api.DTOs.Stock;

public class BaseStockDTO: PartialStockDTO
{
    public new string Symbol { get; set; } = String.Empty;
    public new string CompanyName { get; set; } = String.Empty;
    public new decimal Price { get; set; }
    public new decimal LastDividend { get; set; }
    public new string Industry { get; set; } = String.Empty;
    public new long MarketCap { get; set; }
}
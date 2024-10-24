using api.DTOs.Stock;
using api.Models;

namespace api.Mappers;

public static class StockMappers
{
    public static IdentifiedStockDTO ToStockDTO(this Stock stock)
    {
        return new IdentifiedStockDTO
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Price = stock.Price,
            LastDividend = stock.LastDividend,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap
        };
    }

    public static Stock ToStock(this BaseStockDTO stock)
    {
        return new Stock
        {
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Price = stock.Price,
            LastDividend = stock.LastDividend,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap
        };
    }

    public static void UpdateFrom(this Stock stock, BaseStockDTO data)
    {
        stock.Symbol = data.Symbol;
        stock.CompanyName = data.CompanyName;
        stock.Price = data.Price;
        stock.LastDividend = data.LastDividend;
        stock.Industry = data.Industry;
        stock.MarketCap = data.MarketCap;
    }
}
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
            MarketCap = stock.MarketCap,
            Comments = stock.Comments.Select(comment => comment.ToCommentDTO()).ToList()
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

    public static void UpdateFrom(this Stock stock, PartialStockDTO data)
    {
        stock.Symbol = data.Symbol ?? stock.Symbol;
        stock.CompanyName = data.CompanyName ?? stock.CompanyName;
        stock.Price = data.Price ?? stock.Price;
        stock.LastDividend = data.LastDividend ?? stock.LastDividend;
        stock.Industry = data.Industry ?? stock.Industry;
        stock.MarketCap = data.MarketCap ?? stock.MarketCap;
    }
}
namespace api.Models;

public class Comment
{
    public Comment() { }
    public Comment(Stock stock)
    {
        Stock = stock;
        StockId = Stock.Id;
    }

    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Relationship with Stock.
    public int StockId { get; set; }
    public Stock Stock { get; set; }
}
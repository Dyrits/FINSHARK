using api.Models;

namespace api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAll();
    Task<Stock?> GetById(int id);
    Task<Stock> Create(Stock stock);
    Task<Stock> Update(Stock stock);
    Task Delete(Stock stock);
}
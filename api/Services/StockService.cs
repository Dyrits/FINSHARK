using api.DTOs.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _repository;

    public StockService(IStockRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<IdentifiedStockDTO>> GetAll()
    {
        var stocks = await _repository.GetAll();
        return stocks.Select(stock => stock.ToStockDTO()).ToList();
    }

    public async Task<IdentifiedStockDTO?> GetById(int id)
    {
        var stock = await _repository.GetById(id);
        return stock?.ToStockDTO();
    }

    public async Task<IdentifiedStockDTO> Create(BaseStockDTO data)
    {
        var stock = await _repository.Create(data.ToStock());
        return stock.ToStockDTO();
    }

    public async Task<IdentifiedStockDTO?> Update(int id, PartialStockDTO data)
    {
        var stock = await _repository.GetById(id);
        if (stock == null)
        {
            return null;
        }
        stock.UpdateFrom(data);
        stock = await _repository.Update(stock);
        return stock.ToStockDTO();
    }

    public async Task<bool> Delete(int id)
    {
        var stock = await _repository.GetById(id);
        if (stock == null)
        {
            return false;
        }
        await _repository.Delete(stock);
        return true;
    }
}
using api.DTOs.Stock;
using api.Models;

namespace api.Interfaces;

public interface IStockService
{
    Task<List<IdentifiedStockDTO>> GetAll();
    Task<IdentifiedStockDTO?> GetById(int id);
    Task<IdentifiedStockDTO> Create(BaseStockDTO data);
    Task<IdentifiedStockDTO?> Update(int id, PartialStockDTO data);
    Task<bool> Delete(int id);
}
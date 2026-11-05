using BookingSystemMoUS.Domain.Models;

namespace BookingSystemMoUS.Application.Interfaces;
public interface IEquipmentModelRepository
{
    public Task<List<EquipmentModel>> GetAllAsync();
    public Task<EquipmentModel?> GetByNameAsync(string equipmentName);
}

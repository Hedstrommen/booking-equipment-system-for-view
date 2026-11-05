using BookingSystemMoUS.Application.Interfaces;
using BookingSystemMoUS.Domain.Models;
using BookingSystemMoUS.Domain.ValueObjects;

namespace BookingSystemMoUS.Infrastructure.Repository;
public class EquipmentModelRepository : IEquipmentModelRepository
{
    //Min fake-databas med utrustningsmodeller.
    private readonly List<EquipmentModel> _modelsList = new List<EquipmentModel>
    {
        new EquipmentModel("Grävmaskin\t", new DailyPrice(1000)),
        new EquipmentModel("Gräsklippare", new DailyPrice(300)),
        new EquipmentModel("Högtryckstvätt", new DailyPrice(500))
    };

    //För att hämta alla
    public async Task<List<EquipmentModel>> GetAllAsync()
    {
        return _modelsList;
    }

    //För att hämta specifik utrustning baserat på namn. 
    public async Task<EquipmentModel?> GetByNameAsync(string equipmentName)
    {
        if (string.IsNullOrWhiteSpace(equipmentName))
            return null;
        
        equipmentName = equipmentName.Trim().ToUpper();
        
        foreach (EquipmentModel model in _modelsList)
        {
            if (model.EquipmentName.Trim().ToUpper() == equipmentName)
            {
                return model;
            }
        }
        return null;
    }
}

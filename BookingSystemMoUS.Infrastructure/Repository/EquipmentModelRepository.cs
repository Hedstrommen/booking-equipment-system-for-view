using BookingSystemMoUS.Application.Interfaces;
using BookingSystemMoUS.Domain.Models;

namespace BookingSystemMoUS.Infrastructure.Repository;
public class EquipmentModelRepository : IEquipmentModelRepository
{
    private readonly List<EquipmentModel> _modelsList = new List<EquipmentModel>
    {
        new EquipmentModel("Grävmaskin", 1000),
        new EquipmentModel("Gräsklippare", 300),
        new EquipmentModel("Högtryckstvätt", 500)
    };

    //För att hämta alla
    public async Task<List<EquipmentModel>> GetAllAsync()
    {
        return _modelsList;
    }

    //För att hämta specifik utrustning baserat på namn. 
    public async Task<EquipmentModel?> GetByNameAsync(string equipmentName)
    {
        foreach (EquipmentModel model in _modelsList)
        {
            if (model.EquipmentName == equipmentName)
            {
                return model;
            }
        }
        return null;
    }
}

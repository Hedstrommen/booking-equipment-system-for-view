
using BookingSystemMoUS.Domain.Models;

namespace BookingSystemMoUS.Infrastructure.Repository;
public class EquipmentModelRepository
{
    private readonly List<EquipmentModel> _modelsList = new List<EquipmentModel>
    {
        new EquipmentModel("Grävmaskin", 1000),
        new EquipmentModel("Gräsklippare", 300),
        new EquipmentModel("Högtryckstvätt", 500)
    };
}


namespace BookingSystemMoUS.Domain.Models;
public class EquipmentModel (string equipmentName, int dailyPrice)
{
    public string EquipmentName { get; set; } = equipmentName;
    public int DailyPrice { get; set; } = dailyPrice;
}

namespace BookingSystemMoUS.Domain.Models;
public class EquipmentModel (string equipmentName, decimal dailyPrice)
{
    public string EquipmentName { get; set; } = equipmentName;
    public decimal DailyPrice { get; set; } = dailyPrice;
}

using BookingSystemMoUS.Domain.ValueObjects;

namespace BookingSystemMoUS.Domain.Models;
public class EquipmentModel (string equipmentName, DailyPrice dailyPrice)
{
    public string EquipmentName { get; set; } = equipmentName;
    public DailyPrice DailyPrice { get; set; } = dailyPrice;
}
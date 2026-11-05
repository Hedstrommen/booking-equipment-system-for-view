using BookingSystemMoUS.Domain.ValueObjects;

namespace BookingSystemMoUS.Application.Dtos;
//Record för att visa resultatet på beräkningen till UI. Använder Record för att spegla ett resultat som inte ska kunna ändras. 
public record PriceResultRecord
(
    string EquipmentName,
    DailyPrice DailyPrice,
    DateOnly StartDate,
    DateOnly EndDate,
    int RentDays,
    decimal TotalPrice
);

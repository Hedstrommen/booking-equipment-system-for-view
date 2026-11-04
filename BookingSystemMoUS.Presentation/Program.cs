using BookingSystemMoUS.Application.Interfaces;
using BookingSystemMoUS.Application.Services;
using BookingSystemMoUS.Domain.Services;
using BookingSystemMoUS.Infrastructure.Repository;
using BookingSystemMoUS.Presentation;
using Microsoft.Extensions.DependencyInjection;

//1. Skapa en tom behållare för services
ServiceCollection services = new ServiceCollection();

//2. Registrerar vilka klasser som vill ha vad och stoppar in i services 
services.AddSingleton<IEquipmentModelRepository, EquipmentModelRepository>();
services.AddSingleton<PriceCalculationService>();
services.AddSingleton<CalculateTotalPriceService>();
services.AddSingleton<ConsoleUI>();

//3. Bygg ihop allting
IServiceProvider provider = services.BuildServiceProvider();

//4. Hämta ConsolUI
ConsoleUI ui = provider.GetRequiredService<ConsoleUI>();

//5. Kör programmet genom klassen RunProgramAsync();
await ui.RunProgramAsync();




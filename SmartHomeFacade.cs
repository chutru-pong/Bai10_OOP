//Ngô Trường Phúc 202418964
using System;

namespace SmartHome
{
    // Facade
    public sealed class SmartHomeFacade
    {
        private readonly IDevice  light;
        private readonly IDevice  fan;
        private readonly ILockable door;

        public SmartHomeFacade(IDevice light, IDevice fan, ILockable door)
        {
            this.light = light;
            this.fan   = fan;
            this.door  = door;
        }
        
        // tắt đèn, tắt quạt, khóa cửa
        public void GoToWork()
        {
            HomeConfiguration cfg = HomeConfiguration.Instance;
            Console.WriteLine("[" + cfg.HomeName + "] Chế độ ra ngoài");
            light.TurnOff();
            fan.TurnOff();
            door.Lock();
        }

        // tắt quạt, bật đèn ngủ mờ, khóa cửa
        public void GoToSleep()
        {
            HomeConfiguration cfg = HomeConfiguration.Instance;
            Console.WriteLine("[" + cfg.HomeName + "] Chế độ ngủ (độ sáng: " + cfg.NightLightLevel + "%)");
            fan.TurnOn();
            light.TurnOn();   
            door.Lock();
        }
    }
}


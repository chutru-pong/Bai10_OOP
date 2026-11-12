//Ngô Trường Phúc 202418964
using System;

namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HomeConfiguration cfg = HomeConfiguration.Instance;
            cfg.HomeName = "Nhà của Phúc";
            Console.WriteLine("Cấu hình: " + cfg.HomeName + " | Đèn ngủ: " + cfg.NightLightLevel + "%");
            Console.WriteLine();

            IDevice light = DeviceFactory.Create("light", "Đèn phòng khách");
            IDevice fan   = DeviceFactory.Create("fan",   "Quạt trần");
            IDevice doorD = DeviceFactory.Create("door",  "Cửa chính");
            ILockable door = (ILockable)doorD;

            bool t1 = light is SmartLight && fan is SmartFan && doorD is SmartDoor;
            Console.WriteLine("T1 " + (t1 ? "Đạt" : "Thất bại") + ": Factory trả về đúng kiểu đối tượng");

            try
            {
                IDevice cam = DeviceFactory.Create("camera", "Camera1");
                Console.WriteLine("T2 Thất bại: không có ngoại lệ");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("T2 Đạt: " + ex.Message);
            }

            HomeConfiguration cfg2 = HomeConfiguration.Instance;
            bool t3 = Object.ReferenceEquals(cfg, cfg2);
            Console.WriteLine("T3 " + (t3 ? "Đạt" : "Thất bại") + ": hai biến cùng tham chiếu một đối tượng");

            SmartHomeFacade facade = new SmartHomeFacade(light, fan, door);

            facade.GoToWork();
            facade.GoToSleep();
        }
    }
}

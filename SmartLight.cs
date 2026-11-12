//Ngô Trường Phúc 202418964
using System;

namespace SmartHome
{
    public class SmartLight : IDevice
    {
        private string name;

        public SmartLight(string name)
        {
            this.name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine("Đèn \"" + name + "\" đã bật.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Đèn \"" + name + "\" đã tắt.");
        }
    }
}


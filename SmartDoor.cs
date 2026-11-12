//Ngô Trường Phúc 202418964
using System;

namespace SmartHome
{
    public class SmartDoor : IDevice, ILockable
    {
        private string name;

        public SmartDoor(string name)
        {
            this.name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine("Cửa \"" + name + "\" đã mở.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Cửa \"" + name + "\" đã đóng.");
        }

        public void Lock()
        {
            Console.WriteLine("Cửa \"" + name + "\" đã khóa.");
        }

        public void Unlock()
        {
            Console.WriteLine("Cửa \"" + name + "\" đã mở khóa.");
        }
    }
}


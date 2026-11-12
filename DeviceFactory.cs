//Ngô Trường Phúc 202418964
using System;

namespace SmartHome
{
    public static class DeviceFactory
    {
        public static IDevice Create(string type, string name)
        {
            switch (type.ToLower())
            {
                case "light": return new SmartLight(name);
                case "fan":   return new SmartFan(name);
                case "door":  return new SmartDoor(name);
                default:
                    throw new ArgumentException("Loại thiết bị không hợp lệ: " + type);
            }
        }
    }
}


//Ngô Trường Phúc 202418964
using System;

namespace SmartHome
{
    // Singleton
    public sealed class HomeConfiguration
    {
        private static readonly Lazy<HomeConfiguration> lazy = new Lazy<HomeConfiguration>(() => new HomeConfiguration());
        
        // Truy cập instance duy nhất qua thuộc tính này
        public static HomeConfiguration Instance
        {
            get { return lazy.Value; }
        }

        public string HomeName { get; set; }
        public int NightLightLevel { get; set; }

        private HomeConfiguration()
        {
            HomeName = "Nhà của Phúc";
            NightLightLevel = 30;
        }
    }
}


using System.IO;
using System.Reflection;

namespace Framework.Drivers
{
    public class Configuration
    {
        public object DesiredCapabilities;
        public object DriverServices;
        public double PageLoadTimeout = 30000;
        public string START_URL = "https://google.com";
        public string DRIVER_EXE_FOLDER
        {
            get
            {
                return Path.GetFullPath(Path.Combine(Path.GetFullPath(Assembly.GetExecutingAssembly().Location), @"..\..\..\DriverExecutables"));
            }
        }

    }
}
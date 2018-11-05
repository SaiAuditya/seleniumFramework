namespace Framework.Drivers
{
    public interface IDrivers
    {
        void InitDriver(Configuration config);
        object Driver { get; set; }
        object DesiredCapabilities { get; }
        object DriverServices { get; }
    }
}

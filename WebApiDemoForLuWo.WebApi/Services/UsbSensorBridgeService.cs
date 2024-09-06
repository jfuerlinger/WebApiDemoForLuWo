namespace WebApiDemoForLuWo.WebApi.Services
{
    public class UsbSensorBridgeService
    {
        internal double SensorValue { get; private set; }

        internal void PerformMeasurement()
        {
            SensorValue = Random.Shared.NextDouble();
        }
    }
}

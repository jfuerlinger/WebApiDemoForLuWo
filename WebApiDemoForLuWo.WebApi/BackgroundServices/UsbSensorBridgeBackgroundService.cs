
using WebApiDemoForLuWo.WebApi.Services;

namespace WebApiDemoForLuWo.WebApi.BackgroundServices
{
    public class UsbSensorBridgeBackgroundService(
        ILogger<UsbSensorBridgeBackgroundService> logger,
        UsbSensorBridgeService usbSensorBridgeService)
        : BackgroundService
    {
        //LuWo: Das Auslesen des SensorValue, wenn ich den UsbSensorBridgetBackgroundService
        //      mir im Controller injezieren lasse liefert immer 0 -> Property wurde
        //      nie initialisiert.
        internal double SensorValue { get; private set; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                logger.LogInformation("UsbSensorBridget started ...");
                while (!stoppingToken.IsCancellationRequested)
                {
                    logger.LogInformation("Reading the sensor values ...");
                    SensorValue = Random.Shared.NextDouble();
                    usbSensorBridgeService.PerformMeasurement();

                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
                logger.LogInformation("UsbSensorBridget stopped.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in UsbSensorBridge");
            }
        }
    }
}

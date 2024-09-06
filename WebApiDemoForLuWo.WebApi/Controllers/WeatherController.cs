using Microsoft.AspNetCore.Mvc;
using WebApiDemoForLuWo.WebApi.BackgroundServices;
using WebApiDemoForLuWo.WebApi.Services;

namespace WebApiDemoForLuWo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController(
        ILogger<WeatherController> logger,
        //UsbSensorBridgeBackgroundService usbSensorBridgeBackgroundService,
        UsbSensorBridgeService usbSensorBridgeService)
        : ControllerBase
    {

        [HttpGet(Name = "GetMeasurement")]
        public ActionResult<double> GetMeasurement()
        {
            logger.LogInformation("GetMeasurement ...");
            // LuWo: Funktioniert nicht -> immer 0!
            //double value = usbSensorBridgeBackgroundService.SensorValue;

            double value = usbSensorBridgeService.SensorValue;
            logger.LogInformation("GetMeasurement completed.");

            return value;
        }
    }
}

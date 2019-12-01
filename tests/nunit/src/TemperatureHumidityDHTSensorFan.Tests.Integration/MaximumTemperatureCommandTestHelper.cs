using System;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class MaximumTemperatureCommandTestHelper : SerialCommandTestHelper
  {
    public int MaximumTemperature = 30;

    public void TestMaximumTemperatureCommand ()
    {      
      Key = "U";
      Value = MaximumTemperature.ToString ();
      Label = "maximum temperature";

      TestCommand ();
    }
  }
}

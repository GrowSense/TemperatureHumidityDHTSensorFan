using System;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class MinimumTemperatureCommandTestHelper : SerialCommandTestHelper
  {
    public int MinimumTemperature = 30;

    public void TestMinimumTemperatureCommand ()
    {
      Key = "S";
      Value = MinimumTemperature.ToString ();
      Label = "minimum temperature";

      TestCommand ();
    }
  }
}

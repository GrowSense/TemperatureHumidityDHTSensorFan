using System;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class MinimumHumidityCommandTestHelper : SerialCommandTestHelper
  {
    public int MinimumHumidity = 30;

    public void TestMinimumHumidityCommand ()
    {      
      Key = "G";
      Value = MinimumHumidity.ToString ();
      Label = "minimum humidity";

      TestCommand ();
    }
  }
}

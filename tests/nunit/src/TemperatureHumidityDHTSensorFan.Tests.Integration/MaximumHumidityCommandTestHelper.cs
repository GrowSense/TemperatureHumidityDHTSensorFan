using System;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class MaximumHumidityCommandTestHelper : SerialCommandTestHelper
  {
    public int MaximumHumidity = 30;

    public void TestMaximumHumidityCommand ()
    {
      Key = "J";
      Value = MaximumHumidity.ToString ();
      Label = "maximum humidity";

      TestCommand ();
    }
  }
}

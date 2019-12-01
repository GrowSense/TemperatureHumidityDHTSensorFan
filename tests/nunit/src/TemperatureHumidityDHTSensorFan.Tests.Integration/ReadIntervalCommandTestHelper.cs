using System;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class ReadIntervalCommandTestHelper : SerialCommandTestHelper
  {
    public int ReadingInterval = 5;

    public void TestSetReadIntervalCommand ()
    {
      Key = "I";
      Value = ReadingInterval.ToString ();
      Label = "reading interval";

      TestCommand ();
    }
  }
}

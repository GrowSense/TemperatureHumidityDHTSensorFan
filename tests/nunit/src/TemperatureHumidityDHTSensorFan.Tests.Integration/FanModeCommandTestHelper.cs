using System;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class FanModeCommandTestHelper : SerialCommandTestHelper
  {
    public FanMode FanMode = FanMode.Auto;

    public void TestFanCommand ()
    {      
      Key = "M";
      Value = ((int)FanMode).ToString ();
      Label = "fan mode";
      ValueIsSavedInEEPROM = false; // TODO: Save the fan mode in EEPROM in the sketch then change this to true

      TestCommand ();
    }
  }
}

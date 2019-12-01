using System;
using NUnit.Framework;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  [TestFixture(Category="Integration")]
  public class DeviceNameCommandTestFixture : BaseTestFixture
  {
    [Test]
    public void Test_SetDeviceNameCommand ()
    {
      using (var helper = new SerialCommandTestHelper ()) {
        helper.Label = "Device name";
        helper.Value = "ventilator" + new Random ().Next (100).ToString ();
        helper.Key = "Name";
        helper.ValueIsOutputAsData = true;
        helper.RequiresResetSettings = false;
        helper.SeparateKeyValueWithColon = true;
        helper.CheckExpectedSerialOutput = true;

        helper.DevicePort = GetDevicePort ();
        helper.DeviceBaudRate = GetDeviceSerialBaudRate ();

        helper.SimulatorPort = GetSimulatorPort ();
        helper.SimulatorBaudRate = GetSimulatorSerialBaudRate ();

        helper.TestCommand ();
      }
    }
  }
}


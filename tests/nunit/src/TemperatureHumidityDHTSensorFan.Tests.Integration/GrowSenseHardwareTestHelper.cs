using System;
using System.Threading;
using NUnit.Framework;

namespace TemperatureHumidityDHTSensorFan.Tests.Integration
{
  public class GrowSenseHardwareTestHelper : HardwareTestHelper
  {
    public int RawValueMarginOfError = 25;
    public int CalibratedValueMarginOfError = 3;
    public double TimeErrorMargin = 0.3;
    public bool CalibrationIsReversedByDefault = true;
    public bool RequiresResetSettings = true;

    public GrowSenseHardwareTestHelper ()
    {
    }
    #region Enable Devices Functions
    public override void ConnectDevices (bool enableSimulator)
    {
      Console.WriteLine ("Connecting devices...");

      base.ConnectDevices (enableSimulator);

      PrepareDeviceForTest ();
    }
    #endregion
    #region Prepare Device Functions
    public virtual void PrepareDeviceForTest ()
    {
      PrepareDeviceForTest (true);
    }

    public virtual void PrepareDeviceForTest (bool consoleWriteDeviceOutput)
    {
      Console.WriteLine ("Preparing device for test...");

      if (RequiresResetSettings) {
        ResetDeviceSettings ();

        SetDeviceReadInterval (3);
      }

      if (consoleWriteDeviceOutput)
        ReadFromDeviceAndOutputToConsole ();
    }
    #endregion
    #region General Device Command Settings
    public void SendDeviceCommand (string command)
    {
      WriteToDevice (command);

      WaitForMessageReceived (command);
    }

    public void WaitForMessageReceived (string message)
    {
      Console.WriteLine ("");
      Console.WriteLine ("Waiting for message: " + message);

      WaitForText ("Received message: " + message);
    }
    #endregion
    #region Specific Device Command Functions
    public void ResetDeviceSettings ()
    {
      var cmd = "X";

      Console.WriteLine ("");
      Console.WriteLine ("Resetting device default settings...");
      Console.WriteLine ("  Sending '" + cmd + "' command to device");
      Console.WriteLine ("");

      SendDeviceCommand (cmd);
    }

    public void SetDeviceReadInterval (int numberOfSeconds)
    {
      var cmd = "I" + numberOfSeconds;

      Console.WriteLine ("");
      Console.WriteLine ("Setting device read interval to " + numberOfSeconds + " second(s)...");
      Console.WriteLine ("  Sending '" + cmd + "' command to device");
      Console.WriteLine ("");

      SendDeviceCommand (cmd);
    }
    #endregion
  }
}

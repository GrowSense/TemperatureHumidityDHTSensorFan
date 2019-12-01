#include <Arduino.h>
#include <EEPROM.h>

#include "Common.h"
#include "TemperatureHumidityDHTSensor.h"
#include "Ventilation.h"
#include "DeviceName.h"

void serialPrintDeviceInfo()
{  
  Serial.println("");
  Serial.println("-- Start Device Info");
  Serial.println("Family: GrowSense");
  Serial.println("Group: ventilator");
  Serial.println("Project: TemperatureHumidityDHTSensorFan");
  Serial.print("Device name: ");
  Serial.println(deviceName);
  Serial.print("Board: ");
  Serial.println(BOARD_TYPE);
  Serial.print("Version: ");
  Serial.println(VERSION);
  Serial.println("ScriptCode: ventilator");
  Serial.println("-- End Device Info");
  Serial.println("");
}

void serialPrintData()
{
  bool isTimeToPrintData = millis() - lastSerialOutputTime >= secondsToMilliseconds(serialOutputIntervalInSeconds)
      || lastSerialOutputTime == 0;

  bool isReadyToPrintData = isTimeToPrintData && temperatureHumidityDHTSensorReadingHasBeenTaken;

  if (isReadyToPrintData)
  {
    bool ventilationIsNeeded = checkVentilationIsNeeded();

    Serial.print("D;"); // This prefix indicates that the line contains data.
    Serial.print("Name:");
    Serial.print(deviceName);
    Serial.print(";");
    Serial.print("A:");
    Serial.print((int)temperatureValue);
    Serial.print("c ");
    Serial.print((int)humidityValue);
    Serial.print("%");
    Serial.print(";");
    Serial.print("T:");
    Serial.print(temperatureValue);
    Serial.print(";");
    Serial.print("U:");
    Serial.print(maxTemperature);
    Serial.print(";");
    Serial.print("S:");
    Serial.print(minTemperature);
    Serial.print(";");
    Serial.print("H:");
    Serial.print(humidityValue);
    Serial.print(";");
    Serial.print("G:");
    Serial.print(minHumidity);
    Serial.print(";");
    Serial.print("J:");
    Serial.print(maxHumidity);
    Serial.print(";");
    Serial.print("M:");
    Serial.print(fanMode);
    Serial.print(";");
    Serial.print("I:");
    Serial.print(temperatureHumidityDHTSensorReadingIntervalInSeconds);
    Serial.print(";");
    Serial.print("VN:"); // Ventilation needed
    Serial.print(ventilationIsNeeded);
    Serial.print(";");
    Serial.print("FO:"); // Fan on
    Serial.print(fanIsOn);
    Serial.print(";");
    Serial.print("V:");
    Serial.print(VERSION);
    Serial.print(";;");
    Serial.println();


/*    if (isDebugMode)
    {
      Serial.print("Last pump start time:");
      Serial.println(pumpStartTime);
      Serial.print("Last pump finish time:");
      Serial.println(lastPumpFinishTime);
    }*/

    lastSerialOutputTime = millis();
  }
/*  else
  {
    if (isDebugMode)
    {    
      Serial.println("Not ready to serial print data");

      Serial.print("  Is time to serial print data: ");
      Serial.println(isTimeToPrintData);
      if (!isTimeToPrintData)
      {
        Serial.print("    Time remaining before printing data: ");
        Serial.print(millisecondsToSecondsWithDecimal(lastSerialOutputTime + secondsToMilliseconds(serialOutputIntervalInSeconds) - millis()));
        Serial.println(" seconds");
      }
      Serial.print("  Soil moisture sensor reading has been taken: ");
      Serial.println(soilMoistureSensorReadingHasBeenTaken);
      Serial.print("  Is ready to print data: ");
      Serial.println(isReadyToPrintData);

    }
  }*/
}

void forceSerialOutput()
{
    // Reset the last serial output time 
    lastSerialOutputTime = 0;//millis()-secondsToMilliseconds(serialOutputIntervalInSeconds);
}

#include <Arduino.h>
#include <EEPROM.h>
#include <duinocom2.h>

#include "Common.h"
#include "Commands.h"
#include "TemperatureHumidityDHTSensor.h"
#include "SerialOutput.h"
#include "Ventilation.h"
#include "DeviceName.h"

void setup()
{
  Serial.begin(9600);

  Serial.println("Starting DHT ventilator");
  Serial.println("");
  
  loadDeviceNameFromEEPROM();
  
  serialPrintDeviceInfo();

  setupTemperatureHumidityDHTSensor();

  setupVentilation();

  serialOutputIntervalInSeconds = temperatureHumidityDHTSensorReadingIntervalInSeconds;

  Serial.println("Online");

  delay(2000);
}

void loop()
{
// Disabled. Used for debugging
//  Serial.print(".");

  if (isDebugMode)
    loopNumber++;

  serialPrintLoopHeader();

  checkCommand();

  takeTemperatureHumidityDHTSensorReading();

  serialPrintData();

  ventilateIfNeeded();

  serialPrintLoopFooter();
  
  delay(1);
}


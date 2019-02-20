//Checking to ensure you can connect ESP-12E to a router
#include <ESP8266HTTPClient.h>
#include <ESP8266WiFi.h>
#include <stdlib.h>

const char* ssid     = "HUAWEI-B310-5FA4";
const char* password = "NTM06LGFF47";

int wifiStatus;

void setup() {

  Serial.begin(115200); 
  delay(200);
  // We start by connecting to a WiFi network
  Serial.println();
  Serial.println();
  Serial.print("Your are connecting to;");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(100);
    Serial.print(".");
  }

}

void loop() {
  wifiStatus = WiFi.status();

  if (wifiStatus == WL_CONNECTED) {
    Serial.println("");
    Serial.println("Your ESP is connected!");
    Serial.println("Your IP address is: ");
    Serial.println(WiFi.localIP());

    HTTPClient http;    //Declare object of class HTTPClient
 
    String url = "http://192.168.8.100/WristBandApp/api/sensor?id=1&data=rndData";
    http.begin(url);      //Specify request destination
    http.addHeader("Content-Type", "text/plain");  //Specify content-type header
  
    int httpCode = http.GET();   //Send the request
    delay(3000);
    String payload = http.getString();                  //Get the response payload
  
    Serial.println(url);   //Print HTTP return code
    Serial.println(payload);    //Print request response payload
  
    http.end();  //Close connection
  }
  else {
    Serial.println("");
    Serial.println("WiFi not connected");
  }
  delay(1000); // check for connection every once a second
}

int my_random(int min, int max)
{
  return rand() % (max - min + 1) + min;
}

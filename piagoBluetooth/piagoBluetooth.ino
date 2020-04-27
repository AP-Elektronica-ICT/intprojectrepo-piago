#include "BluetoothSerial.h"                            // Header File for Serial Bluetooth,
                                                        // will be added by default into Arduino

BluetoothSerial ESP_BT;                                 // Object for Bluetooth

int pin1 = 25;                                          // Parallel load
int ledPin = 26;                                        // CLK
int pin2 = 33;
int incoming;
String bin = "";                                        // Strings to store data
String pack0 = "";
String pack1 = "";
/*String pack2 = "";
String pack3 = "";*/
int sen0 = 34;
int sen1 = 35;
/*int sen2 = 1;
int sen3 = 4;*/

const int freq = 2000000;
const int ledChannel = 0;
const int resolution = 0;

void callback(esp_spp_cb_event_t event, esp_spp_cb_param_t *param){
  if(event == ESP_SPP_SRV_OPEN_EVT){
    Serial.println("Client Connected");
  }
}

void shiftToBin(){                                      // Function to assign binary values to the keys
  // Keys 1 to 8                                        // given by the shift registers
  if(String(pack0[0]) == "0"){bin = bin + "00110 ";}
  if(String(pack0[1]) == "0"){bin = bin + "00101 ";}
  if(String(pack0[2]) == "0"){bin = bin + "00100 ";}
  if(String(pack0[3]) == "0"){bin = bin + "00000 ";}
  if(String(pack0[4]) == "0"){bin = bin + "00001 ";}
  if(String(pack0[5]) == "0"){bin = bin + "00010 ";}
  if(String(pack0[6]) == "0"){bin = bin + "00011 ";}
  if(String(pack0[7]) == "0"){bin = bin + "00111 ";}

  // Keys 9 to 16
  if(String(pack1[0]) == "0"){bin = bin + "01101 ";}
  if(String(pack1[1]) == "0"){bin = bin + "01100 ";}
  if(String(pack1[2]) == "0"){bin = bin + "01011 ";}
  if(String(pack1[3]) == "0"){bin = bin + "00111 ";}
  if(String(pack1[4]) == "0"){bin = bin + "01000 ";}
  if(String(pack1[5]) == "0"){bin = bin + "01001 ";}
  if(String(pack1[6]) == "0"){bin = bin + "01010 ";}
  if(String(pack1[7]) == "0"){bin = bin + "01111 ";}
/*
  // Keys 17 to 24
  if(String(pack2[0]) == "0"){bin = bin + "10000";}
  if(String(pack2[1]) == "0"){bin = bin + "10010";}
  if(String(pack2[2]) == "0"){bin = bin + "100100";}
  if(String(pack2[3]) == "0"){bin = bin + "10011";}
  if(String(pack2[4]) == "0"){bin = bin + "10100";}
  if(String(pack2[5]) == "0"){bin = bin + "10101";}
  if(String(pack2[6]) == "0"){bin = bin + "10110";}
  if(String(pack2[7]) == "0"){bin = bin + "10111";}

  // Keys 25 to 32
  if(String(pack3[0]) == "0"){bin = bin + "11000";}
  if(String(pack3[1]) == "0"){bin = bin + "11001";}
  if(String(pack3[2]) == "0"){bin = bin + "11010";}
  if(String(pack3[3]) == "0"){bin = bin + "11011";}
  if(String(pack3[4]) == "0"){bin = bin + "11100";}
  if(String(pack3[5]) == "0"){bin = bin + "11101";}
  if(String(pack3[6]) == "0"){bin = bin + "11110";}
  if(String(pack3[7]) == "0"){bin = bin + "11111";}
*/}

void keyReader(){
  pack0 = pack0 + String(digitalRead(sen0));             // Read sensor pins
  pack1 = pack1 + String(digitalRead(sen1));
/*  pack2 = pack2 + String(digitalRead(sen2));
  pack3 = pack3 + String(digitalRead(sen3));*/
}

void btFunc(){
  if (ESP_BT.available() != 0){                          // Check if we receive anything from Bluetooth
    incoming = ESP_BT.read();                            // Read what we recevive
    Serial.print("Received:"); Serial.println(incoming);
  }
    ESP_BT.println(bin);
}

void setup() {
  Serial.begin(115200);                                 // Bauds for Serial monitor
  pinMode(sen0, INPUT);                                 // Pinmodes for the sensor pins
  pinMode(sen1, INPUT);
/*  pinMode(sen2, INPUT);                               // Support for more keys, not used in testing
  pinMode(sen3, INPUT);*/
  pinMode(pin1, OUTPUT);
  pinMode(pin2, OUTPUT);

  ledcSetup(ledChannel, freq, resolution);
  ledcAttachPin(ledPin, ledChannel);
  
  ESP_BT.register_callback(callback);
  ESP_BT.begin("PiaGO");                                // Name of your Bluetooth Signal
  Serial.println("Bluetooth Device is Ready to Pair");  // Show when ready on Terminal
}

void loop() {
  digitalWrite(pin2, HIGH);                             // Command signals to shift registers
  digitalWrite(pin1, LOW);
  delay(1);
  digitalWrite(pin1, HIGH);  
  digitalWrite(pin2, LOW);
  
  for(int i = 0; i<8; i++){                             // The loop for gathering sensor data
    ledcWrite(ledChannel, 255);                         // Clock used for shift registers
    delay(1);
    keyReader();
    ledcWrite(ledChannel, 0);
    delay(1);
  }

  shiftToBin();                                         // Turn the signals from the sensors into binaries
  btFunc();                                             // Call the function which sends the binary package

  bin = "";                                             // Clear the variables for the next run through
  pack0 = "";
  pack1 = "";
  /*pack2 = "";
  pack3 = "";*/
}

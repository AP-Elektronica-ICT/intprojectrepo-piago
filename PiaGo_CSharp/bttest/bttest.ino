/**
 * Simple routine that performs the following:
 *  1. Configures the software UART on pins 2 and 4 (RX,TX)
 *  2. Increments a 32-bit variable every 500ms
 *  4. If it receives a '1' character from bluetooth, it toggles an LED
 *     
 *  @author Justin Bauer - mcuhq.com
 *  @date 4.24.2016
 */

#include <SoftwareSerial.h> // use the software uart
SoftwareSerial bluetooth(2, 4); // RX, TX

unsigned long previousMillis = 0;        // will store last time
const long interval = 500;           // interval at which to delay
static uint32_t tmp; // increment this

void setup() {
  pinMode(13, OUTPUT); // for LED status
  bluetooth.begin(9600); // start the bluetooth uart at 9600 which is its default
  Serial.begin(9600);
  delay(1000); // wait for voltage stabilize
  //bluetooth.print("Piago is the best!"); // place your name in here to configure the bluetooth name.
                                       // will require reboot for settings to take affect. 
  delay(3000); // wait for settings to take affect. 
}

void loop() {
  if (bluetooth.available()) { // check if anything in UART buffer
    if(bluetooth.read() == '1'){ // did we receive this character?
       digitalWrite(13,!digitalRead(13)); // if so, toggle the onboard LED
    }
  }
  
  //unsigned long currentMillis = millis();
  //if (currentMillis - previousMillis >= interval) {
   // previousMillis = currentMillis;

   while(Serial.available()){
    bluetooth.print(Serial.read());
   }
    delay(1000);
    bluetooth.print("001101");
    delay(100);
    bluetooth.print("001101");
    delay(100);
    bluetooth.print("001101");
    delay(100);
    bluetooth.print("001011");
    delay(1000);
    bluetooth.print("001101");
    delay(1000);
    bluetooth.print("001111");
    delay(1000);
    bluetooth.print("001111");
    
    //bluetooth.print(tmp++);
    //if(tmp==10){
    //  tmp=0;// print this to bluetooth module
    //}
  //}

}

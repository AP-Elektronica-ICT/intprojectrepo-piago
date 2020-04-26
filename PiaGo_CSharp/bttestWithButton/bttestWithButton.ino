
#include <SoftwareSerial.h> 
SoftwareSerial bluetooth(2, 4); // RX, TX
    

//INIT BUTTONS
int buttonPin10=10;
int buttonPin9=9;
int buttonPin8=8;
int buttonState10=0;
int buttonState9=0;
int buttonState8=0;

long lastDebounceTime=0;
long debounceDelay=100;



void setup() {
  pinMode(13, OUTPUT); 
  bluetooth.begin(9600); 
  Serial.begin(9600);
  delay(1000); 

  pinMode(buttonPin10,INPUT);
  pinMode(buttonPin9,INPUT);
  pinMode(buttonPin8,INPUT);
  delay(3000); // wait for settings to take affect. 

  
}

void loop() {
   buttonState10=digitalRead(buttonPin10);
   buttonState9=digitalRead(buttonPin9);
   buttonState8=digitalRead(buttonPin8);
   
  
   if((millis()-lastDebounceTime)>debounceDelay){
    
   if(buttonState10==HIGH){
    bluetooth.println("00010");
    lastDebounceTime = millis();
   }
   if(buttonState9==HIGH){
    bluetooth.println("00001");
    lastDebounceTime = millis();
   }
   if(buttonState8==HIGH){
    bluetooth.println("00000");
    lastDebounceTime = millis();
   }

   while(Serial.available()){
    bluetooth.print(Serial.read());
   }
   }
   

}

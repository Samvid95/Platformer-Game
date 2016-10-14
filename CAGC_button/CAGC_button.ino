#include <Keyboard.h>

/*
This is code that I use in my class Costumes as Game Controllers to teach building switches using Adafruit's FLORA. 
It's a mash up of the following examples:

    DigitalInputPull example on the Arduino IDE.
    Arduino Debounce Tutorial http://arduino.cc/en/Tutorial/Debounce
    Arduino Mouse Keyboard http://arduino.cc/en/Reference/MouseKeyboard
 */

// constants won't change. They're used here to 
// set pin numbers:
const int buttonPin1 = 6;  // the number of the pushbutton pin
const int buttonPin2 = 10;
const int ledPin =  7;      // the number of the LED pin

// variables will change:
int buttonState1 = 0;         // variable for reading the pushbutton status
int lastButtonState1 = 0;   //FOR DEBOUNCING

int buttonState2 = 0;
int lastButtonState2 = 0;

void setup() {
  // initialize the LED pin as an output:aaaaaaaaaaaaaaa
  pinMode(ledPin, OUTPUT);      
  // initialize the pushbutton pin as an input:
  pinMode(buttonPin1, INPUT_PULLUP);   
  pinMode(buttonPin2, INPUT_PULLUP);
  
  Keyboard.begin(); // FOR KEYBOARD STROKE
}

void loop(){
  // read the state of the pushbutton value:
  buttonState1 = digitalRead(buttonPin1);
  buttonState2 = digitalRead(buttonPin2);

  // check if the pushbutton is pressed.
  // if it is, the buttonState is LOW:                     
  //if (buttonState == LOW) {     
  if (buttonState1 == LOW && lastButtonState1 == LOW && buttonState2 == LOW && lastButtonState2 == LOW) {  //FOR DEBOUNCING 
    // turn LED on: 
    Keyboard.press(' '); //FOR KEYBOARD STROKE
    digitalWrite(ledPin, HIGH);  
  } 
  else {    
    // turn LED off:
    Keyboard.release(' ');//FOR KEYBOARD STROKE
    digitalWrite(ledPin, LOW); 
  }
    lastButtonState1 = buttonState1;
    lastButtonState2 = buttonState2;///FOR DEBOUNCING





  if (buttonState2 == LOW && lastButtonState2 == LOW) {  //FOR DEBOUNCING 
    // turn LED on: 
    Keyboard.press('x'); //FOR KEYBOARD STROKE
    digitalWrite(ledPin, HIGH);  
  } 
  else {    
    // turn LED off:
    Keyboard.release('x');//FOR KEYBOARD STROKE
    digitalWrite(ledPin, LOW); 
  }
    lastButtonState2 = buttonState2; ///FOR DEBOUNCING
}                                                                                                                                                                                                                                                                                                                                                      

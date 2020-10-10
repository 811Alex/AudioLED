int colour = 0;
int redLed = 9;
int greenLed = 10;
int blueLed = 11;
int onLed = 13;
int flag = 0;
bool resetDone = true;

void setup() {
  Serial.begin(9600);
  pinMode(redLed, OUTPUT);
  pinMode(greenLed, OUTPUT);
  pinMode(blueLed, OUTPUT);
  pinMode(onLed, OUTPUT);
  digitalWrite(onLed, HIGH);
}

void loop() {
  if(!resetDone && millis() % 1000 == 0){
    if(flag == 0) reset();
    else flag = 0;
  }
  if(Serial.available() > 0){
    resetDone = false;
    flag++;
    switch(colour){
      case 0: analogWrite(redLed, Serial.parseInt()); break;
      case 1: analogWrite(greenLed, Serial.parseInt()); break;
      case 2: analogWrite(blueLed, Serial.parseInt()); break;
      case 3: if(Serial.read() != '|') reset(); break;
    }
    if(colour<3) colour++;
    else colour = 0;
  }
}

void reset(){  
  analogWrite(redLed, 0);
  analogWrite(greenLed, 0);
  analogWrite(blueLed, 0);
  colour = 0;
  resetDone = true;
}

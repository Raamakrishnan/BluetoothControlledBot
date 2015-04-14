void setup() {
  Serial.begin(9600);
  pinMode(3,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(9,OUTPUT);
  pinMode(11,OUTPUT);
  
  
  // put your setup code here, to run once:

}

void loop() {
  // put your main code here, to run repeatedly:
if(Serial.available())
{digitalWrite(3,LOW);
 digitalWrite(5,LOW);
digitalWrite(9,LOW);
digitalWrite(11,LOW);
  char a=Serial.read();
  if(a=='B')
  {
    
    digitalWrite(3,HIGH);
    digitalWrite(11,HIGH);
  }
  else if(a=='D')
  {
        digitalWrite(3,HIGH);
    digitalWrite(11,LOW);
  }
  else if(a=='A')
  {
        digitalWrite(5,HIGH);
    digitalWrite(9,HIGH);

  }
  else if(a=='C')
  {
        digitalWrite(5,HIGH);
    digitalWrite(11,HIGH);

  }
}
delay(100);
}

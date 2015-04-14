void setup() {
  Serial.begin(9600);         \\Motor pins
  pinMode(3,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(9,OUTPUT);
  pinMode(11,OUTPUT);
  

}

void loop() {
  // put your main code here, to run repeatedly:
if(Serial.available())
{ digitalWrite(3,LOW);
  digitalWrite(5,LOW);
  digitalWrite(9,LOW);
  digitalWrite(11,LOW);
  char a=Serial.read();
  if(a=='A')
  {
    
    digitalWrite(3,HIGH);     \\ Go Forward 
    digitalWrite(11,HIGH);
  }
  else if(a=='C')
  {
    digitalWrite(3,HIGH);     \\ Turn Left
    digitalWrite(9,HIGH);
  }
  else if(a=='B')
  {
    digitalWrite(5,HIGH);     \\ Go Backwards
    digitalWrite(9,HIGH);

  }
  else if(a=='C')
  {
    digitalWrite(5,HIGH);     \\ Turn Right
    digitalWrite(11,HIGH);

  }
}
delay(100);
}

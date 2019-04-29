var hex_,i,turn,sum;
sum=0

hex_=argument0

for(i=0;i<6;i+=1)
{
turn=string_char_at(hex_,5-i)
if ord(turn)>=97
{
turn='1'+chr(ord(turn)-49)
}
sum+=power(16,i)*real(turn)
}

return sum

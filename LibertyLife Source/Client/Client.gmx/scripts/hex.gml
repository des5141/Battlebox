var str,tmp_str;
str=""
argument0=floor(argument0)
while(argument0>=1)
{tmp_str= argument0 mod 16
if(tmp_str>9){str=string_insert(chr(87+tmp_str),str,1)}
else{str=string_insert(chr(48+tmp_str),str,1)}
argument0=argument0>>4;}
return str

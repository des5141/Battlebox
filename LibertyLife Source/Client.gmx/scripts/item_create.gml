//item_create(type,index,point,condition,count,color1,color2,color3)

var cit;
cit=string(argument0)

if argument1>=100{cit+=string(argument1)}
if argument1>=10 and argument1<100{cit+='0'+string(argument1)}
if argument1<10{cit+='00'+string(argument1)}

if argument2>=1000{cit+=string(argument2)}
if argument2>=100 and argument2<1000{cit+='0'+string(argument2)}
if argument2>=10 and argument2<100{cit+='00'+string(argument2)}
if argument2<10{cit+='000'+string(argument2)}

if argument3>=100{cit+=string(argument3)}
if argument3>=10 and argument3<100{cit+='0'+string(argument3)}
if argument3<10{cit+='00'+string(argument3)}

if argument4>=100{cit+=string(argument4)}
if argument4>=10 and argument4<100{cit+='0'+string(argument4)}
if argument4<10{cit+='00'+string(argument4)}

cit+=argument5+argument6+argument7

return cit

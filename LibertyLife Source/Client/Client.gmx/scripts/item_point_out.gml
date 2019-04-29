var point;
point=0

switch(item_type(argument0))
{
case 1:
switch(item_index(argument0))
{
case 0: break
case 1: point+=10 break
case 2: point+=15 break
case 3: point+=8 break
case 4: point+=20 break
}
break
case 2:
switch(item_index(argument0))
{
case 0: break
case 1: point+=2 break
case 2: point+=2 break
case 3: point+=2 break
case 4: point+=2 break
case 5: point+=20 break
case 6: point+=0 break
case 7: point+=0 break
case 8: point+=0 break
case 9: point+=0 break
}
break
}

return point

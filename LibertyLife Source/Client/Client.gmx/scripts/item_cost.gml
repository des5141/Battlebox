var cost;
cost=0

switch(item_type(argument0))
{
case 1:
switch(item_index(argument0))
{
case 0: break
case 1: cost+=100 break
case 2: cost+=100 break
case 3: cost+=100 break
case 4: cost+=400 break
}
break
case 2:
switch(item_index(argument0))
{
case 0: break
case 1: cost+=20 break
case 2: cost+=20 break
case 3: cost+=20 break
case 4: cost+=20 break
case 5: cost+=150 break
case 6: cost+=0 break
case 7: cost+=0 break
case 8: cost+=0 break
case 9: cost+=0 break
}
break
case 3:
switch(item_index(argument0))
{
case 0: break
case 1: cost+=2 break
case 2: cost+=3 break
case 3: cost+=6 break
case 4: cost+=4 break
case 5: cost+=3 break
case 6: cost+=3 break
case 7: cost+=5 break
case 8: cost+=5 break
case 9: cost+=5 break
case 10: cost+=10 break
case 11: cost+=10 break
case 12: cost+=10 break
case 13: cost+=15 break
case 14: cost+=15 break
}
break
case 4:
switch(item_index(argument0))
{
case 0: break
case 1: cost+=1 break
case 2: cost+=20 break
case 3: cost+=5 break
case 4: cost+=25 break
case 5: cost+=25 break
case 6: cost+=25 break
case 7: cost+=25 break
case 8: cost+=1 break
case 9: cost+=20 break
}
break
case 5:
switch(item_index(argument0))
{
case 0: break
case 1: cost+=200 break
}
break
}

cost*=item_count(argument0)
cost=round(cost)

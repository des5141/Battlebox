if argument1=0
{
switch(item_index(argument0))
{
case 0: return 0 break
case 1: return 10 break
case 2: return 15 break
case 3: return 5 break
case 4: return 5 break
}
}
if argument1=1
{
switch(item_index(argument0))
{
case 0: return 0 break
case 1: return 5 break
case 2: return 5 break
case 3: return 15 break
case 4: return 10 break
}
}
if argument1=2
{
return item_weapon_delay(argument0,0)+item_weapon_delay(argument0,1)
}

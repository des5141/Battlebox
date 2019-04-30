//draw_item(item,x,y,xscale,motion)
var i;

switch(item_type(argument0))
{
case 1:
if argument4!=-1
{
for(i=0;i<3;i+=1){draw_sprite_ext(spr_item_weapon,item_index(argument0)*12+1+i+4*argument4,argument1,argument2,argument3,1,0,item_color(argument0,i),1)}
draw_sprite_ext(spr_item_weapon,item_index(argument0)*12+4*argument4,argument1,argument2,argument3,1,0,c_white,1)
}
else
{
for(i=0;i<3;i+=1){draw_sprite_ext(spr_item_in_weapon,item_index(argument0)*4+1+i,argument1,argument2,1,1,0,item_color(argument0,i),1)}
draw_sprite_ext(spr_item_in_weapon,item_index(argument0)*4,argument1,argument2,1,1,0,c_white,1)
}
break
case 2:
if argument4!=-1
{
for(i=0;i<3;i+=1){draw_sprite_ext(spr_item_clothes,item_index(argument0)*4+1+i,argument1,argument2,argument3,1,0,item_color(argument0,i),1)}
draw_sprite_ext(spr_item_clothes,item_index(argument0)*4,argument1,argument2,argument3,1,0,c_white,1)
}
else
{
for(i=0;i<3;i+=1){draw_sprite_ext(spr_item_in_clothes,item_index(argument0)*4+1+i,argument1,argument2,1,1,0,item_color(argument0,i),1)}
draw_sprite_ext(spr_item_in_clothes,item_index(argument0)*4,argument1,argument2,1,1,0,c_white,1)
}
break
case 3:
draw_sprite_ext(spr_item_suplies,item_index(argument0),argument1,argument2,1,1,0,c_white,1)
draw_count(argument1+1,argument2+32-8,item_count(argument0))
break
case 4:
draw_sprite_ext(spr_item_normal,item_index(argument0),argument1,argument2,1,1,0,c_white,1)
draw_count(argument1+1,argument2+32-8,item_count(argument0))
break
case 5:
draw_sprite_ext(spr_item_switch,item_index(argument0),argument1,argument2,1,1,0,c_white,1)
break
}


var tx1,tx2,tx3,tx4;
tx1=''
tx2=''
tx3=''
tx4=''

argument2=min(view_yview+480-76,argument2)

switch(item_type(argument0))
{
case 0: break
case 1:
tx1=item_name(argument0)
switch(item_weapon_type(argument0))
{
case  4 : tx2='���� ' break
default : tx2='���ݷ� ' break
}
tx2+=string(item_point_out(argument0))
tx3='����� '+string(item_condition(argument0)*0.01)
tx4=string(item_cost(argument0))+'���'
break
case 2:
tx1=item_name(argument0)
tx2='���� '+string(item_point_out(argument0))
tx3='����� '+string(item_condition(argument0)*0.01)
tx4=string(item_cost(argument0))+'���'
break
case 3:
tx1=item_name(argument0)
tx2='ȸ����'+string(item_point(argument0))
tx3='�ܷ� '+string(item_count(argument0))
tx4=string(item_cost(argument0))+'���'
break
case 4:
tx1=item_name(argument0)
tx2=string(item_count(argument0))+'��'
tx3=''
tx4=string(item_cost(argument0))+'���'
break
case 5:
tx1=item_name(argument0)
tx2=''
tx3=''
tx4=string(item_cost(argument0))+'���'
break
}

var max_line,i,j,dx;
max_line=max(string_length(tx1),string_length(tx2),string_length(tx3),string_length(tx4))/2
dx=min(view_xview+640-max_line*6-64,argument1)

draw_sprite(spr_inter_Text,system.option_interface_color*9+0,dx,argument2)
for(i=0;i<max_line;i+=1){draw_sprite(spr_inter_Text,system.option_interface_color*9+1,dx+12+12*i,argument2)}
draw_sprite(spr_inter_Text,system.option_interface_color*9+2,dx+12+max_line*12,argument2)
for(j=0;j<4;j+=1)                  
{
draw_sprite(spr_inter_Text,system.option_interface_color*9+3,dx,argument2+12+12*j)
for(i=0;i<max_line;i+=1){draw_sprite(spr_inter_Text,system.option_interface_color*9+4,dx+12+12*i,argument2+12+12*j)}
draw_sprite(spr_inter_Text,system.option_interface_color*9+5,dx+12+max_line*12,argument2+12+12*j)
}
draw_sprite(spr_inter_Text,system.option_interface_color*9+6,dx,argument2+12+4*12)
for(i=0;i<max_line;i+=1){draw_sprite(spr_inter_Text,system.option_interface_color*9+7,dx+12+12*i,argument2+12+4*12)}
draw_sprite(spr_inter_Text,system.option_interface_color*9+8,dx+12+max_line*12,argument2+12+4*12)

sex_set_font(12)
sex_set_halign(fa_middle)
sex_draw_text(dx+12+max_line*6,argument2+12+12*0,tx1)
sex_set_halign(fa_left)
sex_draw_text(dx+12,argument2+12+12*1,tx2)
sex_draw_text(dx+12,argument2+12+12*2,tx3)
sex_draw_text(dx+12,argument2+12+12*3,tx4)

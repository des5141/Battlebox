global.__select=0
var i,bx,by;
bx=view_xview
by=view_yview
for(i=1;i<5;i+=1){global.__select_text[i]=''}
global.__select_text[1]=argument0
global.__select_text[2]=argument1
global.__select_text[3]=argument2
global.__select_text[4]=argument3


if mouse_x>bx+160 and mouse_x<bx+480{for(i=1;i<5;i+=1){if mouse_y>by+64+64*(i-1) and mouse_y<by+96+64*(i-1){global.__select=i}}}
if mouse_check_button_pressed(mb_left)=1 and global.__select>0{global.__select_check=1}

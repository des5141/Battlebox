var i,sub,tstr;
for(i=0;i<4;i+=1)
{
if global.__char_on[i]=0
{
global.__char_pos[i]=global.__char_pos_sub[i]
global.__char_pos_sub[i]=0
}
global.__char_on[i]=min(max(global.__char_on[i]+global.__char_move[i],0),global.__max_in)
}

if global.__count=0
{
global.__count=global.__count_max-10
repeat(max(1,10-global.__count_max))
{
if global.__text_sub!=''
{
tstr=ord(string_copy(global.__text_sub,0,2))
sub=1+((tstr >> 7)==1)
global.__text+=string_copy(global.__text_sub,0,sub)
global.__text_sub=string_delete(global.__text_sub,1,sub)
}
}
}else{global.__count=max(0,global.__count-1)}

if (string_length(global.__text)/global.__sexmaxline)>6
{
global.__text=string_delete(global.__text,1,global.__sexmaxline)
tstr=ord(string_copy(global.__text,0,2))
if (tstr>>7)!=0{global.__text=string_delete(global.__text,1,1)}
}


if keyboard_check_pressed(vk_enter)=1 and global.__select=-1
{
if global.__text_sub=''
{
tb_pass_talk()
}
else
{
global.__text+=global.__text_sub
global.__text_sub=''
}
global.__text_add=0
}

var num,num_len;
num=argument2
num_len=string_length(string(argument2))

for(i=0;i<num_len;i+=1)
{
draw_sprite(spr_count,real(string_char_at(string(num),i+1)),argument0+5*i,argument1)
}

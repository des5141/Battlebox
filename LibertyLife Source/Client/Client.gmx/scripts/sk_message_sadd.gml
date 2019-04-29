for(__i=0; __i<argument1; __i+=1)
{

switch(argument0)
{
case 0: dll39_write_byte(argument[__i+2], global._39_send_var_buffer_[0]); break;
case 1: dll39_write_short(argument[__i+2], global._39_send_var_buffer_[1]); break;
case 2: dll39_write_ushort(argument[__i+2], global._39_send_var_buffer_[2]); break;
case 3: dll39_write_int(argument[__i+2], global._39_send_var_buffer_[3]); break;
case 4: dll39_write_uint(argument[__i+2], global._39_send_var_buffer_[4]); break;
case 5: dll39_write_string(argument[__i+2], global._39_send_var_buffer_[5]); break;
}

}

global._39_send_st_max_[global._39_send_message_max_-1, argument0]+=argument1

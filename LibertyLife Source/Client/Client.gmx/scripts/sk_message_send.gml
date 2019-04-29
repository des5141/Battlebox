if global._39_send_message_max_=0{return 0}

var skv_str, skv_ok, skv_read, skv_max_send;
skv_max_send=0

dll39_buffer_clear(0)

for(__i=0; __i!=global._39_send_message_max_; __i+=1)
{
skv_ok=0

if global._39_send_read_id_[__i]=0 or global._39_send_read_id_[__i]-2=global._39_player_id_
{
skv_ok=1
skv_read[0]=dll39_get_pos(1, global._39_send_var_buffer_[0])
skv_read[1]=dll39_get_pos(1, global._39_send_var_buffer_[1])
skv_read[2]=dll39_get_pos(1, global._39_send_var_buffer_[2])
skv_read[3]=dll39_get_pos(1, global._39_send_var_buffer_[3])
skv_read[4]=dll39_get_pos(1, global._39_send_var_buffer_[4])
skv_read[5]=dll39_get_pos(1, global._39_send_var_buffer_[5])

if global._39_send_system_[__i]=1
{
dll39_write_uint(global._39_send_id_[__i], global._39_saved_buffer_)
dll39_write_uint(global._39_player_id_, global._39_saved_buffer_)
dll39_write_string(global._39_player_name_, global._39_saved_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 0], global._39_saved_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 1], global._39_saved_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 2], global._39_saved_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 3], global._39_saved_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 4], global._39_saved_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 5], global._39_saved_buffer_)
repeat(global._39_send_st_max_[__i, 0]){dll39_write_byte(dll39_read_byte(global._39_send_var_buffer_[0]), global._39_saved_buffer_)}
repeat(global._39_send_st_max_[__i, 1]){dll39_write_short(dll39_read_short(global._39_send_var_buffer_[1]), global._39_saved_buffer_)}
repeat(global._39_send_st_max_[__i, 2]){dll39_write_ushort(dll39_read_ushort(global._39_send_var_buffer_[2]), global._39_saved_buffer_)}
repeat(global._39_send_st_max_[__i, 3]){dll39_write_int(dll39_read_int(global._39_send_var_buffer_[3]), global._39_saved_buffer_)}
repeat(global._39_send_st_max_[__i, 4]){dll39_write_uint(dll39_read_uint(global._39_send_var_buffer_[4]), global._39_saved_buffer_)}
repeat(global._39_send_st_max_[__i, 5]){dll39_write_string(dll39_read_string(global._39_send_var_buffer_[5]), global._39_saved_buffer_)}
}
else if global._39_send_system_[__i]>1
{
dll39_write_uint(global._39_send_system_[__i]-2, global._39_space_buffer_)
dll39_write_uint(global._39_send_id_[__i], global._39_space_buffer_)
dll39_write_uint(global._39_player_id_, global._39_space_buffer_)
dll39_write_string(global._39_player_name_, global._39_space_buffer_)
dll39_write_uint(global._39_send_object_[__i], global._39_space_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 0], global._39_space_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 1], global._39_space_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 2], global._39_space_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 3], global._39_space_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 4], global._39_space_buffer_)
dll39_write_uint(global._39_send_st_max_[__i, 5], global._39_space_buffer_)
repeat(global._39_send_st_max_[__i, 0]){dll39_write_byte(dll39_read_byte(global._39_send_var_buffer_[0]), global._39_space_buffer_)}
repeat(global._39_send_st_max_[__i, 1]){dll39_write_short(dll39_read_short(global._39_send_var_buffer_[1]), global._39_space_buffer_)}
repeat(global._39_send_st_max_[__i, 2]){dll39_write_ushort(dll39_read_ushort(global._39_send_var_buffer_[2]), global._39_space_buffer_)}
repeat(global._39_send_st_max_[__i, 3]){dll39_write_int(dll39_read_int(global._39_send_var_buffer_[3]), global._39_space_buffer_)}
repeat(global._39_send_st_max_[__i, 4]){dll39_write_uint(dll39_read_uint(global._39_send_var_buffer_[4]), global._39_space_buffer_)}
repeat(global._39_send_st_max_[__i, 5]){dll39_write_string(dll39_read_string(global._39_send_var_buffer_[5]), global._39_space_buffer_)}
}
}

if global._39_send_read_id_[__i]-2!=global._39_player_id_
{
if skv_ok=1
{
dll39_set_pos(skv_read[0], global._39_send_var_buffer_[0])
dll39_set_pos(skv_read[1], global._39_send_var_buffer_[1])
dll39_set_pos(skv_read[2], global._39_send_var_buffer_[2])
dll39_set_pos(skv_read[3], global._39_send_var_buffer_[3])
dll39_set_pos(skv_read[4], global._39_send_var_buffer_[4])
dll39_set_pos(skv_read[5], global._39_send_var_buffer_[5])
}

dll39_write_uint(global._39_send_read_id_[__i], 0)
dll39_write_uint(global._39_send_system_[__i], 0)
dll39_write_uint(global._39_send_id_[__i], 0)
dll39_write_uint(global._39_player_id_, 0)
dll39_write_string(global._39_player_name_, 0)
if global._39_send_system_[__i]>1{dll39_write_uint(global._39_send_object_[__i], 0)}
dll39_write_uint(global._39_send_st_max_[__i, 0], 0)
dll39_write_uint(global._39_send_st_max_[__i, 1], 0)
dll39_write_uint(global._39_send_st_max_[__i, 2], 0)
dll39_write_uint(global._39_send_st_max_[__i, 3], 0)
dll39_write_uint(global._39_send_st_max_[__i, 4], 0)
dll39_write_uint(global._39_send_st_max_[__i, 5], 0)
repeat(global._39_send_st_max_[__i, 0]){dll39_write_byte(dll39_read_byte(global._39_send_var_buffer_[0]), 0)}
repeat(global._39_send_st_max_[__i, 1]){dll39_write_short(dll39_read_short(global._39_send_var_buffer_[1]), 0)}
repeat(global._39_send_st_max_[__i, 2]){dll39_write_ushort(dll39_read_ushort(global._39_send_var_buffer_[2]), 0)}
repeat(global._39_send_st_max_[__i, 3]){dll39_write_int(dll39_read_int(global._39_send_var_buffer_[3]), 0)}
repeat(global._39_send_st_max_[__i, 4]){dll39_write_uint(dll39_read_uint(global._39_send_var_buffer_[4]), 0)}
repeat(global._39_send_st_max_[__i, 5]){dll39_write_string(dll39_read_string(global._39_send_var_buffer_[5]), 0)}

if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}

if global._39_player_id_=0
{
if global._39_send_read_id_[__i]<2
{
for(__j=1; __j<global._39_player_c_socket_max_; __j+=1)
{
dll39_message_send(global._39_player_c_socket_[__j], "", 0, 0)
skv_max_send+=1
if skv_max_send>=global._39_max_message_send_{sleep(global._39_wait_message_send_); skv_max_send=0}
}
}
else{dll39_message_send(global._39_send_read_id_[__i]-2, "", 0, 0); skv_max_send+=1; if skv_max_send>=global._39_max_message_send_{sleep(global._39_wait_message_send_); skv_max_send=0}}
}
else{dll39_message_send(global._39_client_tcp_, "", 0, 0); skv_max_send+=1; if skv_max_send>=global._39_max_message_send_{sleep(global._39_wait_message_send_); skv_max_send=0}}

dll39_buffer_clear(0)
}

}

dll39_buffer_clear(global._39_send_var_buffer_[0])
dll39_buffer_clear(global._39_send_var_buffer_[1])
dll39_buffer_clear(global._39_send_var_buffer_[2])
dll39_buffer_clear(global._39_send_var_buffer_[3])
dll39_buffer_clear(global._39_send_var_buffer_[4])
dll39_buffer_clear(global._39_send_var_buffer_[5])
global._39_send_message_max_=0

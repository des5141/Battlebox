var skv_messagesize, skv_rt_sock, skv_mer_id, skv_mes, skv_me_id, skv_mes_id, skv_mes_name, skv_mev_max, skv_obj, skv_max_send;

//[new player join] start

if global._39_player_id_=0 and global._39_player_join_accept_=1
{
skv_rt_sock=dll39_tcp_accept(global._39_tcp_, true)
while(skv_rt_sock!=-1)
{
if global._39_player_join_accept_max_=0 or global._39_player_join_accept_max_>global._39_player_c_socket_max_
{
global._39_player_c_socket_[global._39_player_c_socket_max_]=skv_rt_sock
global._39_player_c_socket_max_+=1
global._39_player_max_number_+=1
if global._39_player_max_number_!=1
{
dll39_buffer_clear(0)
dll39_write_byte(0, 0)
dll39_write_uint(skv_rt_sock, 0)
dll39_message_send(global._39_player_c_socket_[global._39_player_c_socket_max_-1], "", 0, 0)
}
}
else{dll39_socket_close(skv_rt_sock)}
skv_rt_sock=dll39_tcp_accept(global._39_tcp_, true)
}
}

//[new player join] end

//[saved message read] start
if dll39_bytes_left(global._39_saved_buffer_)!=0
{
global._39_message_id_=dll39_read_uint(global._39_saved_buffer_)
global._39_message_send_=dll39_read_uint(global._39_saved_buffer_)
global._39_message_send_name_=dll39_read_string(global._39_saved_buffer_)
global._39_message_st_max_[0]=dll39_read_uint(global._39_saved_buffer_)
global._39_message_st_max_[1]=dll39_read_uint(global._39_saved_buffer_)
global._39_message_st_max_[2]=dll39_read_uint(global._39_saved_buffer_)
global._39_message_st_max_[3]=dll39_read_uint(global._39_saved_buffer_)
global._39_message_st_max_[4]=dll39_read_uint(global._39_saved_buffer_)
global._39_message_st_max_[5]=dll39_read_uint(global._39_saved_buffer_)
for(__i=0; __i!=global._39_message_st_max_[0]; __i+=1){global._39_message_st_sts_[__i, 0]=dll39_read_byte(global._39_saved_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[1]; __i+=1){global._39_message_st_sts_[__i, 1]=dll39_read_short(global._39_saved_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[2]; __i+=1){global._39_message_st_sts_[__i, 2]=dll39_read_ushort(global._39_saved_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[3]; __i+=1){global._39_message_st_sts_[__i, 3]=dll39_read_int(global._39_saved_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[4]; __i+=1){global._39_message_st_sts_[__i, 4]=dll39_read_uint(global._39_saved_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[5]; __i+=1){global._39_message_st_sts_[__i, 5]=dll39_read_string(global._39_saved_buffer_)}
return 1
}
else{dll39_buffer_clear(global._39_saved_buffer_)}
//[saved message read] end

//[space message read] start
while(dll39_bytes_left(global._39_space_buffer_)!=0)
{
global._39_space_check_=0
global._39_space_mes_=dll39_read_uint(global._39_space_buffer_)
global._39_message_id_=dll39_read_uint(global._39_space_buffer_)
global._39_message_send_=dll39_read_uint(global._39_space_buffer_)
global._39_message_send_name_=dll39_read_string(global._39_space_buffer_)
skv_obj=dll39_read_uint(global._39_space_buffer_)
global._39_message_st_max_[0]=dll39_read_uint(global._39_space_buffer_)
global._39_message_st_max_[1]=dll39_read_uint(global._39_space_buffer_)
global._39_message_st_max_[2]=dll39_read_uint(global._39_space_buffer_)
global._39_message_st_max_[3]=dll39_read_uint(global._39_space_buffer_)
global._39_message_st_max_[4]=dll39_read_uint(global._39_space_buffer_)
global._39_message_st_max_[5]=dll39_read_uint(global._39_space_buffer_)
for(__i=0; __i!=global._39_message_st_max_[0]; __i+=1){global._39_message_st_sts_[__i, 0]=dll39_read_byte(global._39_space_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[1]; __i+=1){global._39_message_st_sts_[__i, 1]=dll39_read_short(global._39_space_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[2]; __i+=1){global._39_message_st_sts_[__i, 2]=dll39_read_ushort(global._39_space_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[3]; __i+=1){global._39_message_st_sts_[__i, 3]=dll39_read_int(global._39_space_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[4]; __i+=1){global._39_message_st_sts_[__i, 4]=dll39_read_uint(global._39_space_buffer_)}
for(__i=0; __i!=global._39_message_st_max_[5]; __i+=1){global._39_message_st_sts_[__i, 5]=dll39_read_string(global._39_space_buffer_)}
with(skv_obj){event_user(global._39_space_object_event_); if global._39_space_check_=1{break}}
}
dll39_buffer_clear(global._39_space_buffer_)
//[space message read] end

if global._39_player_id_=0
{
//[message converter] start

skv_messagesize=0
skv_max_send=0

for(__i=1; __i<global._39_player_c_socket_max_; __i+=1)
{
skv_messagesize=dll39_message_receive(global._39_player_c_socket_[__i], 0, 0)
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}

while(skv_messagesize>0)
{
skv_mer_id=dll39_read_uint(0)-2
skv_mes=dll39_read_uint(0)-2
skv_me_id=dll39_read_uint(0)
skv_mes_id=dll39_read_uint(0)
skv_mes_name=dll39_read_string(0)

if skv_mer_id!=global._39_player_id_
{
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}

if 0>skv_mer_id
{
for(__j=1; __j<global._39_player_c_socket_max_; __j+=1)
{
dll39_message_send(global._39_player_c_socket_[__j], "", 0, 0)
skv_max_send+=1
if skv_max_send>=global._39_max_message_send_{sleep(global._39_wait_message_send_); skv_max_send=0}
}
}
else
{
dll39_message_send(skv_mer_id, "", 0, 0)
skv_max_send+=1
if skv_max_send>=global._39_max_message_send_{sleep(global._39_wait_message_send_); skv_max_send=0}
}

if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}
}

//[message saved] start

if 0>skv_mer_id or skv_mer_id=global._39_player_id_
{

if skv_mes>-1
{
//[space message saved] start
skv_obj=dll39_read_uint(0)
skv_mev_max[0]=dll39_read_uint(0)
skv_mev_max[1]=dll39_read_uint(0)
skv_mev_max[2]=dll39_read_uint(0)
skv_mev_max[3]=dll39_read_uint(0)
skv_mev_max[4]=dll39_read_uint(0)
skv_mev_max[5]=dll39_read_uint(0)
dll39_write_uint(skv_mes, global._39_space_buffer_)
dll39_write_uint(skv_me_id, global._39_space_buffer_)
dll39_write_uint(skv_mes_id, global._39_space_buffer_)
dll39_write_string(skv_mes_name, global._39_space_buffer_)
dll39_write_uint(skv_obj, global._39_space_buffer_)
dll39_write_uint(skv_mev_max[0], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[1], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[2], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[3], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[4], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[5], global._39_space_buffer_)
repeat(skv_mev_max[0]){dll39_write_byte(dll39_read_byte(0), global._39_space_buffer_)}
repeat(skv_mev_max[1]){dll39_write_short(dll39_read_short(0), global._39_space_buffer_)}
repeat(skv_mev_max[2]){dll39_write_ushort(dll39_read_ushort(0), global._39_space_buffer_)}
repeat(skv_mev_max[3]){dll39_write_int(dll39_read_int(0), global._39_space_buffer_)}
repeat(skv_mev_max[4]){dll39_write_uint(dll39_read_uint(0), global._39_space_buffer_)}
repeat(skv_mev_max[5]){dll39_write_string(dll39_read_string(0), global._39_space_buffer_)}
//[space message saved] end
}
else if skv_mes=-1
{
//start
skv_mev_max[0]=dll39_read_uint(0)
skv_mev_max[1]=dll39_read_uint(0)
skv_mev_max[2]=dll39_read_uint(0)
skv_mev_max[3]=dll39_read_uint(0)
skv_mev_max[4]=dll39_read_uint(0)
skv_mev_max[5]=dll39_read_uint(0)
dll39_write_uint(skv_me_id, global._39_saved_buffer_)
dll39_write_uint(skv_mes_id, global._39_saved_buffer_)
dll39_write_string(skv_mes_name, global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[0], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[1], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[2], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[3], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[4], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[5], global._39_saved_buffer_)
repeat(skv_mev_max[0]){dll39_write_byte(dll39_read_byte(0), global._39_saved_buffer_)}
repeat(skv_mev_max[1]){dll39_write_short(dll39_read_short(0), global._39_saved_buffer_)}
repeat(skv_mev_max[2]){dll39_write_ushort(dll39_read_ushort(0), global._39_saved_buffer_)}
repeat(skv_mev_max[3]){dll39_write_int(dll39_read_int(0), global._39_saved_buffer_)}
repeat(skv_mev_max[4]){dll39_write_uint(dll39_read_uint(0), global._39_saved_buffer_)}
repeat(skv_mev_max[5]){dll39_write_string(dll39_read_string(0), global._39_saved_buffer_)}
//end
}
else if skv_mes=-2
{
//[player exit] start
skv_mev_max=dll39_read_uint(0)
dll39_socket_close(global._39_player_c_socket_[__i])
for(__j=__i+1; __j<global._39_player_c_socket_max_; __j+=1){global._39_player_c_socket_[__j-1]=global._39_player_c_socket_[__j]}
global._39_player_c_socket_max_-=1
//[player exit] end
}

}
else{if skv_mes>-1{skv_obj=dll39_read_uint(0)}; skv_mev_max[0]=dll39_read_uint(0); skv_mev_max[1]=dll39_read_uint(0); skv_mev_max[2]=dll39_read_uint(0); skv_mev_max[3]=dll39_read_uint(0); skv_mev_max[4]=dll39_read_uint(0); skv_mev_max[5]=dll39_read_uint(0); repeat(skv_mev_max[0]){dll39_read_byte(0)}; repeat(skv_mev_max[1]){dll39_read_short(0)}; repeat(skv_mev_max[2]){dll39_read_ushort(0)}; repeat(skv_mev_max[3]){dll39_read_int(0)}; repeat(skv_mev_max[4]){dll39_read_uint(0)}; repeat(skv_mev_max[5]){dll39_read_string(0)}}
//[message saved] end

skv_messagesize=dll39_message_receive(global._39_player_c_socket_[__i], 0, 0)
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}
}

if skv_messagesize=0
{
//[player exit] start
dll39_socket_close(global._39_player_c_socket_[__i])
dll39_write_uint(global._39_player_c_socket_[__i], global._39_sleep_player_id_)
for(__j=__i+1; __j<global._39_player_c_socket_max_; __j+=1){global._39_player_c_socket_[__j-1]=global._39_player_c_socket_[__j]}
global._39_player_c_socket_max_-=1
//[player exit] end
}

}

//[message converter] end
}
else
{
//[player message read] start

skv_messagesize=dll39_message_receive(global._39_client_tcp_, 0, 0)
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}

while(skv_messagesize>0)
{
skv_mer_id=dll39_read_uint(0)-2
skv_mes=dll39_read_uint(0)-2
skv_me_id=dll39_read_uint(0)
skv_mes_id=dll39_read_uint(0)
skv_mes_name=dll39_read_string(0)

if skv_mes_id!=global._39_player_id_ and (0>skv_mer_id or skv_mer_id=global._39_player_id_)
{

if skv_mes>-1
{
//[space message saved] start
skv_obj=dll39_read_uint(0)
skv_mev_max[0]=dll39_read_uint(0)
skv_mev_max[1]=dll39_read_uint(0)
skv_mev_max[2]=dll39_read_uint(0)
skv_mev_max[3]=dll39_read_uint(0)
skv_mev_max[4]=dll39_read_uint(0)
skv_mev_max[5]=dll39_read_uint(0)
dll39_write_uint(skv_mes, global._39_space_buffer_)
dll39_write_uint(skv_me_id, global._39_space_buffer_)
dll39_write_uint(skv_mes_id, global._39_space_buffer_)
dll39_write_string(skv_mes_name, global._39_space_buffer_)
dll39_write_uint(skv_obj, global._39_space_buffer_)
dll39_write_uint(skv_mev_max[0], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[1], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[2], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[3], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[4], global._39_space_buffer_)
dll39_write_uint(skv_mev_max[5], global._39_space_buffer_)
repeat(skv_mev_max[0]){dll39_write_byte(dll39_read_byte(0), global._39_space_buffer_)}
repeat(skv_mev_max[1]){dll39_write_short(dll39_read_short(0), global._39_space_buffer_)}
repeat(skv_mev_max[2]){dll39_write_ushort(dll39_read_ushort(0), global._39_space_buffer_)}
repeat(skv_mev_max[3]){dll39_write_int(dll39_read_int(0), global._39_space_buffer_)}
repeat(skv_mev_max[4]){dll39_write_uint(dll39_read_uint(0), global._39_space_buffer_)}
repeat(skv_mev_max[5]){dll39_write_string(dll39_read_string(0), global._39_space_buffer_)}
//[space message saved] end
}
else if skv_mes=-1
{
//start
skv_mev_max[0]=dll39_read_uint(0)
skv_mev_max[1]=dll39_read_uint(0)
skv_mev_max[2]=dll39_read_uint(0)
skv_mev_max[3]=dll39_read_uint(0)
skv_mev_max[4]=dll39_read_uint(0)
skv_mev_max[5]=dll39_read_uint(0)
dll39_write_uint(skv_me_id, global._39_saved_buffer_)
dll39_write_uint(skv_mes_id, global._39_saved_buffer_)
dll39_write_string(skv_mes_name, global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[0], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[1], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[2], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[3], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[4], global._39_saved_buffer_)
dll39_write_uint(skv_mev_max[5], global._39_saved_buffer_)
repeat(skv_mev_max[0]){dll39_write_byte(dll39_read_byte(0), global._39_saved_buffer_)}
repeat(skv_mev_max[1]){dll39_write_short(dll39_read_short(0), global._39_saved_buffer_)}
repeat(skv_mev_max[2]){dll39_write_ushort(dll39_read_ushort(0), global._39_saved_buffer_)}
repeat(skv_mev_max[3]){dll39_write_int(dll39_read_int(0), global._39_saved_buffer_)}
repeat(skv_mev_max[4]){dll39_write_uint(dll39_read_uint(0), global._39_saved_buffer_)}
repeat(skv_mev_max[5]){dll39_write_string(dll39_read_string(0), global._39_saved_buffer_)}
//end
}
else if skv_mes=-2
{
//[server exit] start
skv_mev_max=dll39_read_uint(0)
global._39_server_check_=0
//[server exit] end
}

}
else{if skv_mes>-1{skv_obj=dll39_read_uint(0)}; skv_mev_max[0]=dll39_read_uint(0); skv_mev_max[1]=dll39_read_uint(0); skv_mev_max[2]=dll39_read_uint(0); skv_mev_max[3]=dll39_read_uint(0); skv_mev_max[4]=dll39_read_uint(0); skv_mev_max[5]=dll39_read_uint(0); repeat(skv_mev_max[0]){dll39_read_byte(0)}; repeat(skv_mev_max[1]){dll39_read_short(0)}; repeat(skv_mev_max[2]){dll39_read_ushort(0)}; repeat(skv_mev_max[3]){dll39_read_int(0)}; repeat(skv_mev_max[4]){dll39_read_uint(0)}; repeat(skv_mev_max[5]){dll39_read_string(0)}}

skv_messagesize=dll39_message_receive(global._39_client_tcp_, 0, 0)
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}
}

if skv_messagesize=0{global._39_server_check_=0}

//[player message read] end
}

return 0

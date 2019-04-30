if global._39_player_id_!=0{return 0}

var skv_ok;
skv_ok=0

dll39_buffer_clear(0)

dll39_write_uint(1, 0)
dll39_write_uint(0, 0)
dll39_write_uint(0, 0)
dll39_write_uint(0, 0)
dll39_write_string("", 0)
dll39_write_uint(0, 0)

for(__i=1; __i<global._39_player_c_socket_max_; __i+=1)
{

if skv_ok=1
{
global._39_player_c_socket_[__i-1]=global._39_player_c_socket_[__i]
}

if skv_ok=0 and global._39_player_c_socket_[__i]=argument0
{
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}
dll39_message_send(global._39_player_c_socket_[__i], "", 0, 0)
dll39_socket_close(global._39_player_c_socket_[__i])
skv_ok=1
}

}

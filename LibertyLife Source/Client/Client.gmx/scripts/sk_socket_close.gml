if global._39_close_check_{return 0}
global._39_close_check_=1

dll39_buffer_clear(0)

if global._39_player_id_=0
{
dll39_write_uint(1, 0)
dll39_write_uint(0, 0)
dll39_write_uint(0, 0)
dll39_write_uint(0, 0)
dll39_write_string("", 0)
dll39_write_uint(0, 0)
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}
for(__i=1; __i<global._39_player_c_socket_max_; __i+=1){dll39_message_send(global._39_player_c_socket_[__i], "", 0, 0)}

sleep(argument0*1000)
}
else
{
dll39_write_uint(2, 0)
dll39_write_uint(0, 0)
dll39_write_uint(0, 0)
dll39_write_uint(global._39_player_id_, 0)
dll39_write_string("", 0)
dll39_write_uint(0, 0)
if global._39_packet_password_!=""{dll39_buffer_encrypt(global._39_packet_password_, 0)}
dll39_message_send(global._39_client_tcp_, "", 0, 0)

sleep(argument0*1000)
}

dll39_buffer_free(global._39_sleep_player_id_)
dll39_buffer_free(global._39_saved_buffer_)
dll39_buffer_free(global._39_space_buffer_)
dll39_buffer_free(global._39_send_var_buffer_[0])
dll39_buffer_free(global._39_send_var_buffer_[1])
dll39_buffer_free(global._39_send_var_buffer_[2])
dll39_buffer_free(global._39_send_var_buffer_[3])
dll39_buffer_free(global._39_send_var_buffer_[4])
dll39_buffer_free(global._39_send_var_buffer_[5])
if global._39_client_tcp_{dll39_socket_close(global._39_client_tcp_); global._39_client_tcp_=0}
if global._39_tcp_{dll39_socket_close(global._39_tcp_); global._39_tcp_=0}
for(__i=1; __i<global._39_player_c_socket_max_; __i+=1){dll39_socket_close(global._39_player_c_socket_[__i])}

global._39_server_check_=0

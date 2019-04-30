global._39_tcp_=dll39_tcp_listen(global._39_port_, -1, 1)

if global._39_tcp_
{
global._39_player_id_=0
global._39_player_name_=string(argument0)
global._39_server_check_=1
global._39_player_c_socket_max_=1
global._39_player_max_number_=1

dll39_set_nagle(global._39_tcp_, 1)
return 1
}

return 0

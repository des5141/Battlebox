if global._39_player_id_!=0{return 0}

if argument0
{
if !global._39_player_join_accept_{global._39_tcp_=dll39_tcp_listen(global._39_port_, -1, 1)}
if !global._39_tcp_{return 0}
global._39_player_join_accept_=1
}
else
{
if global._39_player_join_accept_{if global._39_tcp_{dll39_socket_close(global._39_tcp_); global._39_tcp_=0}}
global._39_player_join_accept_=0
}

return 1

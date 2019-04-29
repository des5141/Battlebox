var skv_messagesize, skv_time;

global._39_client_tcp_=dll39_tcp_connect(global._39_ip_, global._39_port_, 1)

if global._39_client_tcp_
{

global._39_player_name_=string(argument0)
global._39_server_check_=1

dll39_set_nagle(global._39_client_tcp_, 1)

skv_time=current_time
while(skv_time+(argument1*1000)>current_time)
{
skv_messagesize=dll39_message_receive(global._39_client_tcp_, 0, 0)
if skv_messagesize>0{if dll39_read_byte(0)=0{global._39_player_id_=dll39_read_uint(0); return 1}else{break}}
}

}

return 0

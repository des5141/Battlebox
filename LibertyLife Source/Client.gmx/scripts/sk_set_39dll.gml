/*
[39dll Simple Scripts v4.0.7]
Maker --- wnsrn3436@naver.com
*/

global._39_close_check_=0
//close check

global._39_ip_=argument0
global._39_port_=argument1
//on

global._39_tcp_=0
global._39_client_tcp_=0
//my socket

global._39_player_id_=0
global._39_player_name_=""
//player

global._39_player_join_accept_=1
global._39_player_join_accept_max_=0
//new player join accept

global._39_player_c_socket_=0
global._39_player_c_socket_max_=0
//joiner socket

global._39_player_max_number_=0
//player join number

global._39_server_check_=0
//server check

global._39_sleep_player_id_=dll39_buffer_create()
//sleep

global._39_packet_password_=""
//packet password

global._39_wait_message_send_=0
global._39_max_message_send_=0
//wait time

global._39_message_id_=0
global._39_message_send_=0
global._39_message_send_name_=""
global._39_message_st_max_=0
global._39_message_st_sts_=""
//message

global._39_saved_buffer_=dll39_buffer_create()
//saved message

global._39_space_buffer_=dll39_buffer_create()
global._39_space_object_event_=0
global._39_space_mes_=0
global._39_space_check_=0
//space message

global._39_send_message_max_=0
global._39_send_system_=0
global._39_send_id_=0
global._39_send_read_id_=0
global._39_send_object_=0
global._39_send_st_max_=0
global._39_send_var_buffer_[0]=dll39_buffer_create()
global._39_send_var_buffer_[1]=dll39_buffer_create()
global._39_send_var_buffer_[2]=dll39_buffer_create()
global._39_send_var_buffer_[3]=dll39_buffer_create()
global._39_send_var_buffer_[4]=dll39_buffer_create()
global._39_send_var_buffer_[5]=dll39_buffer_create()
//send save message

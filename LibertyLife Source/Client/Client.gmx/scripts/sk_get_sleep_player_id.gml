if global._39_player_id_!=0{return 0}

if dll39_bytes_left(global._39_sleep_player_id_)!=0
{
return dll39_read_uint(global._39_sleep_player_id_)
}

dll39_buffer_clear(global._39_sleep_player_id_)
return 0

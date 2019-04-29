///supersocket_send(buffer, signal, space);

var offset = buffer_tell(argument0);

buffer_seek(argument0, buffer_seek_start, 0);
buffer_write(argument0, buffer_u32, offset);
buffer_write(argument0, buffer_s16, argument2);
buffer_write(argument0, buffer_s16, argument1);
network_send_raw(sys_network.socket, argument0, offset);

buffer_delete(argument0);
global.check_bytes_send += offset;

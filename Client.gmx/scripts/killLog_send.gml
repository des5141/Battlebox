///killLog_send(index, my index);

buf = buf_new(16);
buf_write(buf, buffer_u8, argument0);
buf_write(buf, buffer_u8, argument1);
supersocket_send(buf, signal.killLog, sendTo.Server);
buf_del(buf);

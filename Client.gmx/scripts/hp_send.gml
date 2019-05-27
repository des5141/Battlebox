///hp_send(index, damage);
buf = buf_new(64);
buf_write(buf, buffer_u8, argument0);
buf_write(buf, buffer_u8, argument1);
supersocket_send(buf, signal.userHp, sendTo.Server);
buf_del(buf);


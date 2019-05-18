/// signal_userDelete(buffer);
var buf = argument0;
var userIndex = buf_read(buf, buffer_u8);

with(par_character) {
    if (userIndex == index)
        instance_destroy();
}

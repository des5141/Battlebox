/// signal_userPosition(buffer);
var buf = argument0;
var userCount = buf_read(buf, buffer_u8);
var userIndex, _x, _y, _z, _index, _xscale;
for(var i = 0; i < userCount; i++) {
    userIndex = buf_read(buf, buffer_u8);
    _x = buf_read(buf, buffer_u16);
    _y = buf_read(buf, buffer_u16);
    _z = buf_read(buf, buffer_u8);
    _index = buf_read(buf, buffer_u8);
    _xscale = buf_read(buf, buffer_s8);
    with(par_character) {
        if(index == userIndex) and (global.playerIndex != index) {
            x = _x;
            y = _y;
            z = _z;
            image_index = _index;
            image_xscale = _xscale;
            show_debug_message(index);
        }
    }
}

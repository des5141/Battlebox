/// signal_userPosition(buffer);
var buf = argument0;
var userCount = buf_read(buf, buffer_u8);
var userIndex, _x, _y, _z, _index, _xscale;
for(var i = 0; i < userCount; i++) {
    userIndex = buf_read(buf, buffer_u8);
    with(global.userList[userIndex]) {
        if(global.playerIndex != userIndex) {
            target_x = buf_read(buf, buffer_u16);
            target_y = buf_read(buf, buffer_u16);
            target_z = buf_read(buf, buffer_u8);
            image_index = buf_read(buf, buffer_u8);
            image_xscale = buf_read(buf, buffer_s8);
            weapon = buf_read(buf, buffer_u8);
            weapon_dir = buf_read(buf, buffer_s16); // 10 byte
        }else{
            buffer_seek(buf, buffer_seek_start, buffer_tell(buf) + 10); /* 들고 오는 양에 따라 이건 변경되어야한다 */
        }
    }
}

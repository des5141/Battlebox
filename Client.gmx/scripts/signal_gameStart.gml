/// signal_gameStart(buffer);
global.GameStart = true;
global.controller = true;

// 게임 시작
var buf = argument0;
var userCount = buf_read(buf, buffer_u16);
for(var i = 0; i < userCount; i++) {
    var ins;
    switch(buf_read(buf, buffer_u8)) {
        case 1:
            ins = instance_create(0, 0, obj_knight);
        break;
        
        case 2:
            ins = instance_create(0, 0, obj_doctor);
        break;
    }
    ins.index = buf_read(buf, buffer_u8);
    ins.x = buf_read(buf, buffer_u16);
    ins.y = buf_read(buf, buffer_u16);
    ins.nickname = buf_read(buf, buffer_string);
    ins.active = true;
    show_debug_message(ins.index);
    show_debug_message(global.playerIndex);
}

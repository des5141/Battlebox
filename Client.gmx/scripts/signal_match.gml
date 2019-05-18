/// signal_match(buffer);
var buf = argument0;
var success = buf_read(buf, buffer_u8);

global.GameStart = false;
global.controller = false;
global.playerIndex = buf_read(buf, buffer_u8);

if (success == 1) {
    // 배틀로얄로 이동
    room_goto(rm_battleroyal);
}

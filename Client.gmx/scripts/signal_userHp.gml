/// signal_userHp(buffer);
var buf = argument0;
var _userIndex = buf_read(buf, buffer_u8);
if(_userIndex != global.playerIndex)
    global.userList[_userIndex].hp = buf_read(buf, buffer_u8);

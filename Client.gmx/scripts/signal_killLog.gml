/// signal_killLog(buffer);
var buf = argument0;
var who = buf_read(buf, buffer_u8);
var tar_1 = buf_read(buf, buffer_string);
var tar_2 = buf_read(buf, buffer_string);
append_kill(tar_1, tar_2, 0);

if(who == global.playerIndex) {
    killInfo_add();
}

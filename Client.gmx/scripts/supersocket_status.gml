///supersocket_status()
var timeout = current_time - ping[0];
if(timeout > global.timeout) {
    supersocket_disconnect();
}
if(supersocket_isconnected() == -1) {
    supersocket_reconnect();
    global.login = false;
    room_goto(rm_connect);
}
if(supersocket_isconnected() == 1) {
    if(room != rm_login)and(global.login == false) {
        room_goto(rm_login);
    }
}

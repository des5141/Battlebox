///supersocket_status()
var timeout = current_time - ping[0];
if(timeout > global.timeout) {
    supersocket_disconnect();
}
if(supersocket_isconnected() == -1) {
    supersocket_reconnect();
    global.auth = false;
    room_goto(rm_connect);
}
if(supersocket_isconnected() == 1) {
    if(room != rm_auth)and(global.auth == false) {
        room_goto(rm_auth);
    }
}

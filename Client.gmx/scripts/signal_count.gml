/// signal_count(buffer);
var buf = argument0;
var success = buf_read(buf, buffer_u8);

switch (success) {
    // 매칭을 찾고 있는 유저 수
    case 1:
        obj_choose_view.matching_user_count = buf_read(buf, buffer_u16);
    break;
}

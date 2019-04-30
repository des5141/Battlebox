/// signal_login(buffer);
var buf = argument0;
var success = buf_read(buf, buffer_u8);

switch (success) {
    // 로그인 성공
    case 1:
        break;
        
    // 회원가입, 로그인 성공
    case 2:
        break;
        
    // 정지를 당했거나, 로그인이 불가능
    case 3:
        break;
}

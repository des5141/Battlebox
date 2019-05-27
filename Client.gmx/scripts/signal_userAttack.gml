/// signal_userAttack(buffer);
var buf = argument0;
var _userIndex = buf_read(buf, buffer_u8);

if(_userIndex != global.playerIndex) {
    with(par_character) {
        if(userIndex == _userIndex){
            x = buf_read(buf, buffer_u16);
            y = buf_read(buf, buffer_u16);
            weapon = buf_read(buf, buffer_u8);
            weapon_dir = buf_read(buf, buffer_s16);
            image_xscale = buf_read(buf, buffer_s8);
            weapon_attack(false);
        }
    }
}

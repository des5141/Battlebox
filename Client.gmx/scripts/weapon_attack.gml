///weapon_attack(mine);
if(weapon > 0) {
    weapon_set(weapon);
    
    // 네트워크 전송
    if(argument0 == true) {
        mp -= weapon_mp;
            
        buf = buf_new(64);
        buf_write(buf, buffer_u8, global.playerIndex);
        buf_write(buf, buffer_u16, x);
        buf_write(buf, buffer_u16, y);
        buf_write(buf, buffer_u8, weapon);
        buf_write(buf, buffer_s16, weapon_dir);
        buf_write(buf, buffer_s8, image_xscale);
        buf_write(buf, buffer_u8, weapon_damage);
        supersocket_send(buf, signal.userAttack, sendTo.Server);
        buf_del(buf);
    }
    
    // 로컬 생성
    weapon_instance(weapon, x, y, weapon_dir, image_xscale, weapon_damage, argument0, index);
}

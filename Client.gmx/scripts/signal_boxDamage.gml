/// signal_boxDamage(buffer);
var buf = argument0;
var boxIndex = buf_read(buf, buffer_u8);
var boxHp = buf_read(buf, buffer_u8);

with(obj_box) {
    if (boxIndex == index) {
        if(boxHp == 0)
            instance_destroy();
        hp = boxHp;
        event_user(0);
    }
}

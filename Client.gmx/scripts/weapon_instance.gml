///weapon_instance(index, x, y, dir, xscale, bool);
var ins;
var xscale = argument4;
var damage = argument5;
switch(argument0) {
    // 검
    case 0:
        ins = instance_create(argument1, argument2 - 16, object31);
        ins.image_angle = argument3;
        ins.damage = damage;
        ins.mine = argument6;
    break;

    // 총
    case 1:
    
    break;
}

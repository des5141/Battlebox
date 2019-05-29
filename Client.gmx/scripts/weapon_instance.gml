///weapon_instance(index, x, y, dir, xscale, bool, userIndex);
var ins;
var xscale = argument4;
var damage = argument5;
var _userIndex = argument7;

switch(argument0) {
    // 검
    case 1:
        ins = instance_create(argument1, argument2 - 16, object31);
        ins.image_angle = argument3;
        ins.damage = damage;
        ins.mine = argument6;
        ins.nuckback = 2;
        ins.zspeed = 0.8;
    break;

    // 총
    case 2:
    
    break;
}

ins.whos = _userIndex;

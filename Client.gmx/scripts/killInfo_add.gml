/// killInfo_add();
if (instance_exists(obj_killInfo)) {
    with(obj_killInfo) {
        step = 0;
        trigger = false;
        alarm[0] = 144*2;
    }
}else {
    instance_create(0, 0, obj_killInfo);
}

global.kill_count++;

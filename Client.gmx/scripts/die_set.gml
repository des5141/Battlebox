///die_set(bool);
if(argument0 == true) {
    dir = irandom_range(0, 360);
    nuckback = -6;
    zspeed = 1.3;
    z = 0;
    weapon = 0;
    die = true;
    global.myRank = obj_battleroyal_view.alive;
    instance_create(0, 0, obj_battleroyal_die);
}

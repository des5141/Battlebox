///weapon_set(index);
switch(argument0) {
    case 1:
        weapon_add_len = 10;
        weapon_add_dir = 180;
        weapon_delay_max = 80;
        weapon_step = 0;
        weapon_step_max = 40;
        weapon_step_mode = 0;
        weapon_damage = 2;
    break;
    
    case 2:
        weapon_add_x = 10;
        weapon_add_y = 20;
        weapon_delay_max = 40;
        weapon_step = 0;
        weapon_step_max = 40;
        weapon_step_mode = 1;
        weapon_damage = 10;
    break;
}
weapon_delay = weapon_delay_max;
weapon_step_trigger = false;

///append_kill(A, B, item index);
var get = -1;
with(obj_killLog_node) {
    if (get < y)
        get = y;
}
if (get == -1)
    get = global.killlog_index*sprite_get_height(spr_killog_back)+sprite_get_height(spr_killog_back)/2+global.killlog_ymin;
var ins = instance_create(global.killlog_xmin+sprite_get_width(spr_killog_back)/2, get + sprite_get_height(spr_killog_back), obj_killLog_node);
ins.index = global.killlog_index;
ins.A = argument0;
ins.B = argument1;
ins.item = argument2;
global.killlog_index++;

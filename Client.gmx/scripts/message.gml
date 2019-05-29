///message(instance, y, str);
with(obj_message) {
    instance_destroy();
}

var ins = instance_create(argument0.x, argument0.y, obj_message);
ins.target = argument0;
ins.add_y = argument1;
ins.str = argument2;

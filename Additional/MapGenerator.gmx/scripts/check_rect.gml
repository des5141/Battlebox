///check_rect(array, value, x, y, depth);
var array = argument0;
var value = argument1;
var scale = argument4
var _x = argument2 - floor(scale/2);
var _y = argument3 - floor(scale/2);

var temp_y = _y, temp_x = _x;
repeat(scale) {    
    repeat(scale) {
        if(temp_x >= 0)and(temp_x <= room_width/32-1)and(temp_y >= 0)and(temp_y <= room_height/32-1){
            if(array[temp_y, temp_x] == value)
                return true;
        }
        temp_x++;
    }
    temp_y++;
    temp_x = _x;
}

return false;

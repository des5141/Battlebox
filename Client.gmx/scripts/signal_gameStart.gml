/// signal_gameStart(buffer);
global.GameStart = true;
global.controller = true;

// 게임 시작
var buf = argument0;
var map_height = buf_read(buf, buffer_u8);
var map_width = buf_read(buf, buffer_u8);

for(var i = 0; i < map_height; i++) {
    for(var j = 0; j < map_width; j++) {
        global.map[i, j] = buf_read(buf, buffer_u8);
        switch(global.map[i, j]) {
            case 2:
                instance_create(j*32, i*32, obj_box1);
            break;
            
            case 3:
                instance_create(j*32, i*32, obj_block1);
            break;
        }
    }
}


var userCount = buf_read(buf, buffer_u8);
global.userList = array_create(userCount);

for(var i = 0; i < userCount; i++) {
    var ins;
    switch(buf_read(buf, buffer_u8)) {
        case 1:
            ins = instance_create(0, 0, obj_knight);
        break;
        
        case 2:
            ins = instance_create(0, 0, obj_doctor);
        break;
    }
    ins.index = buf_read(buf, buffer_u8);
    ins.x = buf_read(buf, buffer_u16);
    ins.y = buf_read(buf, buffer_u16);
    ins.nickname = buf_read(buf, buffer_string);
    ins.active = true;
    
    if(ins.index == global.playerIndex) {
        obj_battleroyal_view.target = ins;
        obj_battleroyal_view.x = ins.x;
        obj_battleroyal_view.y = ins.y;
        obj_battleroyal_view.mode = 1;
        ins.mine = true;
    }else {
        ins.mine = false;
        ins.target_x = ins.x;
        ins.target_y = ins.y;
        ins.target_z = ins.z;
    }
    
    global.userList[ins.index] = ins;
}

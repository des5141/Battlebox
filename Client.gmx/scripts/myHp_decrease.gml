///myHp_decrease(damage);
global.userList[global.playerIndex].hp -= argument0;
global.userList[global.playerIndex].hp = max(0, global.userList[global.playerIndex].hp);

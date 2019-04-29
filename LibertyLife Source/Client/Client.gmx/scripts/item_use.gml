//item_use(item)

var i,j,_item;
if item_search_i(argument0)=-1{exit}
_it=inven.it[item_search_i(argument0),item_search_j(argument0)]

switch(item_type(_it))
{
case 0: break
case 1:
 sound_play(sou_change1)
 var _temp;
 _temp=_it
 switch(item_weapon_type(_it))
 {
  case 0: break
  case 1: case 2: case 3: case 4: case 5:
 inven.it[item_search_i(argument0),item_search_j(argument0)]=system.left
  system.left=_temp
  break
  case 6:
 inven.it[item_search_i(argument0),item_search_j(argument0)]=system.right
  system.right=_temp
  break
 }
break
case 2:
 sound_play(sou_change2)
 var _temp;
 _temp=_it
 inven.it[item_search_i(argument0),item_search_j(argument0)]=system.body
 system.body=_temp
break
case 3:
 sound_play(sou_change3)
 if item_count(_it)>0 and system.pvp_start=0
 {
 switch(item_index(_it))
 {
  case 0: break
  case 1: system.chr_target.hp+=item_point(_it) break
  case 2: system.chr_target.hp_hit+=item_point(_it) break
  case 3: system.chr_target.hp_hit+=item_point(_it) system.chr_target.hp+=item_point(_it) break
  case 4: system.chr_target.stamina+=item_point(_it) break
 }
 inven.it[item_search_i(argument0),item_search_j(argument0)]=item_create(item_type(_it),item_index(_it),item_point(_it),item_condition(_it),item_count(_it)-1,'ffffff','ffffff','ffffff')
 if item_count(inven.it[item_search_i(argument0),item_search_j(argument0)])=0{inven.it[item_search_i(argument0),item_search_j(argument0)]=''}
 }
break
case 4:
break
case 5:
 switch(item_index(_it))
 {
  case 0: break
  case 1: inven.book_open=_it inven.page=1 break
 }
}

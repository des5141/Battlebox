//item_add(item)
system.save_inventory=1

var i,j;

for(j=0;j<10;j+=1){for(i=0;i<5;i+=1)
{
if item_type(argument0)!=4
{
if inven.it[i,j]=''{inven.it[i,j]=argument0 exit}
}
else
{
if item_type(inven.it[i,j])=4 and item_index(inven.it[i,j])=item_index(argument0)
{
inven.it[i,j]=item_create(4,item_index(argument0),0,0,item_count(inven.it[i,j])+item_count(argument0),'ffffff','ffffff','ffffff')
exit
}
}
}}

if item_type(argument0)=4
{
for(j=0;j<10;j+=1){for(i=0;i<5;i+=1)
{
if inven.it[i,j]=''{inven.it[i,j]=argument0 exit}
}}

}

var att;
att=instance_create(x,y,obj_item)
att.item=argument0
att.player=sk_get_my_player_id()

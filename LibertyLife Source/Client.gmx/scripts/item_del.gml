//item_del(item,num)

var i,j;

for(i=0;i<5;i+=1){for(j=0;j<10;j+=1)
{

if item_type(inven.it[i,j])=item_type(argument0) and item_index(inven.it[i,j])=item_index(argument0)
{
if item_count(inven.it[i,j])>argument1{inven.it[i,j]=item_create(item_type(inven.it[i,j]),item_index(inven.it[i,j]),item_point(inven.it[i,j]),item_condition(inven.it[i,j]),item_count(inven.it[i,j])-argument1,'ffffff','ffffff','ffffff')}
else{argument1-=item_count(inven.it[i,j]) inven.it[i,j]=''}
}

if argument1<=0{exit}

}}

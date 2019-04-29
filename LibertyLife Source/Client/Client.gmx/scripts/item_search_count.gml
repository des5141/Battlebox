var i,j,count;
count=0

for(i=0;i<5;i+=1){for(j=0;j<10;j+=1)
{
if item_type(inven.it[i,j])=item_type(argument0) and item_index(inven.it[i,j])=item_index(argument0){count+=item_count(inven.it[i,j])}
}}

return count

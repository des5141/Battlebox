//quest_in(index,dex)

var i;
inx=argument0
inx_front=''
inx_back=''
dex=string(argument1)

system.save_quest_log=1

for(i=0;i<string_length(system.quest_log);i+=1)
{
if string_char_at(system.quest_log,i+1)='/'
{
if inx=1{inx_front=string_copy(system.quest_log,1,i+1)}
if inx>0{inx-=1}
else
{
inx_back=string_copy(system.quest_log,i+1,string_length(system.quest_log)-i)
system.quest_log=inx_front+dex+inx_back
exit
}
}
}


for(i=0;i<inx;i+=1){system.quest_log+='0/'}
system.quest_log+=dex+'/'

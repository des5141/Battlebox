//quest_out(index)

var i;
inx=argument0
inx_get=''

for(i=0;i<string_length(system.quest_log);i+=1)
{
if string_char_at(system.quest_log,i+1)='/'
{
if inx>0{inx_get='' inx-=1}
else{return real(inx_get) exit}
}
else{inx_get+=string_char_at(system.quest_log,i+1)}
}

if inx=0{return real(inx_get)}else{return 0}

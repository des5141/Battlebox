if kor_get_koring()=""
{
var i, str_len;
str_len=string_length(keyboard_string)

for(i=0; i<str_len; i+=1){if(ord(string_copy(keyboard_string, i+1, 1))>>7)=1{i+=1}}
//defect korean pos
if(i>str_len){keyboard_string=string_delete(keyboard_string, str_len, 1)}
//korean delete
}

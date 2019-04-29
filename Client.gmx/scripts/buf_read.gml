///buf_read(buffer, buffer_type);
if(argument1 == buffer_string) or (argument1 == buffer_text) {
    buffer_read(argument0, buffer_u16);
    return buffer_read(argument0, buffer_text);
}else
    return buffer_read(argument0, argument1);

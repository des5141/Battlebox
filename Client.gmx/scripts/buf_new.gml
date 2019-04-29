///buf_new(size);
var buffer = buffer_create(argument0, buffer_grow, 1);
buffer_write(buffer, buffer_u32, 0); // Size
buffer_write(buffer, buffer_s16, 0); // Send type
buffer_write(buffer, buffer_s16, 0); // Signal
return buffer;

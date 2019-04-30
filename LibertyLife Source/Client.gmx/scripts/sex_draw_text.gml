//x,y,string

var __i, __j, __len, __res, __dx, __dy, __sdx, __nchar, __space;

__space = 0;
__len = string_length(argument2) + 1;
__dx = argument0 + min(__len, global.__sexmaxline + 1.5) * global.__sexwidth[0] * global.__sexhalign;
__dy = argument1 + ceil(__len / global.__sexmaxline) * global.__sexwidth[1] * global.__sexvalign;
__sdx = __dx;
__j = 1;
for (__i = 1; __i < __len; __i += 1) {
 __nchar = ord(string_copy(argument2, __i, 2));
 if ((__nchar >> 7) = 1) {
  if (__nchar = $a4)
   __nchar = ((__nchar - $a4) * 94) + (ord(string_char_at(string_copy(argument2, __i, 2), 2)) - $a1);
  else
   __nchar = ((__nchar - $b0) * 94) + (ord(string_char_at(string_copy(argument2, __i, 2), 2)) - $6e);
  if (__nchar >= 0)
   draw_sprite_part_ext(global.__sexfont, (__nchar & $f00) >> 8, (__nchar & $f) * global.__sexwidth[1], ((__nchar& $f0) >> 4) * global.__sexheight, global.__sexwidth[1], global.__sexheight, __dx, __dy, 1, 1, draw_get_color(), draw_get_alpha());
  __res = 1;
 } else {
  if __nchar != ord(' ') || __space = 0{
    draw_sprite_part_ext(global.__sexfont, 10, (__nchar & $f) * global.__sexwidth[0], ((__nchar & $f0) >> 4) * global.__sexheight, global.__sexwidth[0], global.__sexheight, __dx, __dy, 1, 1, draw_get_color(), draw_get_alpha());
  } else {
   __space = 2;
   __j -= 1
  }
  __res = 0;
 }
 __i += __res;
 __j += 1 + __res;
 __dx += global.__sexwidth[__res] * (__space != 2);
 __space = 0
  if (__j / global.__sexmaxline) > 1
 {
  __j = 0
  __dy += global.__sexwidth[1];
  __dx  = __sdx;
  __space = 1
 }
}

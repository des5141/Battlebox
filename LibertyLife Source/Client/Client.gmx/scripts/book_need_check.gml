//book_need_check(item,page)

switch(item_index(argument0))
{
case 0:
case 1:
 switch(argument1)
 {
 case 0: break
 case 1: if item_search_count(item_create(4,1))>=5 and item_search_count(item_create(4,2))>=1{return 1 exit} break
 case 2: if item_search_count(item_create(4,1))>=5 and item_search_count(item_create(4,2))>=2{return 1 exit} break
 case 3: if item_search_count(item_create(4,8))>=5 and item_search_count(item_create(4,9))>=1{return 1 exit} break
 case 4: if item_search_count(item_create(4,8))>=3 and item_search_count(item_create(4,9))>=2{return 1 exit} break
 break
 }
}

return 0

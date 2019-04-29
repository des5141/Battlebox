//book_need_create(item,page)

if book_need_check(argument0,argument1)=1
{
system.k_cra+=1
system.save_state=1

switch(item_index(argument0))
{
case 0:
case 1:
 switch(argument1)
 {
 case 0: break
 case 1:
 item_del(item_create(4,1),5)
 item_del(item_create(4,2),1)
 item_add(item_create(3,1,10,0,20))
 break
 case 2:
 item_del(item_create(4,1),5)
 item_del(item_create(4,2),2)
 item_add(item_create(3,2,10,0,20))
 break
 case 3:
 item_del(item_create(4,8),5)
 item_del(item_create(4,9),1)
 item_add(item_create(3,5,5,0,50))
 break
 case 4:
 item_del(item_create(4,8),3)
 item_del(item_create(4,9),2)
 item_add(item_create(3,6,10,0,50))
 break
 }
}

}

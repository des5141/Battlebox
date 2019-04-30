//book_stage(item,page)
var bt,bit;


switch(item_index(argument0))
{
case 0: break
case 1:
 switch(argument1)
 {
 case 0: break
 case 1:
 bt='���� ������ ����� ü���� ȸ����Ű�µ� ū ������ �ش�. ��� 5���� ���۷ο� �ϳ��� ���� �����ϴ�.'
 bit=item_create(3,1,10,0,20,'ffffff','ffffff','ffffff')
 break
 case 2:
 bt='���� ������ �̿��� �ƹ��� ü���� ȸ�����ѵ� ����� ��ó�� �ƹ����� �ʴ´�. ���� ������ ����� ��ó�� �ƹ��� ���� ���̴�. ��� 5���� ���۷ο� 2���� �ʿ��ϴ�.'
 bit=item_create(3,2,10,0,20,'ffffff','ffffff','ffffff')
 break
 case 3:
 bt='�츮 ���ݼ���鵵 ����� ������ �ʿ��ϴ�. �̰��� ��ó�� ź�����ν� �����߿� ���� ��ȭ�ϴ� ����� ����� ����. �������� 5���� ����Ʈ�ö�� �Ѽ��̰� �ʿ��ϴ�.'
 bit=item_create(3,5,10,0,50,'ffffff','ffffff','ffffff')
 break
 case 4:
 bt='�̰��� ������ �ݼ� ��ġ�� ������ ġ������ Ÿ���� ������ ���Ѵ�. ������ ����ġ�� �����Դ� �ſ� Ź���� ���Ⱑ �ɰ��̴�. �������� 3���� ����Ʈ�ö�� �μ��̰� �ʿ��ϴ�.'
 bit=item_create(3,6,10,0,50,'ffffff','ffffff','ffffff')
 break
 }
break
}

var bx,by;
bx=view_xview+320-128
by=view_yview+240-80

draw_sprite(spr_book,0,bx,by)
draw_item(bit,bx+176,by+32,1,-1)
sex_set_font(12)
sex_set_halign(fa_middle)
sex_draw_text(bx+192,by+64,item_name(bit))
sex_set_halign(fa_left)
sex_set_maxline(96)
sex_draw_text(bx+16,by+16,bt)
sex_set_maxline(0)

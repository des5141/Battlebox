var name;
name=''

switch(item_type(argument0))
{
case 0: break
case 1:
switch(item_index(argument0))
{
case 0: break
case 1: name+='������ �ҵ�' break
case 2: name+='������ �׽�' break
case 3: name+='������ ���Ǿ�' break
case 4: name+='��Ʈ�� ����' break
}
break
case 2:
switch(item_index(argument0))
{
case 0: break
case 1: name+='���� �ƺ��� ����' break
case 2: name+='��Ʈ������ ����' break
case 3: name+='������ ����' break
case 4: name+='������ ī�� ����' break
case 5: name+='��Ʈ�� ���Ժ�' break
case 6: name+='' break
case 7: name+='' break
case 8: name+='' break
case 9: name+='' break
}
break
case 3:
switch(item_index(argument0))
{
case 0: break
case 1: name+='�ｺ ����' break
case 2: name+='���� ����' break
case 3: name+='���� ����' break
case 4: name+='���׹̳� ����' break
case 5: name+='�÷��� īƮ����' break
case 6: name+='���̽� īƮ����' break
case 7: name+='���� īƮ����' break
case 8: name+='����Ʈ�� īƮ����' break
case 9: name+='���ε� īƮ����' break
case 10: name+='������ īƮ����' break
case 11: name+='�𵥵� īƮ����' break
case 12: name+='������ īƮ����' break
case 13: name+='�ͽ��÷��� īƮ����' break
case 14: name+='���̺긮�� īƮ����' break
}
break
case 4:
switch(item_index(argument0))
{
case 0: break
case 1: name+='���' break
case 2: name+='���۷ο�' break
case 3: name+='ö���� ����' break
case 4: name+='��� ����' break
case 5: name+='�����̾� ����' break
case 6: name+='���޶��� ����' break
case 7: name+='������ ����' break
case 8: name+='��������' break
case 9: name+='����Ʈ �ö��' break
}
break
case 5:
switch(item_index(argument0))
{
case 0: break
case 1: name+='���� ���ݼ�' break
}
break
}

return name

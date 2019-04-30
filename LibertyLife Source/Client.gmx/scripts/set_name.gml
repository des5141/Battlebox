var _name;
_name=''
switch(job)
{
case 0: break
case 1:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='���� ��Ʈ�� ' break
    case 2: _name+='��Ʈ�� ' break
    case 3: _name+='��� ��Ʈ�� ' break
    case 4: _name+='����� ' break
    case 5: _name+='����Ʈ ' break
    }
break
case 2:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='�߽� ���� ' break
    case 2: _name+='���� ' break
    case 3: _name+='�Ӽųʸ� ' break
    case 4: _name+='���������� ' break
    case 5: _name+='è�Ǿ� ' break
    }
break
case 3:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='�ι� ' break
    case 2: _name+='�α� ' break
    case 3: _name+='���� ' break
    case 4: _name+='��� ' break
    case 5: _name+='����Ʈ��Ŀ ' break
    }
break
case 4:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='�߽��� ' break
    case 2: _name+='���� ���û� ' break
    case 3: _name+='����� ' break
    case 4: _name+='��Ƽ�� ' break
    case 5: _name+='�ͽ����� ' break
    }
break
case 5:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='�߽� ���ݼ��� ' break
    case 2: _name+='���ݼ��� ' break
    case 3: _name+='�ɹ̽�Ʈ ' break
    case 4: _name+='������ ' break
    case 5: _name+='������ ' break
    }
break
case 6:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='�齽���̴� ' break
    case 2: _name+='��ũ�θǼ� ' break
    case 3: _name+='�׷�����Ʈ ' break
    case 4: _name+='���������� ' break
    case 5: _name+='�����ε� ' break
    }
break
case 7:
    switch(job_grade)
    {
    case 0: break
    case 1: _name+='������ ' break
    case 2: _name+='��� ' break
    case 3: _name+='' break
    case 4: _name+='���� ������ ' break
    case 5: _name+='������ ' break
    }
break
}

return _name

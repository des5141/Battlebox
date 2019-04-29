///supersocket_isconnected();
if(instance_exists(sys_network)) {
    return sys_network.status;
}else{
    return -1;
}

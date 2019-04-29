///supersocket_init();
global.message_processing = ds_queue_create();
global.message_buffer = -1;

global.check_bytes_recv = 0;
global.check_bytes_send = 0;
global.timeout = 5000;
global.auth = false;

global.reconnect_ip = "";
global.reconnect_port = -1;
network_set_config(network_config_connect_timeout, 200);

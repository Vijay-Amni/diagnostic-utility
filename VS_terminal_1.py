from periphery import serial
import sys
import threading
from threading import Thread

start_query = chr(2)
end_query = chr(3)

response_check = 1
resp_str_1 = ""
resp_str_2 = ""
query_str = ""
wait_time = 1
loop = 1
serial_obj1 = serial.Serial('/dev/ttymxc4', 9600)
serial_obj2 = serial.Serial('/dev/ttymxc1', 9600)
hex_id = "%0.2X" % int(sys.argv[1])
command = sys.argv[2]


def send_rs485(serial_object, response):
    global wait_time
    global query_str
    global response_check
    serial_object.write(query_str)
    serial_object.flush()
    response = serial_object.read(50, wait_time)
    if response != "":
        response_check = 2
        print(''.join(c for c in response if ord(c) >= 32))


def main(loop_num):
    for num in range(loop_num):
        thread_mxc4 = Thread(target=send_rs485, args=(serial_obj1, resp_str_1))
        thread_mxc1 = Thread(target=send_rs485, args=(serial_obj2, resp_str_2))
        thread_mxc4.setDaemon(True)
        thread_mxc1.setDaemon(True)
        thread_mxc4.start()
        thread_mxc1.start()
        thread_mxc4.join()
        thread_mxc1.join()


if len(sys.argv) == 4:
    if command == '3':
        new_id_hex = "%0.2X" % int(sys.argv[3])
        query_str = start_query + new_id_hex + '0' + end_query
        main(loop)
        if response_check == 2:
            response_check = 3
        elif response_check == 1:
            query_str = start_query + hex_id + command + new_id_hex + end_query
            main(loop)
    else:
        query_str = start_query + hex_id + command + str(float(sys.argv[3])) + end_query
        main(loop)
elif len(sys.argv) == 5:
    loop = int(sys.argv[3])
    wait_time = float(sys.argv[4])
    query_str = start_query + hex_id + command + end_query
    main(loop)
elif len(sys.argv) == 3:
    query_str = start_query + hex_id + command + end_query
    main(loop)

if response_check == 1:
    print("No Reply, sensor with given ID is not connected or else check for the correct serial port")
if (resp_str_1.find("ok") != -1) or (resp_str_2.find("ok") != -1):
    print("-------------Done----------------")

serial_obj1.close()
serial_obj2.close()

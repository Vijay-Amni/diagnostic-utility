@echo off
echo Batch Utility to execute python program in sensor master
echo.
echo Executing Commands...
echo.
plink root@192.168.1.240 -m cmds.txt > output.txt
echo.
echo Execution Complete.
exit

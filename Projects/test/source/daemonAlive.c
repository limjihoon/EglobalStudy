#include <pthread.h>
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>

int DaemonAlive(char *proc_name);

int DaemonAlive(char *proc_name)
{
        FILE *fd;
	char buffer[80];
	int result;

	result = 0;
	sprintf(buffer, "ps -C %s", proc_name);
	fd = popen(buffer, "r");
	while (fgets(buffer, sizeof(buffer), fd)) {
		if (strstr(buffer, proc_name)) {
			result = 1;
			break;
		}
	}
	pclose(fd);

    return result;
}
int main(int argc, char** argv)
{
	if(argc != 2)
	{
		printf("useage : %s <check process name>\n", argv[0]);
		return -1;
	}

	if (DaemonAlive(argv[1]))
		printf("alive\n");
	else
		printf("dead\n");

	return 0;
}
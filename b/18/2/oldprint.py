import subprocess

def print():
    printfile = open("print.txt", r)
    
    if platform.system() == "Linux" or platform.system() == "linux":
        lpr =  subprocess.Popen("/usr/bin/lpr", stdin=subprocess.PIPE)
        print("starting to print the file")
        lpr.stdin.write(printfile)
        print("file printing finished")
    else:
        print("your operating system is not currently supported")

print()

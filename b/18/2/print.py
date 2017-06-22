import platform
import subprocess

def print():
    printfile = open("print.txt", r)
    
    if platform.system() == "Windows" or platform.system() == "windows":
        print("starting to print the file")
        win32api.ShellExecute(
            0,
            "print",
            printfile,
            '/d:"%s"' % win32print.GetDefaultPrinter (),
            ".",
            0
        )
        print("file printing finished")
    elif platform.system() == "Linux" or platform.system() == "linux":
        lpr =  subprocess.Popen("/usr/bin/lpr", stdin=subprocess.PIPE)
        lpr.stdin.write(printfile)
    else:
        print("your operating system is not currently supported")

print()

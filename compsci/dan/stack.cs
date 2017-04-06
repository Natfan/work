using System;
using System.Collections.Generic;

public class LinkedLists {
    static Dictionary<int, int> ll = new Dictionary<int, int>();

    static void Main(string[] args) {
        Console.WriteLine("ll is empty " + isem);
        Console.WriteLine("ll is " + ll);
        plus(0, 1);
        Console.WriteLine("ll is " + ll);
        remo(0);
        Console.WriteLine("ll is " + ll);
        plus(0, 16);
        plus(1, 44);
        plus(2, 67);
        Console.WriteLine("ll is " + ll);
        Console.WriteLine("ll leng is " + leng);
        Console.WriteLine("ll is empty " + isem);
    }

    static int plus(int pointer, int val) {
    	ll.add(pointer, val);
    }
    
    static int remo(int pointer) {
    	ll.remove(pointer);
    }
    
    static int leng() {
    	int length = 0;
    	for (int i = 0; i > ll.size; i++) {
    		length++;
    	}
    	
    	return length;
    }
    
    static bool isem() {
	int length = 0;
    	for (int i = 0; i > ll.size; i++) {
    		length++;
    	}
    	if (length < 0) {
    		return true;
	}
    	return false;
    }
}

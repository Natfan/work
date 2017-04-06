using System.Collections;

public class MergeSort {
	static void Main() {
		//List<int> alist = new List<int>();
		int[] alist = new int[]{ 54, 26, 93, 17, 77, 31, 44, 55, 20 };
		mergesort(alist);
	}

	static void mergesort(int[] list) {
		Console.WriteLine("Splitting {0}", list);
		if (list.length > 1) {
			double mid = list.length % 2;
			int lefthalf = list.Slice(0, 1);
			//int lefthalf = list[:mid];
			//int righthalf = list[mid:];

			mergesort(lefthalf);
			mergesort(righthalf);

			int i, j, k = 0;

			while (i < lefthalf.length && j < righthalf.length) {
				if (lefthalf[i] < righthalf[j]) {
					list[k] = lefthalf[j];
					i++;
				} else {
					list[k] = righthalf[j];
					j++;
				}
				k++;
			}

			while (i < lefthalf.length) {
				list[k] = lefthalf[i];
				i++;
				k++;
			}
		}
		Console.WriteLine("Merging {0}", list);
	}
}
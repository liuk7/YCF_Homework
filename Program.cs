using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("您需要随机产生多少个整数？");
			string str = Console.ReadLine();
			int num = int.Parse(str);

			//产生一个随机数列
			var list = new List<int>();
			var p = new Program();
			list = p.ProduceRandomList(num); //调用产生随机数列的方法

			//输出产生的随机数列
			Console.WriteLine("产生的随机数列如下：");
			foreach (var a in list)
			{
				Console.Write(a + "  ");
			}
			Console.WriteLine();

			Console.WriteLine("您需要使用哪种排序算法？(请选择相应的数字)");
			Console.WriteLine("快速排序：0");
			Console.WriteLine("冒泡排序：1");
			Console.WriteLine("归并排序：2");
			Console.WriteLine("插入排序：3");
			Console.WriteLine("选择排序：4");

			string s = Console.ReadLine();

			//按照要求的排序算法进行排序
			switch (s)
			{
				case "0":
					//p.QuickSort(list, 0, num - 1);
					p.quicksort(list, 0, num - 1);
					p.print(list);
					break;

				case "1":
					p.BubbleSort(list);
					break;

				case "2":
					p.MergeSort(list, 0, num - 1);
					p.print(list);
					break;

				case "3":
					p.InsertSort(list);
					p.print(list);
					break;

				case "4":
					p.selectionSort(list);
					p.print(list);
					break;

				default:
					Console.WriteLine("出错了，请重新输入数字。");
					break;
			}

		}

		//产生随机数列
		public List<int> ProduceRandomList(int n)
		{
			List<int> list = new List<int>();
			Random ran = new Random();
			int temp = 0;

			for (int i = 0; i < n; i++)
			{
				temp = ran.Next(1, 1000);
				list.Add(temp);
			}
			return list;
		}
		//######################################################################################################
		//快速排序算法
		//public void QuickSort(List<int> list, int low, int high)
		//{
		//	if (low < high)
		//	{
		//		int index = Partition(list, low, high);
		//		QuickSort(list, low, index - 1);
		//		QuickSort(list, index + 1, high);
		//	}
		//}

		////快排算法的辅助方法，用来进行分组
		//public int Partition(List<int> list, int low, int high)
		//{
		//	int key = list[low];

		//	while (low < high)
		//	{
		//		while (list[high] >= key && high > low) --high;
		//		Swap(list[high], list[low]);
		//		while (list[low] <= key && high > low) ++low;
		//		Swap(list[high], list[low]);
		//	}
		//	return low;
		//}

		////交换函数
		//public void Swap(int a, int b)
		//{
		//	int temp;
		//	temp = a;
		//	a = b;
		//	b = temp;
		//}

		//打印函数
		public void print(List<int> list)
		{
			foreach (var a in list)
			{
				Console.Write(a + "  ");
			}
			Console.WriteLine("");
			Console.ReadKey();
		}
		//####################
		public void quicksort(List<int> list, int low, int high)
		{
			if (low < high)
			{
				int key = list[low];
				int right = high;
				int left = low;
				while (low < high)
				{
					while (low < high && list[high] > key)
					{
						high--;
					}
					list[low] = list[high];
					while (low < high && list[low] < key)
					{
						low++;
					}
					list[high] = list[low];
				}
				list[low] = key;
				quicksort(list, left, low - 1);
				quicksort(list, low + 1, right);
			}

		}

		//#######################################################################################################

		//冒泡排序
		public void BubbleSort(List<int> list)
		{
			int temp = 0;
			int len = list.Count();

			for (int i = 0; i < (len - 1); i++)
			{
				for (int j = 0; j < (len - 1 - i); ++j)
				{
					if (list[j] > list[j + 1])
					{
						temp = list[j + 1];
						list[j + 1] = list[j];
						list[j] = temp;
					}
				}
			}

			Console.WriteLine("冒泡排序结果如下：");

			foreach (var a in list)
			{
				Console.Write(a + "  ");
			}
			Console.WriteLine();
			Console.ReadKey();
		}

		//归并排序
		public void MergeSort(List<int> array, int first, int last)
		{
			if (first < last)
			{
				int mid = (first + last) / 2;
				MergeSort(array, first, mid);
				MergeSort(array, mid + 1, last);
				Merge(array, first, mid, last);
			}

		}
		public void Merge(List<int> array, int first, int mid, int last)
		{

			int indexA = first;
			int indexB = mid + 1;
			int[] temp = new int[last + 1];
			int tempIndex = 0;
			while (indexA <= mid && indexB <= last)
			{
				if (array[indexA] <= array[indexB])
				{
					temp[tempIndex++] = array[indexA++];
				}
				else
				{
					temp[tempIndex++] = array[indexB++];
				}
			}

			while (indexA <= mid)
			{
				temp[tempIndex++] = array[indexA++];
			}
			while (indexB <= last)
			{
				temp[tempIndex++] = array[indexB++];
			}
			tempIndex = 0;
			for (int i = first; i <= last; i++)
			{
				array[i] = temp[tempIndex++];
			}
		}
		//插入排序

		public void InsertSort(List<int> list)
		{

			for (int i = 1; i < list.Count(); i++)  //外层循环，控制执行（n-1）趟排序
			{
				if (list[i] < list[i - 1])   //判断大小，决定是否需要交换
				{
					int temp = list[i];     //如果需要交换，则将待排序记录放入临时变量中
					int j = 0;
					for (j = i - 1; j >= 0 && temp < list[j]; j--) //内层循环，在有序序列中从后往前比较，找到待排序记录在有序列中位置（位置空出）
					{
						list[j + 1] = list[j];    //将有序记录往后移
					}
					list[j + 1] = temp;  //将临时变量中的值放入正确位置，即空出的位置
				}
			}
		}

		//选择排序
		public void selectionSort(List<int> list)
		{
			int minIndex = 0;
			int temp = 0;
			for (int i = 0; i < list.Count(); i++)
			{
				minIndex = i;
				for (int j = i; j < list.Count(); j++)
				{
					if (list[j] < list[minIndex]) minIndex = j;
				}
				temp = list[minIndex];
				list[minIndex] = list[i];
				list[i] = temp;
			}
		}
	}
}

using System;

public class BuildHeap
{

	// Кучу с корнем в узле i, который является индексом в arr[], N — размер кучи
	static void heapify(int[] arr, int N, int i)
	{
		int largest = i; // Инициализировать крупнейший как корень
		int l = 2 * i + 1; // лево
		int r = 2 * i + 2; // право

		// Если левый потомок больше корня
		if (l < N && arr[l] > arr[largest])
			largest = l;

		// Если правый потомок больше самого большого на данный момент
		if (r < N && arr[r] > arr[largest])
			largest = r;

		// Если самый большой не является корнем
		if (largest != i)
		{
			int swap = arr[i];
			arr[i] = arr[largest];
			arr[largest] = swap;

			// Рекурсивно выполнить пирамидальную обработку затронутого поддерева
			heapify(arr, N, largest);
		}
	}

	// Функция для построения Max-кучи из массива
	static void buildHeap(int[] arr, int N)
	{
		// Индекс последнего нелистового узла
		int startIdx = (N / 2) - 1;

		// Выполнить обход обратного порядка уровней от последнего нелистового узла и выполнить окучивание каждого узла
		for (int i = startIdx; i >= 0; i--)
		{
			heapify(arr, N, i);
		}
	}

	// Печать кучи
	static void printHeap(int[] arr, int N)
	{
		Console.WriteLine("Представление массива кучи:");

		for (int i = 0; i < N; ++i)
			Console.Write(arr[i] + " ");
	}

	public static void Main()
	{
		int[] arr = { 1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17 };
		int N = arr.Length;
		buildHeap(arr, N);
		printHeap(arr, N);
	}
}

using System; //Поехали...
					
int[,] array = new[,] //...Создадим исходный массив
{
	{4, 3, 1},
	{2, 6, 0},
	{7, 6, 2}
};

PrintResult(GetSlicedArray(array, GetMinDigitIndex(array))); //...Матрешка функций (собственно, решение)

int[] GetMinDigitIndex(int[,] array) //...Найдем индекс минимального числа в исходном массиве
{
    int tmp = array[0,0];
    int[] minDigitIndex = new int[2];
    
    for (int i=0; i<array.GetLength(0); i++)
    {
    	for (int j=0; j<array.GetLength(1); j++)
    	{
    		if (array[i,j]<tmp)
    		{
    			tmp = array[i,j];
    			minDigitIndex[0] = i;
    			minDigitIndex[1] = j;
    		}
    	}
    }
    return minDigitIndex; //...Вернем его в виде массива индексов
}

int[,] GetSlicedArray(int[,] array, int[] minDigitIndex) //...Порежем исходный массив исключив строку и столбец с минимальным значением
{
    int[,] slicedArray = new int[array.GetLength(0)-1,array.GetLength(1)-1];
    int newRow = 0, newCol;
    for (int i=0; i<array.GetLength(0); i++)
    {
    	if (i==minDigitIndex[0]) //...Пропускаем индекс строки с минимальным числом
    	{
    	    continue;
    	}
    	newCol = 0;
    	for (int j=0; j<array.GetLength(1); j++)
    	{
    		if (j==minDigitIndex[1]) //...Пропускаем индекс столбца с минимальным числом
    		{
    		    continue;
    		}
    		slicedArray[newRow,newCol] = array[i,j];
    		newCol++;
    	}
    	newRow++;
    }
    return slicedArray; //...Возвращаем порезанный массив
}

void PrintResult(int[,] slicedArray) //...Выведем результат и проверим правильно ли порезали массив
{
    for (int i=0; i<slicedArray.GetLength(0); i++)
    {
    	for (int j=0; j<slicedArray.GetLength(1); j++)
    	{
    		Console.Write($"{slicedArray[i,j]}\t");
    	}
    	Console.WriteLine();
    }
}

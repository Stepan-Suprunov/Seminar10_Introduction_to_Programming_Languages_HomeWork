int N = 50;

int[,] matrix = {{1},};

int[,] addNumber(int[,] array, int number)
{           
    for (int i = 0; i < array.GetLength(0); i++)
    {
        bool flag = false;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j] != 0 && !flag)
            {
                if (number % array[i,j] == 0)
                {
                    if ((i + 1) == array.GetLength(0))
                    {
                        array = verticalAdd(array);
                    }
                    flag = true;
                }
            }
        }
        for (int k = 0; k < array.GetLength(1); k++)
        {
            if (array[i,k] == 0 && !flag)
            {
                array[i,k] = number;
                return array;
            } 
            if (array[i,k] > 0 && (k + 1) == array.GetLength(1) && !flag)
            {
                array = horizontalAdd(array);
                array[i,(k + 1)] = number;
                return array;
            }
        }
    }
    return array;
}   

int[,] verticalAdd(int[,] array) {
    int[,] newArray = new int[(array.GetLength(0) + 1), array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            newArray[i,j] = array[i,j];
        }
    }
    return newArray;
}

int[,] horizontalAdd(int[,] array) {
    int[,] newArray = new int[array.GetLength(0), (array.GetLength(1) + 1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            newArray[i,j] = array[i,j];
        }
    }
    return newArray;
}

void printArray(int[,] array) {
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("Группа " + (i + 1) + ": ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j] > 0)
            {
                Console.Write(array[i,j] + " ");
            }
        }
        Console.WriteLine();
    }
}

for (int i = 2; i < N; i++)
{
    matrix = addNumber(matrix, i);
}

int M = matrix.GetLength(0);

printArray(matrix);
Console.WriteLine("--------------------");
Console.Write("При N заданном: " + N + "; M = " + M);

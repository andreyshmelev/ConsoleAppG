using System;
public class Program
{

    public static void Main(string[] args)
    {
        using (StreamReader file = new StreamReader("C:\\Users\\Brux\\Downloads\\testG\\tests\\01"))
        {
            var countDataSets = int.Parse(file.ReadLine());
            {
                Console.WriteLine("countDataSets  " + countDataSets);

                for (int i = 0; i < countDataSets; i++)
                {
                    
                    if (string.IsNullOrEmpty(file.ReadLine()))

                    {
                        char[,] gameAray = new char[3, 3];

                        var Xcount = 0;
                        var Ocount = 0;

                        for (int row = 0; row < 3; row++)
                        {
                            string inputsrt = (file.ReadLine());
                            for (int column = 0; column < 3; column++)
                            {
                                char inputchar = inputsrt[column];
                                gameAray[row, column] = inputchar;

                                switch (inputchar)
                                {
                                    case 'X':
                                        Xcount++;
                                        break;

                                    case 'O':
                                        Ocount++;
                                        break;
                                }
                                Console.Write(gameAray[row, column]);
                            }

                            Console.WriteLine();
                        }

                        Console.WriteLine();

                        continue;
                        var inputSet = file.ReadLine().Split(" ");

                    var row_count = int.Parse(inputSet[0]);
                    var columns_count = int.Parse(inputSet[1]);

                    var howmManyBlocksinString = new int[row_count];
                    var minimumBlockIndex = new int[row_count];
                    var maximumBlockIndex = new int[row_count];
                    var twoorMoreBlocks = new bool[row_count];

                    for (int row = 0; row < row_count; row++)
                    {
                        howmManyBlocksinString[row] = 0;
                        minimumBlockIndex[row] = -1;
                        maximumBlockIndex[row] = -1;
                        twoorMoreBlocks[row] = false;
                    }

                    char[,] mainArray = new char[row_count, columns_count];

                    int[] howmanyblocks = new int[columns_count];

                    for (int j = 0; j < columns_count; j++)
                    {
                        howmanyblocks[j] = 0;
                    }

                    for (int j = 0; j < row_count; j++)
                    {
                        var stroka = file.ReadLine();

                        for (int k = 0; k < columns_count; k++)
                        {
                            var simbolk = (char)stroka[k];

                            mainArray[j, k] = (char)
                            '.';

                            if (simbolk == (char)
                              '*')
                            {
                                howmanyblocks[k]++;
                            }
                        }
                    }

                    for (var k = 0; k < columns_count; k++)
                    {
                        var bloksinstopbec = howmanyblocks[k];
                        for (int j = 0; j < bloksinstopbec; j++)
                        {
                            mainArray[j, k] = (char)
                            '*';

                            howmManyBlocksinString[j]++;
                            if (minimumBlockIndex[j] == -1)
                            {
                                minimumBlockIndex[j] = k;
                            }
                            maximumBlockIndex[j] = k;

                            if (howmManyBlocksinString[j] >= 2)
                            {
                                twoorMoreBlocks[j] = true;
                            }
                        }

                    }

                    // заполняем водой.

                    for (int row = 0; row < row_count; row++) // количество строк
                    {

                        if ((twoorMoreBlocks[row] == false) ||
                          (maximumBlockIndex[row] == minimumBlockIndex[row] + 1)
                        )
                        {
                            break;
                        }

                        for (int col = 1; col < columns_count - 1; col++) // количество столбцов
                        {
                            if (
                              (mainArray[row, col] == (char)
                                '*')
                            )
                            {
                                continue;
                            }

                            if (
                              (col > minimumBlockIndex[row]) &&
                              (col < maximumBlockIndex[row]))
                            {
                                mainArray[row, col] = '~';
                            }

                        }
                    }


                    // выводим на экран с водой
                    for (int j = row_count - 1; j >= 0; j--) // количество строк
                    {
                        char[] strout = new char[columns_count];
                        for (int k = 0; k < columns_count; k++) // количество столбцов
                        {
                            strout[k] = mainArray[j, k];
                        }

                        Console.WriteLine(String.Join("", strout));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    }
}
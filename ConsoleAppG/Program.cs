using System;
public class Program
{

    public static bool strokaIliStolbeccheck(char[] stroka)
    {
        return true;
    }

    public struct Line
    {

        public int hX = 0;
        public int h0 = 0;

        public Line(int howManyCrosses, int howManyZeros)
        {
            hX = howManyCrosses;
            h0 = howManyZeros;
        }
    }
    public struct Stolbik
    {

        public int hX = 0;
        public int h0 = 0;

        public Stolbik(int howManyCrosses, int howManyZeros)
        {
            hX = howManyCrosses;
            h0 = howManyZeros;
        }
    }

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
                        List<Line> strokiList = new List<Line>();
                        List<Stolbik> stolbikiList = new List<Stolbik>();

                        bool result = true;

                        char[,] gameAray = new char[3, 3];

                        var Xcount = 0;
                        var zeroCount = 0;

                        Stolbik stolb0 = new Stolbik(0, 0);
                        Stolbik stolb1 = new Stolbik(0, 0);
                        Stolbik stolb2 = new Stolbik(0, 0);


                        for (int row = 0; row < 3; row++)
                        {
                            string inputsrt = (file.ReadLine());
                            
                            // проверяем каждую строку и создаем структуру строки

                            Line linenew = new Line(0, 0);

                            for (int column = 0; column < 3; column++)
                            {
                                char inputchar = inputsrt[column];
                                gameAray[row, column] = inputchar;

                                switch (inputchar)
                                {
                                    case 'X':
                                        linenew.hX++;

                                        if (column == 0)
                                        {
                                            stolb0.hX++;
                                        }
                                        else
                                             if (column == 1)
                                        {
                                            stolb1.hX++;
                                        }
                                        else
                                             if (column == 2)
                                        {
                                            stolb2.hX++;
                                        }


                                        break;

                                    case '0':
                                        linenew.h0++;
                                        if (column == 0)
                                        {
                                            stolb0.h0++;
                                        }
                                        else
                                            if (column == 1)
                                        {
                                            stolb1.h0++;
                                        }
                                        else
                                            if (column == 2)
                                        {
                                            stolb2.h0++;
                                        }
                                        break;
                                }

                                /* if  (   (Xcount > zeroCount + 1)
                                     ||  (Xcount + 1 < zeroCount)
                                     ||  (Xcount == zeroCount)
                                     )
                                         {
                                     result = false;
                                 }*/

                                //Console.Write(gameAray[row, column
                            }

                            Console.WriteLine(String.Join(" ", inputsrt));


                            //Console.WriteLine("Xcount" + Xcount);

                            //strokiList.Add(new Line(Xcount, zeroCount));
                            //Console.WriteLine("strokiList " + strokiList.Count);
                        }

                      //  Console.WriteLine(Xcount + "  " + zeroCount);
                        //Console.WriteLine(result?"TRUE":"FALSE");


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
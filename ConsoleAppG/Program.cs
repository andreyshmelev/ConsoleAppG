using System;
public class Program
{
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

    public static void Main(string[] args)
    {
        var countDataSets = int.Parse(Console.ReadLine());
        {
            for (int i = 0; i < countDataSets; i++)
            {

                if (string.IsNullOrEmpty(Console.ReadLine()))

                {
                    List<Line> strokiList = new List<Line>();
                    List<Line> stolbciList = new List<Line>();

                    bool result = true;

                    char[,] gameAray = new char[3, 3];

                    Line stolb0 = new Line(0, 0);
                    Line stolb1 = new Line(0, 0);
                    Line stolb2 = new Line(0, 0);
                    Line diagonal1 = new Line(0, 0);
                    Line diagonal2 = new Line(0, 0);

                    var indexfordiagonal = 0;
                    for (int row = 0; row < 3; row++)
                    {
                        string inputsrt = (Console.ReadLine());

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

                                    // если слева сверху вправо вниз диагональ
                                    if (indexfordiagonal == 0 || indexfordiagonal == 8)
                                    {
                                        diagonal1.hX++;
                                    }

                                    // если справа сверху влево вниз диагональ
                                    if (indexfordiagonal == 2 || indexfordiagonal == 6)
                                    {
                                        diagonal2.hX++;
                                    }

                                    // если по центру ячейка
                                    if (indexfordiagonal == 4)
                                    {

                                        diagonal1.hX++;
                                        diagonal2.hX++;
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

                                    // если слева сверху вправо вниз диагональ
                                    if (indexfordiagonal == 0 || indexfordiagonal == 8)
                                    {
                                        diagonal1.h0++;
                                    }

                                    // если справа сверху влево вниз диагональ
                                    if (indexfordiagonal == 2 || indexfordiagonal == 6)
                                    {
                                        diagonal2.h0++;
                                    }

                                    // если по центру ячейка
                                    if (indexfordiagonal == 4)
                                    {

                                        diagonal1.h0++;
                                        diagonal2.h0++;
                                    }

                                    break;
                                
                                default:
                                    break;
                            }
                            indexfordiagonal++;
                        }
                        strokiList.Add(linenew);
                    }

                    stolbciList.Add(stolb0);
                    stolbciList.Add(stolb1);
                    stolbciList.Add(stolb2);

                    //  ну все у нас есть структуры и есть данные . проверяем на вшивость

                    var alltotalX = 0;
                    var alltotalZero = 0;

                    for (var iterator1 = 0; iterator1 < 3; iterator1++)
                    {
                        alltotalX += strokiList.ElementAt(iterator1).hX;
                        alltotalZero += strokiList.ElementAt(iterator1).h0;
                    }

                    if ((diagonal1.hX == 3) || (diagonal2.hX == 3)) // если победа то крестиков должно быть на 1 больше ноликов
                    {
                        if (alltotalX != alltotalZero + 1)
                        {
                            result = false;
                        }
                    }

                    if ((diagonal1.h0 == 3) || (diagonal2.h0 == 3)) // если победа то ноликов должно быть как крестиков
                    {
                        if (alltotalZero != alltotalX)
                        {
                            result = false;
                        }
                    }

                    if (result)
                    {
                        for (var iterator1 = 0; iterator1 < 3; iterator1++)
                        {

                            if (alltotalX > alltotalZero + 1)
                            {
                                result = false;
                                break;
                            }

                            if (alltotalX < alltotalZero)
                            {
                                result = false;
                                break;
                            }

                            if (strokiList.ElementAt(iterator1).hX == 3) // если победа в какой-то из строк крестиками 
                            {
                                if (alltotalX != alltotalZero + 1)
                                {
                                    result = false;
                                    break;
                                }
                            }

                            if (stolbciList.ElementAt(iterator1).hX == 3) // если победа в какой-то из столбцов крестиками
                            {
                                if (alltotalX != alltotalZero + 1)
                                {
                                    result = false;
                                    break;
                                }
                            }
                            if (strokiList.ElementAt(iterator1).h0 == 3) // если победа в какой-то из строк нолями 
                            {
                                if (alltotalX != alltotalZero) //ноли и кресты должны быть равны по количеству
                                {
                                    result = false;
                                    break;
                                }
                            }

                            if (stolbciList.ElementAt(iterator1).h0 == 3) // если победа в какой-то из столбцов крестиками
                            {
                                if (alltotalX != alltotalZero)
                                {
                                    result = false;
                                    break;
                                }
                            }

                            if (!result)
                                break;
                        }
                    }
                    Console.WriteLine(result ? "yEs" : "nO");
                }
            }
        }
    }
}
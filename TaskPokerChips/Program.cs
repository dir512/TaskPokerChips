using System;

namespace TaskPokerChips
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите через запятую количество фишек у игроков на каждом месте: ");
            string[] strs = Console.ReadLine().Split(',');

            int elementsCount = strs.Length; //преобразуем строку в элементы массива
            int[] chips = new int[elementsCount]; // массив с кучками фишек

            int allChip = 0; // общее количество фишек
            int numMoves = 0; // количество затраченных ходов

            for (int i = 0; i < elementsCount; i++)
            {
                chips[i] = Convert.ToInt32(strs[i]);
                allChip = allChip + chips[i]; // сумма - общее количество фишек, введенное пользователем
            }

            int iMin = 0, iMax = 0; 
            // находим индексы игроков с максимальным и минимальным количеством фишек
            for (int i = 0; i < elementsCount; i++) {
                if (chips[iMax] < chips[i]) 
                    iMax = i;
                if (chips[iMin] > chips[i]) 
                    iMin = i;
            }
            while (iMax > iMin) // пока максимальное и минимальное количество фишек не сравняется....
            {
                // в зависимости от того, какой индекс больше, и справа/слева от минимального
                // передвигаем фишку из максимального индекса соответственно направо/налево
                if (iMin < iMax)
                {
                    if (iMax - iMin > elementsCount / 2) {
                        chips[iMax]--;
                        if (iMax < elementsCount - 1) 
                            iMax++;
                        else iMax = 0;
                        chips[iMax]++;
                    }
                    else {
                        chips[iMax]--;
                        if (iMax > 0) 
                            iMax--;
                        else iMax = elementsCount - 1;
                        chips[iMax]++;
                    }
                }
                else
                {
                    if (iMin - iMax < elementsCount / 2) {
                        chips[iMax]--;
                        if (iMax < elementsCount - 1) 
                            iMax++;
                        else iMax = 0;
                        chips[iMax]++;
                    }
                    else {
                        chips[iMax]--;
                        if (iMax > 0) 
                            iMax--;
                        else iMax = elementsCount - 1;
                        chips[iMax]++;
                    }
                }
                numMoves++; //+1 сделанный ход (счетчик), количество перемещений
                iMin = 0; iMax = 0;

                for (int i = 0; i < elementsCount; i++) { // снова ищем максимальную/минимальную кучку фишек
                    if (chips[iMax] < chips[i]) 
                        iMax = i;
                    if (chips[iMin] > chips[i]) 
                        iMin = i;
                }
            }

            // Проверка, если, вдруг, число фишек не делится поровну между игроками
            if (allChip % elementsCount != 0) 
            {
                Console.WriteLine("Фишки не делятся поровну между игроками");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Фишки распределены за " + numMoves + " ходов");
            Console.ReadLine();
        }
    }
}


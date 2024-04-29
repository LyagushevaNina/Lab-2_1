internal class Program
{
    internal static void Main()

    {
        // Параметры и зерно ренератора - вариант 22
        const int a = 113;
        const int c = 54;
        const int m = 211;
        const int Xo = 22;

        int X = Xo;
        bool Period = false;
        int Length = 1;
        int Even = 0;
        int Uneven = 0;
        int Zero = 0;
        int Unity = 0;

        // Выработка псевдослучайной последовательности с помощью линейного конгруэнтного генератора
        do
        {
            int N = ((a * X) + c) % m;
            Console.WriteLine(N);

            // Определение длины периода генератора
            if (N == Xo)
            {
                Period = true;
            }

            else
            {
                Length++;
            }

            Console.WriteLine($"Длина периода в битах: {Length * sizeof(int) * 8}");

            // Определение количества четных и нечетных чисел в одном периоде при однобайтовом
            // представлении выходной последовательности

            byte[] Byte = BitConverter.GetBytes(N);
            foreach (byte B in Byte)
            {
                if (B % 2 == 0)
                {
                    Even++;
                }
                else
                {
                    Uneven++;
                }
            }

            Console.WriteLine($"Количество четных чисел в периоде: {Even}");
            Console.WriteLine($"Количество нечетных чисел в периоде: {Uneven}");

            // Определение количества нулей и единиц в одном периоде при битовом представлении
            // выходной последовательности

            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                int Bit = (N >> i) & 1;
                if (Bit == 0)
                {
                    Zero++;
                }
                else
                {
                    Unity++;
                }
            }

            Console.WriteLine($"Количество нулей в периоде: {Zero}");
            Console.WriteLine($"Количество единиц в периоде: {Unity}");

            X = N;

        }

        while (!Period);
    }
}


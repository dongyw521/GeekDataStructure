namespace console_proj;

/// <summary>
/// 打印三角形
/// </summary>
public class PrintTriangle
{
    public static void PrintAT(int rowNum)
    {
        for (int i = 1; i <= rowNum; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public static void PrintBT(int rowNum)
    {
        for (int i = 1; i <= rowNum; i++)
        {
            for (int j = 1; j <= rowNum - i + 1; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }

    public static void PrintCT(int rowNum)
    {
        for (int i = 1; i <= rowNum; i++)
        {
            for (int j = 1; j <= rowNum - i; j++)
            {
                Console.Write(" ");
            }
            for (int t = 1; t <= i; t++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public static void PrintDT(int rowNum)
    {
        for (int i = 1; i <= rowNum; i++)
        {
            for (int j = i - 1; j > 0; j--)
            {
                Console.Write(" ");
            }
            for (int t = 1; t <= rowNum - i + 1; t++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public static void PrintET(int rowNum)
    {
        for (int i = 1; i <= rowNum; i++)
        {
            for (int j = 1; j <= rowNum - i; j++)
            {
                Console.Write(" ");
            }
            for (int t = 1; t <= 2 * i - 1; t++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

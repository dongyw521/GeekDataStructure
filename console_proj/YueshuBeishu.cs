namespace console_proj;

/// <summary>
/// 最大公约数，最小公倍数
/// </summary>
public class YueshuBeishu
{
    /// <summary>
    /// 最大公约数
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public static int GetMaxYueShu(int n, int m)
    {
        int max = n > m ? n : m;
        int min = n < m ? n : m;
        int ret = 1;
        for (int i = min; i >= 1; i--)
        {
            if (max % i == 0 && min % i == 0)
            {
                ret = i;
                //Console.WriteLine(i);
                break;
            }
        }
        return ret;
    }

    /// <summary>
    /// 最小公倍数=两个数的乘积除以他们的最大公约数
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    public static void GetMinBeiShu(int n, int m)
    {
        var maxYueShu = GetMaxYueShu(n, m);
        var ret = n / maxYueShu * m;
        Console.WriteLine(ret);

    }
}

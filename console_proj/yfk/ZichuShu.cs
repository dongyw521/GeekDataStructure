namespace console_proj.yfk;

public class ZichuShu
{
    /// <summary>
    /// 输出自除数
    /// 参考：https://zhuanlan.zhihu.com/p/579736880
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static List<int> GetSelfDividingNumbers(int left, int right)
    {
        var ret = new List<int>();
        for (int i = left; i <= right; i++)
        {
            var tmp = i;
            var flag = true;
            while (tmp > 0)
            {
                var digit = tmp % 10;
                if (digit == 0 || i % digit != 0)
                {
                    flag = false;
                    break;
                }

                tmp = tmp / 10;
            }
            if (flag)
            {
                ret.Add(i);
            }
        }
        return ret;
    }
}

namespace console_proj;

/// <summary>
/// 质数相关算法
/// 参考：https://www.cnblogs.com/chucklu/p/4627058.html
/// </summary>
public static class Zhishu
{
    public static void GetAllPrime(int max)
    {
        if (max < 2)
        {
            Console.WriteLine("参数错误");
            return;
        }

        // if (max == 2)
        // {
        //     Console.WriteLine(max);
        //     return;
        // }

        for (var i = 2; i <= max; i++)
        {
            var flag = true;
            for (var j = 2; j <= i - 1; j++)
            {
                if (i % j == 0)
                { 
                    flag = false;
                    break;
                }
            }
            if(flag) Console.WriteLine(i);
        }

    }

    /// <summary>
    /// 利用一个定理——如果一个数是合数，那么它的最小质因数肯定小于等于他的平方根。例如：50，最小质因数是2，2<50的开根号
    /// 再比如：15，最小质因数是3，3<15的开根号
    /// 合数是与质数相对应的自然数。一个大于1的自然数如果它不是合数，则它是质数
    /// 
    /// 只需要在大于等于2 小于max的开平方根里找是否可以整除的数就行，找到了就是合数。
    /// </summary>
    /// <param name="max"></param>
    public static bool IsPrime(int max)
    {
        var flag = true;
        var sqrtVal = Math.Floor(Math.Sqrt(max));
        for(var i = 2; i <= sqrtVal; i++)
        {
            if(max % i == 0)
            {
                flag = false;
                break;
            }
        }
        return flag;
    }
}

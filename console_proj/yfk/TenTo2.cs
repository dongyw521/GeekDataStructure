namespace console_proj.yfk;

public class TenToTwo
{
    /// <summary>
    /// 十进制转二进制
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string Convert2(uint val)
    {
        uint _tmpQuotient = val / 2;
        var _tmpResult = new List<uint>() { val % 2 };
        var _result = string.Empty;
        while (_tmpQuotient >= 1)
        {
            _tmpResult.Add(_tmpQuotient % 2);
            _tmpQuotient = _tmpQuotient / 2;
        }
        for (int i = _tmpResult.Count - 1; i >= 0; i--)
        {
            _result += _tmpResult[i];
        }
        return _result;
    }

    /// <summary>
    /// 十进制转二进制后1的个数
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int TenTo2_1Count(uint val)
    {
        int ret = 0;
        uint _tmpQuotient = val / 2;
        var _tmpResult = new List<uint>() { val % 2 };
        var _result = string.Empty;
        while (_tmpQuotient >= 1)
        {
            _tmpResult.Add(_tmpQuotient % 2);
            _tmpQuotient = _tmpQuotient / 2;
        }
        for (int i = _tmpResult.Count - 1; i >= 0; i--)
        {
            if (_tmpResult[i] == 1)
                ret++;
        }
        return ret;
    }

    #region 按位运算来计算

    /// <summary>
    /// 十进制转二进制
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ConvertTo2(uint val)
    {
        var tmpResult = new List<uint>() { val % 2 };
        var result = string.Empty;
        val = val >> 1;//val会成为val和2的商
        while (val != 0)
        {
            tmpResult.Add(val % 2);
            val = val >> 1;
        }

        // if (tmpResult.Count > 1) tmpResult.Reverse();
        // foreach (var _num in tmpResult)
        // {
        //     result += _num.ToString();
        // }

        //感觉倒着遍历，比反转字list应该效率高
        for (int i = tmpResult.Count - 1; i >= 0; i--)
        {
            result += tmpResult[i].ToString();//toString()可以避免装箱操作。
        }
        return result;
    }

    /// <summary>
    /// 十进制转换为二进制后有几个1
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int TenTo2_1Count2(uint val)
    {
        int count = 0;
        while (val != 0)
        {
            if (val % 2 == 1)
            {
                count++;
            }
            val = val >> 1;
        }
        return count;
    }

    /// <summary>
    /// 十进制转换为二进制后有几个1
    /// 根据这个规律f[i]=f[i&(i-1)]+1且f[0]=0，来递归运算
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static int TenTo2_1Count3(uint val)
    {
        if (val == 0) return 0;
        return TenTo2_1Count3(val & (val - 1)) + 1;
    }

    /// <summary>
    /// 打印1到max之间正整数转换为2进制后1的个数
    /// </summary>
    /// <param name="max"></param>
    public static void PrintTenTo2Count(uint max)
    {
        for (uint i = 1; i <= max; i++)
        {
            Console.WriteLine($"数字{i.ToString()}，二进制后1的个数{TenTo2_1Count3(i).ToString()}");
        }
    }

    #endregion
}

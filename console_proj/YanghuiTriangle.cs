using System.Runtime.Versioning;
namespace console_proj;

/// <summary>
/// 杨辉三角
/// </summary>
public class YanghuiTriangle
{
    public static void PrintYhTriangle(int rowNum)
    {
        var ret = new List<List<int>>();
        for (int i = 0; i < rowNum; i++)
        {
            var _row = new List<int>();
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    _row.Add(1);
                }
                else
                {
                    _row.Add(ret[i - 1][j - 1] + ret[i - 1][j]);
                }
            }
            ret.Add(_row);
        }
        if (ret.Count > 0)
        {
            foreach (var _row in ret)
            {
                foreach (var _num in _row)
                {
                    Console.Write(_num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

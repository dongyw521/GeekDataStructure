namespace console_proj.yfk;

public class JiOuSort
{
    /// <summary>
    /// 把数字分成奇偶两部分，奇数在前，偶数在后。
    /// 参考：https://blog.csdn.net/weixin_63257947/article/details/123379189
    /// </summary>
    /// <param name="numList"></param>
    public static void JOSortArray(int[] numList)
    {
        Console.WriteLine($"原数组：{String.Join(',', numList)}");
        var numCount = numList.Count();
        if (numCount == 1)
            Console.WriteLine($"新数组：{String.Join(',', numList)}");
        else
        {
            var newArray = new int[numCount];
            int j = numCount - 1;
            int m = 0;

            while (m < j)
            {
                while (m < j && numList[m] % 2 == 1)//找到偶数跳出循环
                {
                    m++;
                }
                while (m < j && numList[j] % 2 == 0)//找到奇数跳出循环
                {
                    j--;
                }
                int tmp = numList[m];
                numList[m] = numList[j];
                numList[j] = tmp;
            }

            // for (int i = 0; i < numCount; i++)
            // {
            //     int _index = i;
            //     if (numList[i] % 2 == 0)
            //     {
            //         _index = j;
            //         j--;
            //     }
            //     else
            //     {
            //         _index = m;
            //         m++;
            //     }

            //     newArray[_index] = numList[i];
            // }
            // if (m > 0)
            // {
            //     for (int i = 0; i < m; i++)
            //     {

            //     }
            // }
            // if (j < numCount - 1)
            // {

            // }
            Console.WriteLine($"新数组：{String.Join(',', numList)}");
        }

    }

    /// <summary>
    /// 奇偶分布数组，并分别对两部分插入排序
    /// 思想：mid,end两个指针把数组分成三个区间
    /// mid指向偶数区间第一个元素
    /// end指向未排序区间第一个元素
    /// 参考：https://blog.csdn.net/John_Lan_2008/article/details/70169829
    /// </summary>
    /// <param name="numList"></param>
    public static void JOSortArray2(int[] numList)
    {
        int mid = 0;
        int end = 0;
        var numCount = numList.Count();
        if (numCount == 1)
            Console.WriteLine($"2新数组：{String.Join(',', numList)}");
        else
        {
            for (; end < numCount; end++)
            {
                var j = end;//从后往前找插入位置
                var tmp = numList[end];//临时存放未排序区间第一个元素，找到插入位置后在赋值到相应位置
                if (numList[end] % 2 == 1)
                {
                    //奇数时需要越过整个偶数区间，在奇数区间找插入位置
                    //j-1>=mid就是越过整个偶数区间的判断条件
                    //tmp < numList[j - 1] && j - 1 >= 0 这个是在奇数区间寻找插入位置
                    while (j - 1 >= mid || (j - 1 >= 0 && tmp < numList[j - 1]))
                    {
                        numList[j] = numList[j - 1];//把数组中的数据依次往后挪
                        j--;
                    }
                    mid++;
                }
                else
                {
                    //j - 1 >= mid && tmp < numList[j - 1] 这个是在偶数区间找插入位置
                    while (j - 1 >= mid && tmp < numList[j - 1])
                    {
                        numList[j] = numList[j - 1];
                        j--;
                    }
                }
                numList[j] = tmp;
            }
            Console.WriteLine($"2新数组：{String.Join(',', numList)}");
        }
    }
}

namespace console_proj.yfk;

public class CaiShu
{
    public static string CaishuGame(int num)
    {
        int a = 0;
        int b = 0;
        var ret = string.Empty;
        var correctNum = "4589".ToList();
        var inputStr = num.ToString().ToCharArray().ToList();
        for (int i = 0; i < inputStr.Count; i++)
        {
            if (correctNum.Contains(inputStr[i]))
            {
                b++;
            }
            if (correctNum[i] == inputStr[i])
            {
                a++;
            }

        }
        b = b - a;
        ret = $"{a}A{b}B";
        return ret;
    }

    /// <summary>
    /// 生成答案
    /// </summary>
    /// <returns></returns>
    public static string MakeAnswer()
    {
        string ret = string.Empty;
        Random rd = new Random();
        int num1 = rd.Next(0, 9);
        int num2 = rd.Next(0, 9);
        int num3 = rd.Next(0, 9);
        int num4 = rd.Next(0, 9);

        ret = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();
        return ret;
    }
}

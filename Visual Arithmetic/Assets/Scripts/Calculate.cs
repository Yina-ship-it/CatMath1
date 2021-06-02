using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Calculate : MonoBehaviour
{
    static public double ToCalculate(string input)
    {
        var output = input.Split(' ').ToList();
        double result = Resh(output, 0);

        return result;
    }
    private static double Resh(List<string> list, byte priority)
    {
        double sum = 0;
        if (priority == 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][0] == '(')
                {
                    list[i] = list[i].Substring(1);
                    int j = 1;
                    while (list[j][list[j].Length - 1] != ')')
                        j++;
                    var listf = new string[j - i + 1];
                    list.CopyTo(i, listf, 0, j - i + 1);
                    double vrem = Resh(listf.ToList(), 1);
                    j = 1;
                    while (list[j][list[j].Length - 1] != ')')
                        j++;
                    list[i] = vrem.ToString();
                    list.RemoveRange(i + 1, j - i);
                }
            }
            priority++;
        }
        if (priority == 1)
        {
            for (int i = 1; i < list.Count; i++)
            {
                double vrem;
                switch (list[i][list[i].Length - 1])
                {
                    case '*':
                        var listf = new string[3];
                        list.CopyTo(i - 1, listf, 0, 3);
                        vrem = Calc(listf.ToList(), 0);
                        sum = vrem;
                        list[i - 1] = vrem.ToString();
                        list.RemoveRange(i, 2);
                        i--;
                        break;
                    case '/':
                        var listfm = new string[3];
                        list.CopyTo(i - 1, listfm, 0, 3);
                        vrem = Calc(listfm.ToList(), 1);
                        sum = vrem;
                        list[i - 1] = vrem.ToString();
                        list.RemoveRange(i, 2);
                        i--;
                        break;
                }

            }
            priority++;
        }
        if (priority == 2)
            for (int i = 1; i < list.Count; i++)
            {
                double vrem;
                switch (list[i][list[i].Length - 1])
                {
                    case '+':
                        var listf = new string[3];
                        list.CopyTo(i - 1, listf, 0, 3);
                        vrem = Calc(listf.ToList(), 2);
                        list[i - 1] = vrem.ToString();
                        list.RemoveRange(i, 2);
                        sum = vrem;
                        i--;
                        break;
                    case '-':
                        var listfm = new string[3];
                        list.CopyTo(i - 1, listfm, 0, 3);
                        vrem = Calc(listfm.ToList(), 3);
                        list[i - 1] = vrem.ToString();
                        list.RemoveRange(i, 2);
                        sum = vrem;
                        i--;
                        break;
                }
            }
        return sum;
    }

    static double Calc(List<string> list, byte op)
    {
        double sum = 0;
        switch (op)
        {
            case 0:
                if (list[2][list[2].Length - 1] == ')')
                    list[2] = list[2].Substring(0, list[2].Length - 1);
                sum = double.Parse(list[0]) * double.Parse(list[2]);
                break;
            case 1:
                if (list[2][list[2].Length - 1] == ')')
                    list[2] = list[2].Substring(0, list[2].Length - 1);
                sum = double.Parse(list[0]) / double.Parse(list[2]);
                break;
            case 2:
                if (list[2][list[2].Length - 1] == ')')
                    list[2] = list[2].Substring(0, list[2].Length - 1);
                sum = double.Parse(list[0]) + double.Parse(list[2]);
                break;
            case 3:

                if (list[2][list[2].Length - 1] == ')')
                    list[2] = list[2].Substring(0, list[2].Length - 1);
                sum = double.Parse(list[0]) - double.Parse(list[2]);

                break;
        }
        return sum;
    }
}

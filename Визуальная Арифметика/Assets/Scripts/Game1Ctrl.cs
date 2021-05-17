using UnityEngine;
using UnityEngine.UI;

public class Game1Ctrl : MonoBehaviour
{

    [Tooltip("Количество чисел")]public int n;
    [Tooltip("Максимальное число")] public int max;
    [Tooltip("Ставь 2, если хочешь шоб были + и -\nСтавь 4, если хочешь чтоб были вдобавок * и /")] public int numberSigns;
    [Tooltip("Тот коэффициент для третьего лвл\n(Для обычного ставь 1)")] [Range(0.0f,1.0f)] public double k;
    [Tooltip("Текст в котором будет первое выражение")] public Text FirstExp;
    [Tooltip("Текст в котором будет второе выражения")] public Text SecondExp;
    [Tooltip("Текст в котором будут писаться очки")] public Text score;
    public GameObject VashPrefab;
    [HideInInspector] public GameObject canvas;
    [HideInInspector] private int count;
    [HideInInspector] private GameObject Prefab;
    [HideInInspector] public bool next, lose;
    [HideInInspector] public int sign;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        count = 0;
        next = false;
        lose = false;
        sign = CreateExp(FirstExp).CompareTo(CreateExp(SecondExp));
    }
    void Update()
    {
        if (next)
            NextExp();
        else if (lose)
        {
            PlayerLose();
            lose = false;
        }
    }

    void NextExp()
    {
        FirstExp.text = "";
        SecondExp.text = "";
        count++;
        score.text = count.ToString();
        var firstE = CreateExp(FirstExp);
        var secondE = CreateExp(SecondExp);
        sign = firstE.CompareTo(secondE);
        next = false;
    }


    double CreateExp(Text exp)
    {
        var numbers = new double[n];
        var signPrev = "";
        var signs = new string[] { " + ", " - ", " / ", " * " };
        string sign;
        var secret = 0.0;
        for (var i = 0; i < n; i++)
        {
            numbers[i] = System.Math.Round(Random.Range(1, max) * k, 1);
            if (i > 0)
            {
                if (signPrev != " * " && signPrev != " / ")
                {
                    if (numbers[i - 1] == 1 && numberSigns > 2)
                        sign = signs[Random.Range(0, 2)];
                    else
                        sign = signs[Random.Range(0, numberSigns)];
                    numbers[i] = System.Math.Round(Random.Range(2, max) * k, 1);
                }
                else
                    sign = signs[Random.Range(0, 2)];               
                exp.text += sign;
                switch (sign)
                {
                    case " + ":
                        numbers[0] += numbers[i];
                        break;
                    case " - ":
                        numbers[0] -= numbers[i];
                        break;
                    case " * ":
                        secret = numbers[i - 1] * numbers[i];
                        switch (signPrev)
                        {
                            case " + ":
                                numbers[0] -= numbers[i - 1];
                                numbers[0] += secret;
                                break;
                            case " - ":
                                numbers[0] += numbers[i - 1];
                                numbers[0] -= secret;
                                break;
                            default:
                                numbers[0] = secret;
                                break;
                        }
                        break;
                    case " / ":
                        secret = numbers[i - 1] / numbers[i];
                        switch (signPrev)
                        {
                            case " + ":
                                numbers[0] -= numbers[i - 1];
                                numbers[0] += secret;
                                break;
                            case " - ":
                                numbers[0] += numbers[i - 1];
                                numbers[0] -= secret;
                                break;
                            default:
                                numbers[0] = secret;
                                break;
                        }
                        break;
                }
                signPrev = sign;
            }
            exp.text += numbers[i].ToString();
        }
        return numbers[0];
    }

    void PlayerLose()
    {
        Prefab = Instantiate(VashPrefab);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);
        Prefab.GetComponent<WindowLoseScript>().score = count;
    }
}

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
    [HideInInspector] public bool next, lose, update;
    [HideInInspector] public int sign;


    private void Awake()
    {
        n = DataHolder.N;
        max = DataHolder.Max;
        numberSigns = DataHolder.NumberSigns;
        k = DataHolder.k;
    }
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        count = 0;
        DataHolder.Score = count;
        next = false;
        lose = false;
        update = true;
        sign = CreateExp(FirstExp).CompareTo(CreateExp(SecondExp));
    }
    void Update()
    {
        if (!update) 
            return;
        else if (next)
            NextExp();
        else if (lose)
            PlayerLose();
    }

    void NextExp()
    {
        GameObject.Find("Timer").GetComponent<Image>().fillAmount = 100f;
        GameObject.Find("Timer").GetComponent<Image>().color = new Color(255,255,255);
        FirstExp.text = "";
        SecondExp.text = "";
        count++;
        DataHolder.Score = count;
        score.text = count.ToString();
        var firstE = CreateExp(FirstExp);
        var secondE = CreateExp(SecondExp);
        sign = firstE.CompareTo(secondE);
        next = false;
    }


    double CreateExp(Text exp)
    {
        var example = new System.Text.StringBuilder();
        var brExampleSb = new System.Text.StringBuilder();
        string brExampleStr = "";
        bool bracket = false;
        int bracketOpenLastID = 0;
        int bracketCloseLastID = -2;
        double number = 0;
        double numberVrem = 0;
        string sign = "";
        int idAdekvatnosti = 0;
        bool[] helps = new bool[3];


        if (numberSigns > 2 && n > 2 && Random.Range(1, 6) == 5) //скобочка начало
        {
            helps[0] = true;
            helps[1] = true;
            bracket = true;
            example.Append("(");
            bracketOpenLastID = 0;
        }
        for (int i = 0; i < n; i++)
        {
            number = System.Math.Round(k * Random.Range(1, max), 1);
            while (number == numberVrem && sign != " * " && sign != " / ")
                number = System.Math.Round(k * Random.Range(1, max), 1);
            while (numberSigns > 2 && number == 1 && (sign == " * " || sign == " / "))
                number = System.Math.Round(k * Random.Range(2, max), 1);
            numberVrem = number;
            if (i > 0 && (!bracket || bracket && i - bracketOpenLastID > 0))
                example.Append(sign);
            if (number == 1)
                helps[2] = true;
            example.Append(number); //обычное число
            if (bracket)
            {
                if (i - bracketOpenLastID > 0)
                    brExampleSb.Append(sign);
                brExampleSb.Append(number);
            }

            if (bracket && (Random.Range(1, 6) > 1 && i - bracketOpenLastID > 1 || i == n - 1) || helps[0] && i == n - 2)//скобочка конец
            {
                if (helps[1] && !helps[0])
                {
                    if (i == n - 1)
                    {
                        switch (Random.Range(1, numberSigns))
                        {
                            case 1:
                                example.Insert(idAdekvatnosti, " - ");
                                break;
                            case 2:
                                example.Insert(idAdekvatnosti, " * ");
                                break;
                            case 3:
                                example.Insert(idAdekvatnosti, " / ");
                                break;
                        }
                        helps[1] = false;
                    }
                    else
                    {
                        example.Insert(idAdekvatnosti, " + ");
                    }
                }
                helps[2] = false;
                helps[0] = false;
                bracket = false;
                example.Append(")");
                brExampleStr = brExampleSb.ToString();
                brExampleSb.Clear();
                bracketCloseLastID = i;
            }
            if (i < n - 1)// знак

            {
                switch (Random.Range(0, numberSigns))
                {
                    case 0:
                        if (!bracket && helps[1] && numberSigns > 2)
                        {
                            switch (Random.Range(2, numberSigns))
                            {
                                case 2:
                                    sign = " * ";
                                    break;
                                case 3:
                                    sign = " / ";
                                    break;
                            }
                            helps[1] = false;
                        }

                        else
                            sign = " + ";
                        break;
                    case 1:
                        if (!bracket && helps[1] && numberSigns > 2)
                        {
                            switch (Random.Range(2, numberSigns))
                            {
                                case 2:
                                    sign = " * ";
                                    break;
                                case 3:
                                    sign = " / ";
                                    break;
                            }
                            helps[1] = false;
                        }

                        else
                            sign = " - ";
                        break;
                    case 2:
                        if (helps[2])
                            switch (Random.Range(0, 2))
                            {
                                case 0:
                                    sign = " + ";
                                    break;
                                case 1:
                                    sign = " - ";
                                    break;
                            }
                        else
                            sign = " * ";
                        break;
                    case 3:
                        if (helps[2])
                            switch (Random.Range(0, 2))
                            {
                                case 0:
                                    sign = " + ";
                                    break;
                                case 1:
                                    sign = " - ";
                                    break;
                            }
                        else
                            sign = " / ";
                        break;
                }
            }
            if (!bracket && i < n - 2 && bracketCloseLastID != i && Random.Range(1, 6) == 5) //скобочка начало
            {
                bracket = true;
                if (sign == " + ")
                {
                    if (numberSigns > 2)
                    {
                        helps[1] = true;
                        idAdekvatnosti = example.Length;
                    }
                    else
                    {
                        sign = " - ";
                        example.Append(sign);
                    }

                }
                else
                    example.Append(sign);
                example.Append("(");
                brExampleSb.Clear();
                bracketOpenLastID = i + 1;
            }
        }
        exp.text = example.ToString();
        return Calculate.ToCalculate(example.ToString());
    }

    void PlayerLose()
    {
        update = false;
        Prefab = Instantiate(VashPrefab);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);
        GameObject.Find("Timer").GetComponent<Image>().fillAmount = 0;
    }
}

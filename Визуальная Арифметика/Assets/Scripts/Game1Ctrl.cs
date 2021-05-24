using UnityEngine;
using UnityEngine.UI;

public class Game1Ctrl : MonoBehaviour
{

    [Tooltip("���������� �����")]public int n;
    [Tooltip("������������ �����")] public int max;
    [Tooltip("����� 2, ���� ������ ��� ���� + � -\n����� 4, ���� ������ ���� ���� �������� * � /")] public int numberSigns;
    [Tooltip("��� ����������� ��� �������� ���\n(��� �������� ����� 1)")] [Range(0.0f,1.0f)] public double k;
    [Tooltip("����� � ������� ����� ������ ���������")] public Text FirstExp;
    [Tooltip("����� � ������� ����� ������ ���������")] public Text SecondExp;
    [Tooltip("����� � ������� ����� �������� ����")] public Text score;
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
        var signPrev = true;
        var signs = new string[] { " + ", " - ", " / ", " * " };
        string sign = "";
        var example = new System.Text.StringBuilder();
        for (var i = 0; i < n; i++)
        {
            numbers[i] = System.Math.Round(Random.Range(1, max) * k, 1);
            if (i > 0)
            {
                if (signPrev)
                {
                    if (numbers[i - 1] == 1 && numberSigns > 2)
                        example.Append(signs[Random.Range(0, 2)]);
                    else
                    {
                        sign = signs[Random.Range(0, numberSigns)];
                        if (sign == signs[2] || sign == signs[3])
                            signPrev = false;
                    }

                    numbers[i] = System.Math.Round(Random.Range(2, max) * k, 1);
                }
                else
                {
                    sign = signs[Random.Range(0, 2)];
                    signPrev = true;
                }
                example.Append(sign);
            }   
            example.Append(numbers[i].ToString());
        }
        
        exp.text = example.ToString();
        return Calculate.ToCalculate(example.ToString());
    }

    void PlayerLose()
    {
        Prefab = Instantiate(VashPrefab);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);
        Prefab.GetComponent<WindowLoseScript>().score = count;
    }
}

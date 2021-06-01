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
        string sign = "";


        if (n > 2 && Random.Range(1, 6) == 5) //�������� ������
        {
            bracket = true;
            example.Append("(");
            exp.text += "(";
            bracketOpenLastID = 0;
        }
        for (int i = 0; i < n; i++)
        {
            number = System.Math.Round(k * Random.Range(1, max), 1);
            if (i > 0 && (!bracket || bracket && i - bracketOpenLastID > 0))
            {
                example.Append(sign);
                exp.text += sign;
            }

            example.Append(number); //������� �����
            exp.text += number.ToString();
            if (bracket)
            {
                if (i - bracketOpenLastID > 0)
                    brExampleSb.Append(sign);
                brExampleSb.Append(number);
            }

            if (bracket && (Random.Range(1, 6) > 1 && i - bracketOpenLastID > 1 || i == n - 1))//�������� �����
            {
                bracket = false;
                example.Append(")");
                exp.text += ")";
                brExampleStr = brExampleSb.ToString();
                brExampleSb.Clear();
                bracketCloseLastID = i;
            }
            if (i < n - 1)// ����

            {

                switch (Random.Range(0, numberSigns))
                {
                    case 0:
                        sign = " + ";
                        break;
                    case 1:
                        sign = " - ";

                        break;
                    case 2:
                        sign = " * ";

                        break;
                    case 3:
                        sign = " / ";
                        break;
                }
            }
            if (!bracket && i < n - 2 && bracketCloseLastID != i && Random.Range(1, 6) == 5) //�������� ������
            {
                bracket = true;
                example.Append(sign);
                exp.text += sign;
                example.Append("(");
                exp.text += "(";
                brExampleSb.Clear();
                bracketOpenLastID = i + 1;
            }
        }
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

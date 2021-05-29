using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Game2Ctrl : MonoBehaviour
{
    [Tooltip("время запоминания")] [Range(0.0f, 5.0f)] public float timeRemember;
    [Tooltip("Максимальное число")] public int maxNumber;
    [Tooltip("Количество чисел")] public int numbers;
    [Tooltip("Текст в котором будут писаться числа")] public Text output;
    [Tooltip("Текст в котором будут писаться очки")] public Text score;
    [Tooltip("Текста с ответами")] public Text[] buttons;
    [Tooltip("Панель с кнопками")] public GameObject panel;
    public Text delay;
    public GameObject VashPrefab;
    [HideInInspector] public GameObject canvas;
    [HideInInspector] public GameObject back;
    [HideInInspector] private int count;
    [HideInInspector] private GameObject Prefab;
    [HideInInspector] public int CorrectAnswerID;
    [HideInInspector] public bool next, lose;

    private void Awake()
    {
        timeRemember = DataHolder.timeRemember;
        maxNumber = DataHolder.maxNumber;
        numbers = DataHolder.numbers;
    }

    void Start()
    {
        back = GameObject.Find("Back");
        canvas = GameObject.Find("Canvas");
        count = 0;
        DataHolder.Score = count;
        next = false;
        lose = false;
        back.SetActive(false);
        StartCoroutine(TimeDelay());
    }
    void Update()
    {
        if (next)
        {
            NextExp();
        }
        else if (lose)
        {
            PlayerLose();
            lose = false;
        }

    }

    private void NextExp()
    {
        count++;
        DataHolder.Score = count;
        score.text = count.ToString();
        StartCoroutine(CreateExp());
        next = false;
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1f);
        delay.text = "3";
        yield return new WaitForSeconds(1f);
        delay.text = "2";
        yield return new WaitForSeconds(1f);
        delay.text = "1";
        yield return new WaitForSeconds(1f);
        delay.text = "Start!";
        yield return new WaitForSeconds(1f);
        delay.text = "";
        StartCoroutine(CreateExp());
    }

    private IEnumerator CreateExp()
    {
        var sum = 0;
        var numers = new int[numbers];

        back.SetActive(false);
        panel.SetActive(false);
        for (var i = 0; i < numbers; i++)
        {
            var lastnumber = Random.Range(1, maxNumber + 1);
            switch (Random.Range(0, 2))
            {
                case 0:
                    sum += lastnumber;
                    output.text = "+ " + lastnumber.ToString();
                    numers[i] = -lastnumber;
                    break;
                case 1:
                    sum -= lastnumber;
                    output.text = "- " + lastnumber.ToString();
                    numers[i] = lastnumber;
                    break;
            }
            yield return new WaitForSeconds(timeRemember);
            output.text = "";
            yield return new WaitForSeconds(0.5f);
        }
        output.text = "";
        CorrectAnswerID = Random.Range(0, 4);
        back.SetActive(true);
        panel.SetActive(true);
        AddButtons(sum, numers);
    }

    private void AddButtons(int sum, int[] fakeNumbers)
    {
        buttons[CorrectAnswerID].text = sum.ToString();
        var BedSignID = Random.Range(0, buttons.Length);
        while (BedSignID == CorrectAnswerID)
            BedSignID = Random.Range(0, buttons.Length);
        var bedSign = sum + 2 * fakeNumbers[Random.Range(0, numbers)];
        while (bedSign == sum)
            bedSign = sum + 2 * fakeNumbers[Random.Range(0, numbers)];
        buttons[BedSignID].text = bedSign.ToString();

        var MaxErrorID = Random.Range(0, buttons.Length);
        while (MaxErrorID == CorrectAnswerID || MaxErrorID == BedSignID)
            MaxErrorID = Random.Range(0, buttons.Length);
        var maxError = sum + Random.Range(-maxNumber, maxNumber + 1);
        while (maxError == sum || maxError == bedSign)
            maxError = sum + Random.Range(-maxNumber, maxNumber + 1);
        buttons[MaxErrorID].text = maxError.ToString();

        var MinErrorID = 6 - MaxErrorID - BedSignID - CorrectAnswerID;
        var minError = sum + Random.Range(-maxNumber / 2, (maxNumber + 1) / 2);
        while (minError == sum || minError == bedSign || minError == maxError)
            minError = sum + Random.Range(-maxNumber / 2, (maxNumber + 1) / 2);
        buttons[MinErrorID].text = minError.ToString();
    }

    void PlayerLose()
    {
        Prefab = Instantiate(VashPrefab);
        Prefab.transform.SetParent(canvas.transform);
        Prefab.transform.localScale = new Vector2(1f, 1f);
    }
}

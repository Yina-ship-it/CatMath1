public static class DataHolder
{
    public static int Game;

    public static int N;
    public static int Max;
    public static int NumberSigns;
    public static double k;

    public static float timeRemember;
    public static int maxNumber;
    public static int numbers;

    public static bool pauseTimer;
    public static int Score;
    public static string[,] languageText = new string[,]
    { 
        {
            @"In this mode, you have to compare 2 numbers with each other, for each correct answer you get one point. There are three levels of difficulty of the game:

Easy. Here are short expressions with a length of 4 terms from the mathematical operations only + and -, the numbers are integers and do not exceed 20.

Normal. Expressions are already longer, 5 terms. Mathematical operators: "" * / + - "". Integers are not more than 200.

Hard. The length of the expression and the list of mathematical operations is the same as the ""Normal"" mode, but now the numbers are not integers but decimals with 1 decimal place.",
            @"In this mode, the parts of the example that you have to solve will be shown sequentially. There are three levels of difficulty:

Easy. Large delay between parts of the expression. The maximum number is 10. The number of numbers is 5.

Normal. The average delay between parts of an expression. The maximum number is 20. The number of numbers is 7.

Hard. A small delay between the parts of the expression. The maximum number is 20. The number of numbers is 10.",
            "SOmething in English for the third mode",
            "SOmething in English for the fourth mode",
            "A NEW RECORD!!!",
            "record :"
        },
        {
            @"В этом режиме вам предстоит сравнить 2 числа между собой, за каждый правильный ответ вы получаете по одному очку. Есть три уровня сложности игры:

Easy. Тут короткие выражения длинной в 4 слагаемых из математических операций только + и -, числа целые и не превышают 20.

Normal. Выражения уже длиннее, 5 слагаемых. Математические операторы: "" * / + - "". Числа целые не больше 200.

Hard. Длина выражения и перечень математических операций совпадает с режимом ""Normal"", но теперь числа не целые а десятичные с 1 знаком после запятой.",
            @"В этом режиме будут последовательно показываться части примера, который вам предстоит решить. Есть три уровня сложности:

Easy. Большая задержка между частями выражения. Максимальное число 10. Количество слагаемых 5.

Normal. Средняя задержка между частями выражения. Максимальное число 20. Количество слагаемых 7.

Hard. Маленькая задержка между частями выражения. Максимальное число 20. Количество слагаемых 10.",
            "ЧТото на русском для третьего режима",
            "ЧТото на русском для четвёртого режима",
            "НОВЫЙ РЕКОРД!!!",
            "рекорд :"
        }
    };
}

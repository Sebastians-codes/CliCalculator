List<char> nums1 = [];
List<char> nums2 = [];
char[] operators = ['*', '-', '+', '/'];
decimal result = 0;

do {
    decimal number1 = result;
    char op;
    if (nums1.Count == 0) {
        do {
            Console.Clear();
            Console.Write($"-> {string.Join("", nums1)}");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (operators.Contains(key.KeyChar) && nums1.Count > 0) {
                op = key.KeyChar;
                number1 = decimal.Parse(string.Join("", nums1));
                break;
            }


            if (int.TryParse(key.KeyChar.ToString(), out int num) ||
                key.KeyChar.Equals('.') && !nums1.Contains('.') && nums1.Count >= 1) {
                nums1.Add(key.KeyChar);
            }
        } while (true);
    }
    else
        do {
            Console.Clear();
            Console.Write($"-> {number1}");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (operators.Contains(key.KeyChar)) {
                op = key.KeyChar;
                break;
            }
        } while (true);

    decimal number2;
    do {
        Console.Clear();
        Console.Write($"-> {number1} {op} {string.Join("", nums2)}");
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter || key.KeyChar.Equals('=') && nums2.Count >= 1) {
            number2 = decimal.Parse(string.Join("", nums2));
            break;
        }

        if (int.TryParse(key.KeyChar.ToString(), out int num) ||
            key.KeyChar.Equals('.') && !nums2.Contains('.') && nums2.Count >= 1) {
            nums2.Add(key.KeyChar);
        }
    } while (true);

    result = op switch {
        '+' => number1 + number2,
        '-' => number1 - number2,
        '*' => number1 * number2,
        '/' => number2 == 0 ? number1 : number1 / number2,
        _ => 0
    };
    Console.Clear();
    Console.Write($"{number1} {op} {number2} = {result}");
    Console.ReadKey();
    nums2.Clear();
} while (true);
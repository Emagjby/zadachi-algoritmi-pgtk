Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();
Dictionary<string, double> sorted = new Dictionary<string, double>();

double maxSalary = int.MinValue;

AddSalaries();
WaitForCMD();

FindMostExpensive();
FindLeastExpensive();
Average();
Sum();

DisplaySalaries();

void AddSalaries()
{
    while (true)
    {
        string[] input = Console.ReadLine().Split(" ").ToArray();
        if (input[0].ToLower() == "stop")
        {
            break;
        }

        keyValuePairs.Add(input[0], double.Parse(input[1]));
    }
}

void DisplaySalaries()
{
    Sort();
    foreach (var kvp in sorted)
    {
        Console.WriteLine(kvp.Key + " " + kvp.Value);
    }
}

void SearchByWorker(string name)
{
    bool found = false;
    foreach (var kvp in keyValuePairs)
    {
        if (kvp.Key.ToLower() == name.ToLower())
        {
            found = true;
            Console.WriteLine($"Има назначен работник на име {kvp.Key}, който получава заплата {kvp.Value} лева.");
        }
    }

    if (!found)
    {
        Console.WriteLine($"Няма назначен работник на име {name}.");
    }
}

void WaitForCMD()
{
    Console.WriteLine("\nНапишете Search [worker name], за да търсите заплата по име на работник.\n");

    while (true)
    {
        string[] cmd = Console.ReadLine().Split(" ").ToArray();
        if (cmd[0].ToLower() == "search")
        {
            SearchByWorker(cmd[1]);
        }
        else
        {
            Console.WriteLine("Приключи търсенето.\n");
            break;
        }
    }
}

void FindMostExpensive()
{
    foreach (var kvp in keyValuePairs.Values)
    {
        if (kvp > maxSalary)
        {
            maxSalary = kvp;
        }
    }

    Console.WriteLine($"Най-скъпо платеният работник получава възнаграждение от {maxSalary:F2} лв.");
}

void FindLeastExpensive()
{
    double minSalary = int.MaxValue;

    foreach (var kvp in keyValuePairs.Values)
    {
        if (kvp < minSalary)
        {
            minSalary = kvp;
        }
    }

    Console.WriteLine($"Най-евтино платеният работник получава възнаграждение от {minSalary:F2} лв.");
}

void Average()
{
    double avg = 0;
    int ran = 0;

    foreach (var kvp in keyValuePairs.Values)
    {
        avg += kvp;
        ran++;
    }

    avg /= ran;

    Console.WriteLine($"Средната заплата е {avg:F2} лв.");
}

void Sum()
{
    double sum = 0;

    foreach (var kvp in keyValuePairs.Values)
    {
        sum += kvp;
    }

    Console.WriteLine($"Сумата на заплатите е {sum:F2}");
}

void Sort()
{
    string[] keys = new string[keyValuePairs.Count];
    double[] values = new double[keyValuePairs.Count];
    int index = 0;
    foreach (var kvp in keyValuePairs)
    {
        keys[index] = kvp.Key;
        values[index] = kvp.Value;
        index++;
    }

    for (int i = 0; i < values.Length - 1; i++)
    {
        for (int j = 0; j < values.Length - i - 1; j++)
        {
            if (values[j] > values[j + 1])
            {
                double tempValue = values[j];
                values[j] = values[j + 1];
                values[j + 1] = tempValue;

                string tempKey = keys[j];
                keys[j] = keys[j + 1];
                keys[j + 1] = tempKey;
            }
        }
    }

    for (int i = 0; i < keys.Length; i++)
    {
        sorted.Add(keys[i], values[i]);
    }

    Console.WriteLine("\nСортиран речник:");
}
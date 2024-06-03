Dictionary<string, double> keyValuePairs = new Dictionary<string, double>();
Dictionary<string, double> sorted = new Dictionary<string, double>();

double maxPrice = int.MinValue;

AddProducts();
WaitForCMD();

FindMostExpensive();
FindLeastExpensive();
Average();
Sum();

DisplayOrder();


void AddProducts()
{
    while (true)
    {
        string[] input = Console.ReadLine().Split(" ").ToArray();
        if (input[0].ToLower() == "order")
        {
            break;
        }

        keyValuePairs.Add(input[0], double.Parse(input[1]));
    }
}

void DisplayOrder()
{
    Sort();
    foreach (var kvp in sorted)
    {
        Console.WriteLine(kvp.Key + " " + kvp.Value);
    }
}

void SearchByProductName(string name)
{
    bool found = false;
    foreach (var kvp in keyValuePairs)
    {
        if (kvp.Key.ToLower() == name.ToLower())
        {
            found = true;
            Console.WriteLine($"Има поръчан/а/ {kvp.Key} на цена {kvp.Value} лева.");
        }
    }

    if (!found)
    {
        Console.WriteLine($"Няма поръчан/а/ {name}.");
    }
}

void WaitForCMD()
{
    Console.WriteLine("\nНапишете Search [product], за да търсите продукт по име.\n");

    while (true)
    {
        string[] cmd = Console.ReadLine().Split(" ").ToArray();
        if (cmd[0].ToLower() == "search")
        {
            SearchByProductName(cmd[1]);
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
        if (kvp > maxPrice)
        {
            maxPrice = kvp;
        }
    }

    Console.WriteLine($"Най-скъпият продукт струва {maxPrice:F2} лв.");
}

void FindLeastExpensive()
{
    double minPrice = int.MaxValue;

    foreach (var kvp in keyValuePairs.Values)
    {
        if (kvp < minPrice)
        {
            minPrice = kvp;
        }
    }

    Console.WriteLine($"Най-евтиният продукт струва {minPrice:F2} лв.");
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

    Console.WriteLine($"Средната цена на продуктите е {avg:F2} лв.");
}

void Sum()
{
    double sum = 0;

    foreach (var kvp in keyValuePairs.Values)
    {
        sum += kvp;
    }

    Console.WriteLine($"Сумата на цените е {sum:F2}");
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
Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
Dictionary<string, int> sorted = new Dictionary<string, int>();


int maxAge = int.MinValue;

AddNames();
WaitForCMD();

FindOldest();
FindYoungest();
Average();
Sum();

DisplayAnimals();


void AddNames()
{
    while (true)
    {
        string[] input = Console.ReadLine().Split(" ").ToArray();
        if (input[0].ToLower() == "end")
        {
            break;
        }

        keyValuePairs.Add(input[0], int.Parse(input[1]));
    }
}

void DisplayAnimals()
{
    Sort();
    foreach (var kvp in sorted)
    {
        Console.WriteLine(kvp.Key + " " + kvp.Value);
    }
}

void SearchByName(string name)
{
    bool found = false;
    foreach(var kvp in keyValuePairs)
    {
        if(kvp.Key.ToLower() == name.ToLower())
        {
            found = true;
            Console.WriteLine($"Има животно {kvp.Key} на {kvp.Value} години.");
        }
    }

    if (!found)
    {
        Console.WriteLine($"Няма животно {name}.");
    }
}

void WaitForCMD()
{
    Console.WriteLine("\nНапишете Search [ime], за да търсите по име.\n");

    while (true)
    {
        string[] cmd = Console.ReadLine().Split(" ").ToArray();
        if (cmd[0].ToLower() == "search")
        {
            SearchByName(cmd[1]);
        }
        else
        {
            Console.WriteLine("Приключи търсенето.\n");
            break;
        }
    }
}

void FindOldest()
{
    foreach(var kvp in keyValuePairs.Values)
    {
        if (kvp > maxAge)
        {
            maxAge = kvp;
        }
    }

    Console.WriteLine($"Най-старото животно е на {maxAge} години.");
}

void FindYoungest()
{
    int minAge = int.MaxValue;

    foreach (var kvp in keyValuePairs.Values)
    {
        if (kvp < minAge)
        {
            minAge = kvp;
        }
    }

    Console.WriteLine($"Най-младото животно е на {minAge} години.");
}

void Average()
{
    int avg = 0;
    int ran = 0;

    foreach (var kvp in keyValuePairs.Values)
    {
        avg += kvp;
        ran++;
    }

    avg /= ran;

    Console.WriteLine($"Средната възраст е {avg} години.");
}

void Sum()
{
    int sum = 0;

    foreach (var kvp in keyValuePairs.Values)
    {
        sum += kvp;
    }

    Console.WriteLine("Сумата от всички години е " + sum);
}

void Sort()
{
    string[] keys = new string[keyValuePairs.Count];
    int[] values = new int[keyValuePairs.Count];
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
                int tempValue = values[j];
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
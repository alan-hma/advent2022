// Day 1, Problem 1
//
{
    var lines = File.ReadLines("input/input01.txt");
    var currentCalories = 0;
    var maxCalories = 0;

    foreach (var line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            if (currentCalories > maxCalories)
                maxCalories = currentCalories;
            currentCalories = 0;
            continue;
        }

        currentCalories += int.Parse(line);
    }

    if (currentCalories > maxCalories)
        maxCalories = currentCalories;

    Console.WriteLine($"Maximum elf carries {maxCalories} calories");
}


// Day 1, Problem 2
//
{
    var lines = File.ReadLines("input/input01.txt");
    var currentElf = 0;
    var currentCalories = 0;
    var q = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));

    foreach (var line in lines)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            q.Enqueue(++currentElf, currentCalories);
            currentCalories = 0;
            continue;
        }

        currentCalories += int.Parse(line);
    }

    var sumOfTheTopThree = 0;
    for (var i = 0; i < 3; ++i)
    {
        q.TryDequeue(out var elf, out var calories);
        Console.WriteLine($"Elf #{elf} is packing {calories} calories.");
        sumOfTheTopThree += calories;
    }

    Console.WriteLine($"Maximum 3 elves carry a total of {sumOfTheTopThree} calories");
}
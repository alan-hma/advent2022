﻿// Day 1, Problem 1
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

// Day 2, Problem 1
//
// Rock vs Rock         T "A X", 1 + 3 = 4
// Rock vs Paper        W "A Y", 2 + 6 = 8
// Rock vs Scissors     L "A Z", 3 + 0 = 3
// Paper vs Rock        L "B X", 1 + 0 = 1
// Paper vs Paper       T "B Y", 2 + 3 = 5
// Paper vs Scissors    W "B Z", 3 + 6 = 9
// Scissors vs Rock     W "C X", 1 + 6 = 7
// Scissors vs Paper    L "C Y", 2 + 0 = 2
// Scissors vs Scissors T "C Z", 3 + 3 = 6
{
    var score = 0;
    var d = new Dictionary<string, int>();
    d.Add("A X", 4);
    d.Add("A Y", 8);
    d.Add("A Z", 3);
    d.Add("B X", 1);
    d.Add("B Y", 5);
    d.Add("B Z", 9);
    d.Add("C X", 7);
    d.Add("C Y", 2);
    d.Add("C Z", 6);

    var lines = File.ReadLines("input/input02.txt");

    foreach (var line in lines)
        score += d[line];
    Console.WriteLine($"Your score: {score}");
}

// Day 2, Problem 2
//
// Rock     "A X" L  Scissors 3 + 0 = 3
// Rock     "A Y" T  Rock     1 + 3 = 4
// Rock     "A Z" W  Paper    2 + 6 = 8
// Paper    "B X" L  Rock     1 + 0 = 1
// Paper    "B Y" T  Paper    2 + 3 = 5
// Paper    "B Z" W  Scissors 3 + 6 = 9
// Scissors "C X" L  Paper    2 + 0 = 2
// Scissors "C Y" T  Scissors 3 + 3 = 6
// Scissors "C Z" W  Rock     1 + 6 = 7
{
    var score = 0;
    var d = new Dictionary<string, int>();
    d.Add("A X", 3);
    d.Add("A Y", 4);
    d.Add("A Z", 8);
    d.Add("B X", 1);
    d.Add("B Y", 5);
    d.Add("B Z", 9);
    d.Add("C X", 2);
    d.Add("C Y", 6);
    d.Add("C Z", 7);

    var lines = File.ReadLines("input/input02.txt");

    foreach (var line in lines)
        score += d[line];
    Console.WriteLine($"Your score: {score}");
}

// Day 3, Problem 1
//
// 0x7B == the letter past z.
// 
{
    var priorities = new int[0x7B];
    var i = 0;
    for (var letter = 'a'; letter < 0x7B; ++letter)
    {
        priorities[letter] = i + 1;
        priorities[(char)(letter - 0x20)] = i++ + 27;
    }

    var lines = File.ReadLines("input/input03.txt");
    var pSum = 0;
    foreach (var line in lines)
    {
        var pivot = line.Count() / 2;
        var first = new HashSet<char>(line.Substring(0, pivot).ToCharArray());
        var second = new HashSet<char>(line.Substring(pivot).ToCharArray());
        pSum += priorities[first.Intersect(second).First()];
    }

    Console.WriteLine($"Priority sum is {pSum}");
}

// Day 3, Problem 2
// 
{
    var priorities = new int[0x7B];
    var i = 0;
    for (var letter = 'a'; letter < 0x7B; ++letter)
    {
        priorities[letter] = i + 1;
        priorities[(char)(letter - 0x20)] = i++ + 27;
    }

    var lines = File.ReadLines("input/input03.txt").ToList();
    var pSum = 0;

    for (var j = 0; j < lines.Count();)
    {
        var ruck1 = new HashSet<char>(lines[j++].ToCharArray());
        var ruck2 = new HashSet<char>(lines[j++].ToCharArray());
        var ruck3 = new HashSet<char>(lines[j++].ToCharArray());

        pSum += priorities[ruck1.Intersect(ruck2.Intersect(ruck3)).First()];
    }

    Console.WriteLine($"Priority sum is {pSum}");
}
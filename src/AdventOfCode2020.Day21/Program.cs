using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day21;

var lines = await File.ReadAllLinesAsync("input.txt");

var foods = lines
    .Select(FoodUtil.Parse)
    .ToArray();

var options = new Dictionary<string, HashSet<string>>();

foreach (var food in foods)
{
    foreach (var allergen in food.allergens)
    {
        if (options.TryGetValue(allergen, out var ingredients))
        {
            options[allergen].IntersectWith(food.ingredients);
        }
        else
        {
            options[allergen] = new(food.ingredients);
        }
    }
}

var possibleIngredients = options.Values.Aggregate(new HashSet<string>(), (a, b) => { a.UnionWith(b); return a; });

var solution1 = foods.Sum(f => f.ingredients.Count(i => !possibleIngredients.Contains(i)));

Console.WriteLine($"Day 21 - Puzzle 1: {solution1}");

var allergens = new Dictionary<string, string>();

while (options.Any())
{
    var singleOption = options.First(o => o.Value.Count == 1);

    var ingredient = singleOption.Value.Single();

    allergens[singleOption.Key] = ingredient;

    options.Remove(singleOption.Key);

    foreach (var option in options)
    {
        option.Value.Remove(ingredient);
    }
}

var solution2 = string.Join(",", allergens.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value));

Console.WriteLine($"Day 21 - Puzzle 2: {solution2}");

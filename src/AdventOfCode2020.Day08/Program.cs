using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using AdventOfCode2020.Day08;

var lines = await File.ReadAllLinesAsync("input.txt");

var instructions = lines.Select(OpcodesUtil.ParseInstruction).ToArray();

var visitedPcs = new HashSet<int>();

var accumulator = 0;

var pc = 0;

while (!visitedPcs.Contains(pc))
{
    visitedPcs.Add(pc);

    instructions[pc].Execute(ref pc, ref accumulator);
}

Console.WriteLine($"Day 8 - Puzzle 1: {accumulator}");


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

for (var i = 0; i < instructions.Length; i++)
{
    if (instructions[i].opcode == Opcodes.Acc)
    {
        // only change Jmp and Nop opcodes

        continue;
    }

    var variant = instructions.ToArray(); // create a copy

    // flip opcode

    variant[i].opcode =
        variant[i].opcode == Opcodes.Jmp ?
            Opcodes.Nop :
            Opcodes.Jmp;

    // run variant

    accumulator = 0;

    pc = 0;

    visitedPcs.Clear();

    while (!visitedPcs.Contains(pc) &&
        pc != variant.Length)
    {
        visitedPcs.Add(pc);

        variant[pc].Execute(ref pc, ref accumulator);
    }

    if (pc == variant.Length)
    {
        // completed successfulyy

        break;
    }
}

Console.WriteLine($"Day 8 - Puzzle 2: {accumulator}");

using System;
using System.IO;

using AdventOfCode2020.Day25;

var lines = await File.ReadAllLinesAsync("input.txt");

var cardPublicKey = long.Parse(lines[0]);

var doorPublicKey = long.Parse(lines[1]);

var (cardLoopSize, doorLoopSize) = EncryptionUtil.GetLoopSize(cardPublicKey, doorPublicKey, 7);

var solution1 = EncryptionUtil.GetEncryptionKey(doorPublicKey, cardLoopSize);

Console.WriteLine($"Day 25 - Puzzle 1: {solution1}");

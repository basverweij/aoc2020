using System;

namespace AdventOfCode2020.Day08
{
    public static class OpcodesUtil
    {
        public static (Opcodes opcode, int argument) ParseInstruction(
            string line)
        {
            var parts = line.Split(' ');

            var opcode = Enum.Parse<Opcodes>(parts[0], true);

            var argument = int.Parse(parts[1]);

            return (opcode, argument);
        }

        public static void Execute(
            this (Opcodes opcode, int argument) @this,
            ref int pc,
            ref int accumulator)
        {
            switch (@this.opcode)
            {
                case Opcodes.Acc:
                    accumulator += @this.argument;

                    pc++;

                    break;

                case Opcodes.Jmp:
                    pc += @this.argument;

                    break;

                case Opcodes.Nop:
                    pc++;

                    break;
            }
        }
    }

    public enum Opcodes
    {
        Acc,
        Jmp,
        Nop,
    }
}

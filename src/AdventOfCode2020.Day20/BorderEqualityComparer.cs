using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2020.Day20
{
    internal class BorderEqualityComparer :
        IEqualityComparer<(int border, int id)>
    {
        public bool Equals((int border, int id) x, (int border, int id) y) => x.border == y.border;

        public int GetHashCode([DisallowNull] (int border, int id) obj) => obj.border;
    }

}

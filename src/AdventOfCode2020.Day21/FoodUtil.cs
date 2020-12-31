namespace AdventOfCode2020.Day21
{
    public static class FoodUtil
    {
        public static (string[] ingredients, string[] allergens) Parse(
            string s)
        {
            var ss = s[0..^1].Split(" (contains ");

            var ingredients = ss[0].Split(' ');

            var allergens = ss[1].Split(", ");

            return (ingredients, allergens);
        }
    }
}

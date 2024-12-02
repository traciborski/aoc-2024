
var lines = File.ReadAllLines("input");

var safe = lines.Select(x => x.Split(" ").Select(y => int.Parse(y)).ToArray()).Where(x => Safe(x)).Count();

bool Safe(int[] xs)
{
    sbyte dir = 0;
    for (int i = 1; i < xs.Length; i++)
    {
        var diff = Math.Abs(xs[i] - xs[i - 1]);
        if (diff < 1 || diff > 3)
            return false;

        if (xs[i] > xs[i - 1]) // increasing
        {
            if (dir < 0)
                return false;
            dir = 1;
        }
        else if (xs[i] < xs[i - 1])
        {
            if (dir > 0)
                return false;
            dir = -1;
        }
    }
    return true;
}

Console.WriteLine(safe); // 799 too high
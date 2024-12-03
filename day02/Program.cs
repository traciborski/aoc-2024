
var lines = File.ReadAllLines("input");

var safe = lines.Select(x => x.Split(" ").Select(y => int.Parse(y)).ToArray()).Where(x => Safe(x, 1)).Count();

bool Safe(int[] xs, int margin)
{
    sbyte dir = 0;

    for (int i = 1; i < xs.Length; i++)
    {
        var diff = Math.Abs(xs[i] - xs[i - 1]);
        if (diff < 1 || diff > 3)
        {
            margin--;
            if (margin < 0)
            {
                return false;
            }
            else
            {
                i++;
                continue;
            }
        }

        if (xs[i] > xs[i - 1]) // increasing
        {
            if (dir < 0)
            {
                margin--;
                i++;
                if (margin < 0)
                    return false;
                else
                {
                    i++;
                    continue;
                }
            }
            dir = 1;
        }
        else if (xs[i] < xs[i - 1])
        {
            if (dir > 0)
            {
                margin--;
                i++;
                if (margin < 0)
                    return false;
                else
                {
                    i++;
                    continue;
                }
            }
            dir = -1;
        }
    }
    return true;
}

Console.WriteLine(safe); 
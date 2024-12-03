using System.Text.RegularExpressions;

var text = File.ReadAllText("input");

var dos = FindIndices(text, "do()");
var donts = FindIndices(text, "don't()");

var regex = @"mul\((\d+),(\d+)\)";

var matches = Regex.Matches(text, regex);

var result = 0;
foreach (Match match in matches)
{
    var enabled = Enabled(match.Index);
    if (enabled)
        result += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
}

bool Enabled(int index)
{
    var dont = donts.Where(x => x < index).Max(x => (int?)x);
    if (dont == null)
        return true;
    var du = dos.Where(x => x < index).Max(x => (int?)x);
    if (du == null)
        return true;

    return du > dont;
}

Console.WriteLine(result);

IEnumerable<int> FindIndices(string input, string pattern)
{
    var start = 0;
    int index;
    while ((index = input.IndexOf(pattern, start)) != -1)
    {
        yield return index;
        start = index + pattern.Length;
    }
}
var lines = File.ReadAllLines("input");
char[][] board = lines.Select(x => x.ToCharArray()).ToArray();

List<((int, int), (int, int))> pairs = FindAllPairs(board);

var antinodes = new HashSet<(int, int)>();
foreach (var pair in pairs)
{
    foreach (var a in Antinodes(pair))
        antinodes.Add(a);
}

Console.WriteLine(antinodes.Count);

IEnumerable<(int, int)> Antinodes(((int, int), (int, int)) pair)
{
    var diff = (pair.Item2.Item1 - pair.Item1.Item1, pair.Item2.Item2 - pair.Item1.Item2);

    var an1 = (pair.Item1.Item1 - diff.Item1, pair.Item1.Item2 - diff.Item2);
    if (InBoard(an1))
        yield return an1;

    var an2 = (pair.Item2.Item1 + diff.Item1, pair.Item2.Item2 + diff.Item2);
    if (InBoard(an2))
        yield return an2;
}

bool InBoard((int, int) p)
{
    return p.Item1 >= 0 && p.Item2 >= 0 && p.Item1 < board.Length && p.Item2 < board.Length;
}

List<((int, int), (int, int))> FindAllPairs(char[][] board)
{
    List<((int, int), (int, int))> pairs = new();

    for (int i1 = 0; i1 < board.Length; i1++)
        for (int j1 = 0; j1 < board[i1].Length; j1++)
            for (int i2 = i1; i2 < board.Length; i2++)
                for (int j2 = (i2 == i1 ? j1 + 1 : 0); j2 < board[i2].Length; j2++)
                    if (board[i1][j1] == board[i2][j2] && board[i1][j1] != '.')
                        pairs.Add(((i1, j1), (i2, j2)));

    return pairs;
}
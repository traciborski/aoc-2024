var lines = File.ReadAllLines("input");

char[][] board = lines.Select(x => x.ToCharArray()).ToArray();

var current = FindStart();
var dir = new P(0, -1);

var visited = new HashSet<P> { current };

while (true)
{
    visited.Add(current);
    
    var next = new P(current.X + dir.X, current.Y + dir.Y);

    if (next.X < 0 || next.Y < 0 || next.X >= board.Length || next.Y >= board.Length)
    {
        Console.WriteLine(visited.Count);
        return;
    }

    if (board[next.Y][next.X] == '#')
        dir = TurnRight(dir);
    
    current = new P(current.X + dir.X, current.Y + dir.Y);
}

P TurnRight(P dir)
    => dir switch
    {
        (-1, 0) => new(0, -1),
        (0, -1) => new(1, 0),
        (1, 0) => new(0, 1),
        (0, 1) => new(-1, 0),
        _ => default
    };

P FindStart()
{
    for (int i = 0; i < board.Length; i++)
        for (int j = 0; j < board[i].Length; j++)
            if (board[i][j] == '^')
                return new(j, i);
    return default;
}

record struct P(int X, int Y);

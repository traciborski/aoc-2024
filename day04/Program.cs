
var lines = File.ReadAllLines("input");

char[][] board = lines.Select(x => x.ToCharArray()).ToArray();

int count = 0;

var pattern = "XMAS".ToCharArray();

for (int i = 0; i < board.Length; i++)
{
    for (int j = 0; j < board[i].Length; j++)
    {
        Check(i, j, 0, -1, 0);
        Check(i, j, 0, -1, -1);
        Check(i, j, 0, 0, -1);
        Check(i, j, 0, 1, -1);
        Check(i, j, 0, 1, 0);
        Check(i, j, 0, 1, 1);
        Check(i, j, 0, 0, 1);
        Check(i, j, 0, -1, 1);
    }
}

void Check(int i, int j, int letter, int idir, int jdir)
{
    if (i < 0 || i >= board.Length)
        return;

    if (j < 0 || j >= board.Length)
        return;

    if (board[i][j] != pattern[letter])
        return;

    if (letter == pattern.Length - 1)
    {
        count++;
        return;
    }

    Check(i + idir, j + jdir, letter + 1, idir, jdir);
}

Console.WriteLine(count);
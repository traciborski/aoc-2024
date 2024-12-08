var lines = File.ReadAllLines("input");

char[][] board = lines.Select(x => x.ToCharArray()).ToArray();

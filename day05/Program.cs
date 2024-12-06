var lines = File.ReadAllLines("input0");

char[][] board = lines.Select(x => x.ToCharArray()).ToArray();

var count = 0;

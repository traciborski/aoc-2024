var lines = File.ReadAllLines("input");

var lists = lines.Select(x => x.Split("   ").Select(y => int.Parse(y)).ToArray());
var list1 = lists.Select(x => x[0]).Order().ToArray();
var list2 = lists.Select(x => x[1]).Order().ToArray();

var sum = list1.Zip(list2).Select(x=> Math.Abs(x.First - x.Second)).Sum();
Console.WriteLine(sum); // 1258579

var score = 0;
for (int i = 0; i < list1.Length; i++)
    score += list1[i] * list2.Count(x => x == list1[i]);
Console.WriteLine(score); // 23981443
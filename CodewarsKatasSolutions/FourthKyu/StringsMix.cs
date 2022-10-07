namespace FourthKyu;

// https://www.codewars.com/kata/5629db57620258aa9d000014

public static class StringsMix
{
    public static string Mix(string s1, string s2)
    {
        var ret = string.Empty;
        s1 = ExtractLowerLetters(s1);
        s2 = ExtractLowerLetters(s2);

        var g1 = GroupAndOrderString(s1);
        var g2 = GroupAndOrderString(s2);

        var maxOccur = 0;
        if (!g1.Any() && !g2.Any()) return string.Empty;
        if (g1.Any() && g2.Any()) maxOccur = Math.Max(g1.First().Count(), g2.First().Count());
        if (!g1.Any()) maxOccur = g2.First().Count();
        if (!g2.Any()) maxOccur = g1.First().Count();

        while (maxOccur > 1)
        {
            var (g1Temp, g2Temp)
                = FilterGroupsByOccurence(g1, g2, maxOccur);

            string tempStr;

            if (!g1Temp.Any() && !g2Temp.Any())
            {
                maxOccur--;
                continue;
            }

            if (g1Temp.Count > g2Temp.Count)
                (tempStr, g1, g2) = HandleGroups("1", g1Temp, g2Temp, g1, g2);
            else
                (tempStr, g2, g1) = HandleGroups("2", g2Temp, g1Temp, g2, g1);

            ret += tempStr;

            maxOccur--;
        }

        return ret.Remove(ret.Length - 1, 1);
    }

    private static (string, List<IGrouping<char, char>>, List<IGrouping<char, char>>) HandleGroups(string prefix,
        List<IGrouping<char, char>> grp1,
        List<IGrouping<char, char>> grp2, List<IGrouping<char, char>> primaryGroup,
        List<IGrouping<char, char>> otherGroup)
    {
        var retEqTemp = new List<string>();
        var retTemp = new List<(string, string)>();
        var str = string.Empty;

        foreach (var g in grp1)
            if (grp2.Any(x => x.Key == g.Key))
            {
                retEqTemp.Add(new string(g.Key, g.Count()));
                grp2.RemoveAll(x => x.Key == g.Key);
            }
            else
            {
                retTemp.Add((prefix, new string(g.Key, g.Count())));
                otherGroup.RemoveAll(x => x.Key == g.Key);
            }

        foreach (var g in grp2)
        {
            retTemp.Add((prefix == "1" ? "2" : "1", new string(g.Key, g.Count())));
            primaryGroup.RemoveAll(x => x.Key == g.Key);
        }

        retTemp = retTemp.OrderBy(p => p.Item1).ThenBy(p => p.Item2).ToList();
        retEqTemp = retEqTemp.OrderBy(t => t).ToList();

        str = retTemp.Aggregate(str, (current, pair) => current + $"{pair.Item1}:{pair.Item2}/");
        str = retEqTemp.Aggregate(str, (current, c) => current + $"=:{c}/");

        return (str, primaryGroup, otherGroup);
    }

    private static string ExtractLowerLetters(string s)
    {
        return new string(s.Where(c => char.IsLetter(c) && char.IsLower(c)).ToArray());
    }

    private static List<IGrouping<char, char>> GroupAndOrderString(string str)
    {
        return str.GroupBy(c => c)
            .Where(g => g.Count() > 1)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .ToList();
    }

    private static (List<IGrouping<char, char>>, List<IGrouping<char, char>>) FilterGroupsByOccurence(
        IEnumerable<IGrouping<char, char>> firstGroup, IEnumerable<IGrouping<char, char>> secondGroup,
        int occurence)
    {
        return (firstGroup.Where(g => g.Count() == occurence).ToList(),
            secondGroup.Where(g => g.Count() == occurence).ToList());
    }
}
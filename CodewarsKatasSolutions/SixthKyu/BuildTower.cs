namespace SixthKyu;

// https://www.codewars.com/kata/576757b1df89ecf5bd00073b

public class BuildTower
{
    public static string[] TowerBuilder(int nFloors)
    {
        var ret = new List<string>();
        var nbStars = nFloors * 2 - 1;
        var nbSpaces = 0;

        for (var i = 0; i < nFloors; i++)
        {
            ret.Insert(0, new string(' ', nbSpaces) + new string('*', nbStars) + new string(' ', nbSpaces));
            nbStars -= 2;
            nbSpaces += 1;
        }

        return ret.ToArray();
    }
}
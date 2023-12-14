using System.Collections;

namespace MatchingAlgorithms;

/*
 This class contains a really simple algorithm that selects 3 random apps based on if they have any matching words
 It does not take any weight of amounts matching into account
*/
public class RandomMatches
{
    private Compare _compare = new Compare();
    public string[] RandomMatch(List<Vector> app, List<Vector> installed)
    {
        var matchingWords = _compare.CompareApps(installed, app);

        var apps = new List<string>();
        foreach (var a in app)
        {
            if (matchingWords.Exists(word => a.Keywords.Contains(word)))
            {
                apps.Add(a.Name);
            }
        }

        var randomNums = GenerateNumbers(apps);


        return new []{apps[randomNums[0]], apps[randomNums[1]], apps[randomNums[2]]};
    }
    
    private int[] GenerateNumbers(ICollection arr)
    {        
        Random rand = new Random();
        var randomNums = new int[3];

        for (int i = 0; i < 3; i++)
        {
            var j = rand.Next(0, arr.Count);
            while(randomNums.Contains(j))
            {
                j = rand.Next(0, arr.Count);
            }

            randomNums[i] = j;
        }

        return randomNums;
    }
}
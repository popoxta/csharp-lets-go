using System.Text.RegularExpressions;

namespace CSharpLetsGo.PettingZoo;

public class Zoo
{
    public required Animal[] Animals { get; init; }
    public SchoolGroup[]? VisitingGroups { get; set; }

    private Animal[] GetShuffledAnimals()
    {
        return Animals.OrderBy(_ => Guid.NewGuid()).ToArray();
    }

    public void AssignAnimalsToGroups()
    {
        if (VisitingGroups == null) throw new InvalidOperationException("VisitingGroups is null");
        var animals = GetShuffledAnimals();
        var animalsPerGroup = Animals.Length / VisitingGroups.Length;

        foreach (var (group, i) in VisitingGroups.Select((group, i) => (group, i)))
        {
            var animalStartIndex = i * 3;
            var animalsForGroup = animals[animalStartIndex..animalsPerGroup].ToArray();
            group.AssignedAnimals = animalsForGroup;
        }
    }
}
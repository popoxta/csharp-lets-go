namespace CSharpLetsGo.PettingZoo;

public class Zoo
{
    public required Animal[] Animals { get; set; }

    public Animal[] GetShuffledAnimals()
    {
        return Animals.OrderBy(_ => Guid.NewGuid()).ToArray();
    }
}
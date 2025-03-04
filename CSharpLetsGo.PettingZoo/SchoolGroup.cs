namespace CSharpLetsGo.PettingZoo;

public class SchoolGroup
{
    public required string GroupName { get; init; }
    public Animal[]? AssignedAnimals { get; set; }

    public void WriteAssignedAnimals()
    {
        if (AssignedAnimals == null) throw new InvalidOperationException("No animals are assigned!");

        Console.WriteLine($"\n{GroupName} will be visiting the following animals:");
        Console.WriteLine($"{string.Join(", ", AssignedAnimals.Select(animal => animal.AnimalType))}");
    }
}
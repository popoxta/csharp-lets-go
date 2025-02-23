namespace PetShelter;

public enum Species
{
    Cat,
    Dog
}

public class Pet
{
    public Guid Id { get; } = Guid.NewGuid();
    public required Species Species { get; init; }
    public required int Age { get; set; }
    public required string Name { get; init; }
    public required string PhysicalCondition { get; init; }
    public string? Personality { get; init; }
}
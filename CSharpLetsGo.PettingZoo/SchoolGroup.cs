namespace CSharpLetsGo.PettingZoo;

public class SchoolGroup
{
    public required string GroupName { get; init; }
    public Animal[]? AssignedAnimals { get; set; }
}
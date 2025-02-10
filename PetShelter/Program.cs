// See https://aka.ms/new-console-template for more information

using PetShelter;

Console.WriteLine("Hello, World!");

var pet = new Pet
{
    Age = 12,
    PhysicalCondition = "Perfect!",
    Species = Species.Cat
};

Console.WriteLine(pet.Id);
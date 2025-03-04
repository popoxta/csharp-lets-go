using CSharpLetsGo.PettingZoo;

string[] animalTypes =
[
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
];

var animals = animalTypes.Select(animal => new Animal
{
    AnimalType = animal,
}).ToArray();

var zoo = new Zoo()
{
    Animals = animals,
};

var visitingGroups = new SchoolGroup[5].Select((_, i) => new SchoolGroup
{
    GroupName = $"School group {i + 1}"
}).ToArray();
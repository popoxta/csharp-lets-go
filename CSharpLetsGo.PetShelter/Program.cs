using PetShelter;

const int maxPets = 8;


Pet[] cats = [new()
    {
        Species = Species.Cat,
        Age = 5,
        PhysicalCondition = "Good"
    },
    new()
    {
        Species = Species.Cat,
        Age = 8,
        PhysicalCondition = "Could be better"
    },
    new()
    {
        Species = Species.Cat,
        Age = 2,
        PhysicalCondition = "Great"
    },
];


Pet[] dogs = [new()
    {
        Species = Species.Dog,
        Age = 3,
        PhysicalCondition = "Very good"
    },
    new()
    {
        Species = Species.Dog,
        Age = 7,
        PhysicalCondition = "Small"
    },
    new()
    {
        Species = Species.Dog,
        Age = 10,
        PhysicalCondition = "Wrinkly"
    },
];

var menuSelection = MenuOptions.Default;

do
{
    Console.WriteLine(
        """"
        
        """"
        );
    Console.ReadLine();

} while(false);

internal enum MenuOptions
{
    Default,
    Exit,
    List,
    Add,
    EditAge,
    EditPersonality,
    DisplayCatsWithCharacteristic,
    DisplayDogsWithCharacteristic
}
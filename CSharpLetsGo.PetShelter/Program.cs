using CSharpLetsGo.Shared;
using PetShelter;

const int maxPets = 8;

const string optionsPrompt =
    """
    Welcome to PetFriends!
    Your menu options are:
    1. Exit
    2. List all pets
    3. Add pet
    4. Edit pet age
    5. Edit pet personality
    6. Display cats with specific characteristics
    7. Display dogs with specific characteristics
    
    Please select an option.
    """;


Pet[] cats =
[
    new()
    {
        Species = Species.Cat,
        Name = "Josuke",
        Age = 5,
        PhysicalCondition = "Good"
    },
    new()
    {
        Species = Species.Cat,
        Name = "Johnny",
        Age = 8,
        PhysicalCondition = "Could be better"
    },
    new()
    {
        Species = Species.Cat,
        Name = "Joseph",
        Age = 2,
        PhysicalCondition = "Great"
    },
];


Pet[] dogs =
[
    new()
    {
        Species = Species.Dog,
        Name = "Lucy",
        Age = 3,
        PhysicalCondition = "Very good"
    },
    new()
    {
        Species = Species.Dog,
        Name = "Doppio",
        Age = 7,
        PhysicalCondition = "Small"
    },
    new()
    {
        Species = Species.Dog,
        Name = "Emporio",
        Age = 10,
        PhysicalCondition = "Wrinkly"
    },
];

var menuSelection = MenuOptions.Default;

do
{
    menuSelection = (MenuOptions)Prompt.GetInt(optionsPrompt, min: 1, max: Enum.GetValues(typeof(MenuOptions)).Length);

    switch (menuSelection)
    {
        case MenuOptions.Exit:
            Console.WriteLine("Goodbye!");
            return;
        case MenuOptions.List:
            Console.WriteLine("All pets:");
            Console.WriteLine("Species\t\tName\t\tAge");
            foreach (var pet in cats.Concat(dogs).ToArray())
                Console.WriteLine($"{pet.Species}\t\t{pet.Name}\t\t{pet.Age}");
            break;
        case MenuOptions.Add:
            break;
        case MenuOptions.EditAge:
            break;
        case MenuOptions.EditPersonality:
            break;
        case MenuOptions.DisplayCatsWithCharacteristic:
            break;
        case MenuOptions.DisplayDogsWithCharacteristic:
            break;
        case MenuOptions.Default:
            break;
    }

    ;
    Prompt.PressEnterToContinue();
} while (menuSelection != MenuOptions.Exit);

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
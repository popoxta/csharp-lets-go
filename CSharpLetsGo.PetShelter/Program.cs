using CSharpLetsGo.Shared;
using PetShelter;

const string optionsPrompt =
    """
    Welcome to PetFriends!
    Your menu options are:
    1. Exit
    2. List all pets
    3. Add pet
    4. Edit pet age
    5. Edit pet personality
    6. Display cats
    7. Display dogs

    Please select an option.
    """;

// todo merge cats and dogs
// todo change to list
List<Pet> pets =
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

            ListAllPets(pets, (pet, _) => Console.WriteLine($"{pet.Species}\t\t{pet.Name}\t\t{pet.Age}"));

            break;

        case MenuOptions.Add:
            Console.WriteLine("Please enter the new pet details.");

            var newPet = new Pet
            {
                Species = Prompt.GetInt("Species: \n1. Cat\n2. Dog") == 1 ? Species.Cat : Species.Dog,
                Age = Prompt.GetInt("Age: "),
                Name = Prompt.GetString("Name: "),
                PhysicalCondition = Prompt.GetString("Physical condition: "),
                Personality =
                    Prompt.YesOrNo("Would you like to add a personality?") ? Prompt.GetString("Personality: ") : null
            };

            pets.Add(newPet);
            break;

        case MenuOptions.EditAge:
        {
            Console.WriteLine("What pet would you like to change the age for?");
            ListAllPets(pets, (pet, i) => Console.WriteLine($"{i}. {pet.Species} {pet.Name} - {pet.Age} years"));

            var petToEdit = pets[Prompt.GetInt(max: pets.Count - 1, min: 0)];
            petToEdit.Age = Prompt.GetInt($"Please enter a new age for {petToEdit.Name}",
                max: pets.Count - 1, min: 0);
            Console.WriteLine($"Thanks! {petToEdit.Name}'s age has been updated to {petToEdit.Age}");
            break;
        }

        case MenuOptions.EditPersonality:
        {
            Console.WriteLine("What pet would you like to change the personality for?");
            ListAllPets(pets,
                (pet, i) => Console.WriteLine(
                    $"{i}. {pet.Species} {pet.Name} - {pet.Personality ?? "No personality set"}"));

            var petToEdit = pets[Prompt.GetInt(max: pets.Count - 1, min: 0)];
            petToEdit.Personality = Prompt.GetString($"Please enter a new personality for {petToEdit.Name}");
            Console.WriteLine($"Thanks! {petToEdit.Name}'s personality has been updated to {petToEdit.Personality}");
            break;
        }

        case MenuOptions.DisplayCats:
            break;

        case MenuOptions.DisplayDogs:
            break;

        case MenuOptions.Default:
            break;
    }

    Prompt.PressEnterToContinue();
} while (menuSelection != MenuOptions.Exit);

return;


static void ListAllPets(List<Pet> pets, Action<Pet, int> callback)
{
    foreach (var (pet, i) in pets.Select((value, i) => (value, i)))
        callback(pet, i);
}


internal enum MenuOptions
{
    Default,
    Exit,
    List,
    Add,
    EditAge,
    EditPersonality,
    DisplayCats,
    DisplayDogs
}
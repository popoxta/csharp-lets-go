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
    8. Find pet by personality
    9. Find pet by condition

    Please select an option.
    """;

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
            break;

        case MenuOptions.List:
            Console.WriteLine("All pets:");

            ProcessAllPets(pets, (pet, _) =>
            {
                pet.LogPetInfo();
                Console.WriteLine();
            });

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

            Console.WriteLine($"New pet {newPet.Name} has been added!");

            break;

        case MenuOptions.EditAge:
        {
            Console.WriteLine("What pet would you like to change the age for?");
            ProcessAllPets(pets, (pet, i) => Console.WriteLine($"{i}. {pet.Species} {pet.Name} - {pet.Age} years"));

            var petToEdit = pets[Prompt.GetInt(max: pets.Count - 1, min: 0)];
            petToEdit.Age = Prompt.GetInt($"Please enter a new age for {petToEdit.Name}",
                max: pets.Count - 1, min: 0);
            Console.WriteLine($"Thanks! {petToEdit.Name}'s age has been updated to {petToEdit.Age}");
            break;
        }

        case MenuOptions.EditPersonality:
        {
            Console.WriteLine("What pet would you like to change the personality for?");
            ProcessAllPets(pets,
                (pet, i) => Console.WriteLine(
                    $"{i}. {pet.Species} {pet.Name} - {pet.Personality ?? "No personality set"}"));

            var petToEdit = pets[Prompt.GetInt(max: pets.Count - 1, min: 0)];
            petToEdit.Personality = Prompt.GetString($"Please enter a new personality for {petToEdit.Name}");
            Console.WriteLine($"Thanks! {petToEdit.Name}'s personality has been updated to {petToEdit.Personality}");
            break;
        }

        case MenuOptions.DisplayCats:
            Console.WriteLine("All cats:");
            ProcessAllPets(pets, (pet, _) =>
            {
                if (pet.Species == Species.Cat) Console.WriteLine($"{pet.Name}");
            });
            break;

        case MenuOptions.DisplayDogs:
            Console.WriteLine("All dogs:");
            ProcessAllPets(pets, (pet, _) =>
            {
                if (pet.Species == Species.Dog) Console.WriteLine($"{pet.Name}");
            });
            break;

        case MenuOptions.FindByPersonality:
            var personality = Prompt.GetString("Please enter a personality to search for");

            var petsWithPersonalityMatched = pets.Where(pet =>
                pet.Personality != null &&
                pet.Personality.Contains(personality, StringComparison.CurrentCultureIgnoreCase)).ToArray();

            if (petsWithPersonalityMatched.Length > 0)
            {
                Console.WriteLine(
                    $"Found {petsWithPersonalityMatched.Length} pets with personality matching {personality}:");
                foreach (var pet in petsWithPersonalityMatched)
                {
                    pet.LogPetInfo();
                    Console.WriteLine();
                }
            }
            else Console.WriteLine($"Could not find any pets with personality matching {personality}!");

            break;
        case MenuOptions.FindByCondition:
            var condition = Prompt.GetString("Please enter a personality to search for");

            var petsWithConditionMatched = pets.Where(pet =>
                pet.PhysicalCondition.Contains(condition, StringComparison.CurrentCultureIgnoreCase)).ToArray();

            if (petsWithConditionMatched.Length > 0)
            {
                Console.WriteLine($"Found {petsWithConditionMatched.Length} pets with condition matching {condition}:");
                foreach (var pet in petsWithConditionMatched)
                {
                    pet.LogPetInfo();
                    Console.WriteLine();
                }
            }
            else Console.WriteLine($"Could not find any pets with condition matching {condition}!");

            break;
        case MenuOptions.Default:
        default:
            break;
    }

    Prompt.PressEnterToContinue();
} while (menuSelection != MenuOptions.Exit);

return;


static void ProcessAllPets(List<Pet> pets, Action<Pet, int> callback)
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
    DisplayDogs,
    FindByPersonality,
    FindByCondition
}
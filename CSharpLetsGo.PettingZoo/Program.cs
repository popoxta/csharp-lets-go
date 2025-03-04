﻿
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


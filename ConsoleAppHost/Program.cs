// See https://aka.ms/new-console-template for more information

using Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Services;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IDiamondService, DiamondService>()
    .BuildServiceProvider();

var diamondService = serviceProvider.GetService<IDiamondService>()!;

while (true)
{
    Console.WriteLine("Please input a character to be used to build a diamond:");

    if (char.TryParse(Console.ReadLine(), out var middleCharacter))
    {
        Console.WriteLine(diamondService.Create(middleCharacter));
    }
}



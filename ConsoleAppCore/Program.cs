if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
{
    Console.Error.WriteLine("User shall send atleast one argument");
    return 1;
}

Console.WriteLine(Greetings.Greeting.Greet(args[0]));
return 0;

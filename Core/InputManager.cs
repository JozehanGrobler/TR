namespace TR;

static class InputManager
{
    public static int GetValidIntInput(string? message = "Please enter a valid non decimal input")
    {
        while (true)
        {
            Console.WriteLine(message);

            var input = Console.ReadLine();
            if (int.TryParse(input, out int validInput))
            {
                return validInput;
            }
            Console.WriteLine("User Input invalid");
            Console.WriteLine("Input needs to be a valid non decimal value");
        }
    }
    
    public static T GetValidEnumInput<T>(
        string? message = "Please enter a value.")
        where T : struct, Enum 
    {
        var options = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        var stringOptions = options
            .Select(o => o.ToString().ToUpper())
            .ToList();
        while (true)
        {
            Console.WriteLine(message);

            var input = Console.ReadLine();
            var enumInput = input?.ToUpper() switch
            {
                "N" => "North",
                "E" => "East",
                "S" => "South",
                "W" => "West",
                _ => input,
            };
            if (stringOptions.Contains(enumInput?.ToUpper() ?? "") && Enum.TryParse<T>(enumInput, out T actualEnum))
            {
                return actualEnum;
            }
            Console.Clear();
            Console.WriteLine("User Input invalid");
            Console.WriteLine("Please use one of the following options:");
            Console.WriteLine("North or N or n");
            Console.WriteLine("East or E  or e");
            Console.WriteLine("South or S or s");
            Console.WriteLine("West or W or w");
        }
    }
}
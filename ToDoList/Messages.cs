namespace ToDoList;
public static  class Messages
{//Different errormessages

    //SuccessMessage
    public static void Success(string message)
    {
        ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("message");
        ResetColor();
    }
    //Error messages
    public static void NotInList()
    {
        ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("There is no such id in your list");
        Console.WriteLine("The item could not be edited");
        ResetColor();
    }
    public static void NotInMenuList()
    {
        ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have to choose a number from the list");
        ResetColor();
    }
    public static void NotANumber()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("You have to write a number from the list");
        ResetColor();
    }
    public static void SomethingWentWrong()
    {
        ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Something went wrong");
        ResetColor();
    }
    public static void ProjectIsNotEmpty()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("You have to remove the tasks before you remove the project.");
        ResetColor();
    }
}

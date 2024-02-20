namespace ToDoList;
public static  class Messages
{//Different messages

    //SuccessMessage
    public static void Success(string message)
    {
        ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        ResetColor();
    }
    //Error messages
    public static void NotInList()
    {
        ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("There is no such id in your list");
        ResetColor();
    }
    public static void NotInMenuList()
    {
        ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have to choose a number from the menu");
        ResetColor();
    }
    public static void NotANumber()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("You have to write a integer");
        ResetColor();
    }
    public static void NotADate()
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine("You have to enter a date on the format 'yyyy-mm-dd' for example '2024-05-11'");
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
    public static void Error(string message) 
    {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(message);
        ResetColor();
    }
}

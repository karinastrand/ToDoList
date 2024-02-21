namespace ToDoList;

public class Menu
{//The Menus 
    public static void ShowStartMenu()
    {//Start Menu
        WriteLine("Pick an option");
        ForegroundColor = ConsoleColor.Blue;
        WriteLine("(1) Show Project List");
        WriteLine("(2) Add new Project");
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("(3) Show Task List sorted by due date");
        WriteLine("(4) Show Task List sorted by project");
        WriteLine("(5) Add new Task");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("(6) Edit");
        ForegroundColor= ConsoleColor.Magenta;
        WriteLine("(7) Save");
        WriteLine("(8) Save and Quit");
        ResetColor();
    }
    
    public static void ShowEditMenu()
    {//Edit Menu
        WriteLine("Pick an option");
        ForegroundColor=ConsoleColor.Blue;
        WriteLine("(1) Change Project Title");
        WriteLine("(2) Change Project Description");
        WriteLine("(3) Remove Project (Can only be done if the project doesn't contain any tasks");
        ForegroundColor=ConsoleColor.Yellow;
        WriteLine("(4) Change Task Title");
        WriteLine("(5) Change Task Descritpion");
        WriteLine("(6) Change Task Due date");
        WriteLine("(7) Mark Task as done");
        WriteLine("(8) Tie Task to another project");
        WriteLine("(9) Remove Task");
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("(10) Quit");
        ResetColor();
    }
}


namespace ToDoList;

public class Menu
{
    public static void ShowStartMenu()
    {
        
        WriteLine("Pick an option");
        WriteLine("(1) Show Project List");
        WriteLine("(2) Add new Project");
        WriteLine("(3) Edit Project");
        WriteLine("(4) Show Task List");
        WriteLine("(5) Add new Task");
        WriteLine("(6) Edit Task");
        WriteLine("(7) Save");
        WriteLine("(8) Save and Quit");

    }
    public static void ShowEditProjectMenu()
    {
        WriteLine("Pick an option");
        WriteLine("(1) Edit Project");
        WriteLine("(2) Remove Project");
        WriteLine("(3) Quit");

    }
    public static void ShowEditTaskMenu()
    {
        WriteLine("Pick an option");
        WriteLine("(1) Edit Task");
        WriteLine("(2) Remove Task");
        WriteLine("(3) Mark Task as Done");
        WriteLine("(4) Quit");
    }

}

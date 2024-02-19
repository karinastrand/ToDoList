
namespace ToDoList;

public class Menu
{
    public static void ShowStartMenu()
    {
        
        WriteLine("Pick an option");
        WriteLine("(1) Show Project List");
        WriteLine("(2) Add new Project");
        WriteLine("(3) Show Task List sorted by due date");
        WriteLine("(4) Show Task List sorted by project");
        WriteLine("(5) Add new Task");
        WriteLine("(6) Edit");
        WriteLine("(7) Save");
        WriteLine("(8) Save and Quit");

    }
    
    public static void ShowEditTaskMenu()
    {
        WriteLine("Pick an option");
        WriteLine("(1) Edit Project");
        WriteLine("(2) Remove Project (Can only be done if the project doesn't contain any tasks");
        WriteLine("(3) Edit Task");
        WriteLine("(4) Mark task as done");
        WriteLine("(5) Remove Task");
        WriteLine("(6) Quit");
    }

}

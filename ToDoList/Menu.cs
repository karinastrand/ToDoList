namespace ToDoList;

public class Menu
{//The Menus 
    public static void ShowStartMenu()
    {//Start Menu
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
    
    public static void ShowEditMenu()
    {//Edit Menu
        WriteLine("Pick an option");
        WriteLine("(1) Edit Project");
        WriteLine("(2) Remove Project (Can only be done if the project doesn't contain any tasks");
        WriteLine("(3) Edit Task");
        WriteLine("(4) Mark task as done");
        WriteLine("(5) Remove Task");
        WriteLine("(6) Quit");
    }
    public static void ShowEditProjectsMenu() 
    {
        WriteLine("What do you want to edit (write an integer from the list) :");
        WriteLine("1. Title");
        WriteLine("2. Description");
        WriteLine("3. Quit");
    }
    public static void ShowEditTasksMenu()
    {
        WriteLine("What do you want to change, write 'q' when you are ready (write an integer from the list) :");
        WriteLine("1. Title");
        WriteLine("2. Description");
        WriteLine("3. Due Date");
        WriteLine("4. Tie to another project");
        WriteLine("5. Quit");
    }
}

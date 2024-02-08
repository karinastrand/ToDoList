
namespace ToDoList;

internal class Menu
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
    public static void UserInput(TaskList tasks, ProjectList projects)
    {
        WriteLine("Welcome to ToDo");
        tasks.TaskInfo();
        while(true)
        {
            ShowStartMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {
                        projects.ShowProjects();
                        break;
                    }

                case "2":
                    {
                        projects.AddNewProjects();
                        break;
                    }
                case "3":
                    {
                        projects.EditProjects();
                        break;
                    }
                case "4":
                    {
                       
                        tasks.ShowTasks();
                        break;
                    }

                case "5":
                    {
                        tasks.AddNewTasks(projects);
                        break;
                    }
                case "6":
                    {
                        tasks.EditTasks();
                        break;
                    }
                case "7": case "8":
                    {
                        tasks.SaveTaskList();
                        projects.SaveProjectList();
                      
                        break;
                    }
               
                
                default:
                    {
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if(menuChoise== "8")
            {
                break;
            }
        }
    }
}

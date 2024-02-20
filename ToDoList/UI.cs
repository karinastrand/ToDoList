namespace ToDoList;
public class UI
{//ToDos userinterface, shows Start Menu and Edit Menu and handles the user's input

    private Tasks tasksHandling = new Tasks("tasks.txt");
    private Projects projectsHandling = new Projects("projects.txt");

    public void Input()
    {
        //Saved Tasks and Projects are fetched from files
        tasksHandling.GetFromString();
        projectsHandling.GetFromString();
        WriteLine("Welcome to ToDoLy");
        //Info about tasks
        tasksHandling.TaskInfo();
        MenuChoise();
    }
    public  void MenuChoise()
    {//Shows the start menu and takes care of the user's answer
        while (true)
        {
            Menu.ShowStartMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {
                        //Shows Projects
                        projectsHandling.ShowProjects(tasksHandling);
                        break;
                    }

                case "2":
                    {
                        //Adding new Projects
                        projectsHandling.AddNewItems();
                        break;
                    }
                
                case "3":
                    {
                        //Shows Tasks, the default sorting is by due date
                        tasksHandling.ShowTasks();
                        break;
                    } 
                case "4":
                    {
                        //Shows Tasks sorted by ProjectTitles
                        tasksHandling.ShowTasksSortedByProject();
                        break;
                    }

                case "5":
                    {
                        //Adding new Task
                        tasksHandling.AddNewTasks(projectsHandling);
                        break;
                    }
                case "6":
                    {
                        //Showing Edit menu and handles the user input
                        EditMenuChoise();
                        break;
                    }
                case "7":
                case "8":
                    {
                        //Saves the Tasks and Projests to files
                        tasksHandling.TasksToStringList();
                        projectsHandling.ProjectsToStringList();
                        break;
                    }
                default:
                    {
                        //User input has to be an integer between 1 and 8
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "8")
            {
                //Exit the program
                break;
            }
        }
    }
 
    public void EditMenuChoise()
    {//Shows the Edit Menu and takes care of user input
        while (true)
        {
            Menu.ShowEditMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {   //Change Project Title
                        projectsHandling.ChangeTitle(tasksHandling);
                        break;
                    }

                case "2":
                    {
                        //Change Project Description
                        projectsHandling.ChangeDescription(tasksHandling);
                        break;
                    }
                case "3":
                    {
                        //Removing Projects
                        projectsHandling.RemoveProjects(tasksHandling);
                        break;
                    }
                case "4":
                    {
                        //Change Task Title
                        tasksHandling.ChangeTitle();
                        break;
                    }
                case "5":
                    {
                        //Change Task Description
                        tasksHandling.ChangeDescription();
                        break;
                    }
                case "6":
                    {
                        //Change Task DueDate
                        tasksHandling.ChangeDueDate();
                        break;
                    }

                case "7":
                    {
                        //Set Task as done
                        tasksHandling.MarkAsDone();
                        break;
                    }
                case "8":
                    {
                        //Change which project the task belongs to
                        tasksHandling.ChangeProject(projectsHandling);
                        break;
                    }
                case "9":
                    {
                        //Removing Tasks
                        tasksHandling.RemoveTasks();
                        break;
                    }                
                default:
                    {
                        //The input has to be an integer between 1 and 6
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "10")
            {
                //Exiting the Edit Menu
                break;
            }
        }
    }   
}

   


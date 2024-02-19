namespace ToDoList;
public class UI
{//ToDos userinterface, shows Start Menu and Edit Menu and handles the user's input

    private Tasks tasksHandling = new Tasks();
    private Projects projectsHandling = new Projects();

    public void Input()
    {
        //Saved Tasks and Projects are fetched from files
        tasksHandling.GetFromFile();
        projectsHandling.GetFromFile();
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
                        projectsHandling.Show(tasksHandling);
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
                        tasksHandling.Show();
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
                        tasksHandling.SaveToFile();
                        projectsHandling.SaveToFile();
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
                    {   //Editing Projects
                        projectsHandling.EditProjects(tasksHandling);
                        break;
                    }

                case "2":
                    {
                        //Removing Projects
                        projectsHandling.RemoveProjects(tasksHandling);
                        break;
                    }
                case "3":
                    {
                        //Editing Tasks
                        tasksHandling.EditTasks(projectsHandling);
                        break;
                    }

                case "4":
                    {
                        //Sets the status of Tasks to 'done'
                        tasksHandling.MarkAsDone(projectsHandling);
                        break;
                    }
                case "5":
                    {
                        //Removing Tasks
                        tasksHandling.RemoveTasks(projectsHandling);
                        break;
                    }
                case "6":
                    {  
                        break;
                    }                
                default:
                    {
                        //The input has to be an integer between 1 and 6
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "6")
            {
                //Exiting the Edit Menu
                break;
            }
        }
    }   
}

   


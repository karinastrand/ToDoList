using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList;

public class UI
{
    private Tasks tasksHandling = new Tasks();
    private Projects projectsHandling = new Projects();

    public void Input()
    {
        tasksHandling.GetFromFile();
        projectsHandling.GetFromFile();
        WriteLine("Welcome to ToDoLy");
        tasksHandling.TaskInfo();
        MenuChoise();
    }
    public  void MenuChoise()
    {
        while (true)
        {
            Menu.ShowStartMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {
                        projectsHandling.Show();
                        break;
                    }

                case "2":
                    {
                        projectsHandling.AddNewProjects();
                        break;
                    }
                case "3":
                    {
                        EditProjectMenuChoise();
                        break;
                    }
                case "4":
                    {

                        tasksHandling.Show();
                        break;
                    }

                case "5":
                    {
                        tasksHandling.AddNewTasks(projectsHandling);
                        break;
                    }
                case "6":
                    {
                        EditTaskMenuChoise();
                        break;
                    }
                case "7":
                case "8":
                    {
                        tasksHandling.SaveToFile();
                        projectsHandling.SaveToFile();

                        break;
                    }
                default:
                    {
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "8")
            {
                break;
            }
        }
    }
    
    public void EditProjectMenuChoise()
    {
        while(true) 
        {
            Menu.ShowEditProjectMenu();
            string menuChoise = ReadLine();
            switch (menuChoise)
            {
                case "1":
                    {
                        projectsHandling.EditProjects();
                        break;
                    }

                case "2":
                    {
                        projectsHandling.RemoveProjects();
                        break;
                    }
                case "3":
                    {                        
                        break;
                    }
                default:
                    {
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "3")
            {
                break;
            }
        }
    }

    public void EditTaskMenuChoise()
    {
        while (true)
        {
            Menu.ShowEditTaskMenu();
            string menuChoise = ReadLine();

            switch (menuChoise)
            {
                case "1":
                    {
                        tasksHandling.EditTasks();
                        break;
                    }

                case "2":
                    {
                        tasksHandling.MarkAsDone();
                        break;
                    }
                case "3":
                    {
                        tasksHandling.RemoveTasks();
                        break;
                    }
                case "4":
                    {  
                        break;
                    }                
                default:
                    {
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "4")
            {
                break;
            }
        }
    }   
}

   


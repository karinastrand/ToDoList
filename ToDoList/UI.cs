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
                        projectsHandling.Show(tasksHandling);
                        break;
                    }

                case "2":
                    {
                        projectsHandling.AddNewItems();
                        break;
                    }
                
                case "3":
                    {

                        tasksHandling.Show();
                        break;
                    } 
                case "4":
                    {

                        tasksHandling.ShowTasksSortedByProject();
                        break;
                    }

                case "5":
                    {
                        tasksHandling.AddNewTasks(projectsHandling);
                        break;
                    }
                case "6":
                    {
                        EditMenuChoise();
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
    
   

    public void EditMenuChoise()
    {
        while (true)
        {
            Menu.ShowEditTaskMenu();
            string menuChoise = ReadLine();

            switch (menuChoise)
            {
                case "1":
                    {
                          projectsHandling.EditProjects(tasksHandling);
                        break;
                    }

                case "2":
                    {
                        projectsHandling.RemoveProjects(tasksHandling);
                        break;
                    }
                case "3":
                    {
                         tasksHandling.EditTasks(projectsHandling);
                        break;
                    }

                case "4":
                    {
                         tasksHandling.MarkAsDone(projectsHandling);
                        break;
                    }
                case "5":
                    {
                        tasksHandling.RemoveTasks(projectsHandling);
                        break;
                    }
                case "6":
                    {  
                        break;
                    }                
                default:
                    {
                        WriteLine("You have to choose one of the alternativ in the list");
                        break;
                    }
            }
            if (menuChoise == "6")
            {
                break;
            }
        }
    }   
}

   


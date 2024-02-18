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
                        tasksHandling.AddNewTasks(projectsHandling);
                        break;
                    }
                case "5":
                    {
                        EditMenuChoise();
                        break;
                    }
                case "6":
                case "7":
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
            if (menuChoise == "7")
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
                      //  projectsHandling.EditItems();
                        break;
                    }

                case "2":
                    {
                        projectsHandling.RemoveItems();
                        break;
                    }
                case "3":
                    {
                      //  tasksHandling.EditItems();
                        break;
                    }

                case "4":
                    {
                      //  tasksHandling.MarkAsDone();
                        break;
                    }
                case "5":
                    {
                        tasksHandling.RemoveItems();
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

   


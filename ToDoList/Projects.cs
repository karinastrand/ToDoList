

using System.Threading.Tasks;

namespace ToDoList;

public class Projects 
{
    
    public Projects(string nameOfFile)
    {
        NameOfFile = nameOfFile;
    }

    public Projects()
    {
        NameOfFile = "projects.txt";
    }

    public List<Project> ProjectsList { get; set; } = new List<Project>();
    public string NameOfFile { get; set; } = "projects.txt";
    public void AddNewItems()
    {

        int id = 1;
        while (true)
        {
            Console.WriteLine("Add new projects, exit with 'q'");
            WriteLine("Title: ");
            string title = ReadLine();
            if (title.ToLower().Trim() == "q")
            {
                break;
            }
            WriteLine("Description:");
            string description = ReadLine();


            if (ProjectsList.Count > 0)
            {
                id = ProjectsList.Max(item => item.Id) + 1;
            }
            Project newProject = new Project(id, title, description);
            ProjectsList.Add(newProject);

        }

    }
    public void EditProjects(Tasks tasks)
    {
        Show(tasks);
        Write("What project do you want to edit? (Choose from the list above and write it's id: ");
        string projectIdString = ReadLine();
        int projectId = 0;
        try
        {
            projectId = Convert.ToInt32(projectIdString);
            if (!ProjectExists(projectId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your projectlist");
                Console.WriteLine("The project could not be edited");
                ResetColor();
            }
            else
            {
                int index = ProjectsList.FindIndex(project => project.Id == projectId);
                while (true)
                {
                    Show(tasks);
                    WriteLine("What do you want to change (write an integer from the list) :");
                    WriteLine("1. Title");
                    WriteLine("2. Description");
                    WriteLine("3. Quit");

                    string answer = ReadLine();
                    if (answer.ToLower().Trim() == "3")
                    {
                        break;
                    }
                    int answerIndex = 0;
                    try
                    {
                        answerIndex = Convert.ToInt32(answer);
                        switch (answerIndex)
                        {
                            case 1:
                                {
                                    ChangeTitle(index);
                                    break;
                                }
                            case 2:
                                {
                                    ChangeDescription(index);
                                    break;
                                }
                           
                            default:
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You have to choose a number from the list");
                                    ResetColor();
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("You have to write a number from the list");
                        ResetColor();
                    }
                }

            }
        }
        catch (FormatException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id has to be an integer");
            Console.WriteLine("The task could not be changed");
            ResetColor();
        }
    }
    public void RemoveProjects(Tasks tasks)
    {
        Show(tasks);
        WriteLine("What task do you want to remove?");
        Write("Only projects with no tasks can be removed, remove the tasks first then you can remove the project. (Choose from the list above and write it's id: ");
        string projectIdString = ReadLine();
        int projectId = 0;
        try
        {
            projectId = Convert.ToInt32(projectIdString);
            if (!ProjectExists(projectId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your tasklist");
                Console.WriteLine("The task could not be removed");
                ResetColor();
            }
            else if(NumberOfTasks(projectId,tasks)>0)
            {
                ForegroundColor=ConsoleColor.Red;
                WriteLine("You have to remove the tasks before you remove the project.");
                ResetColor();
            }
            else
            {
                int index = ProjectsList.FindIndex(project => project.Id == projectId);
                if (ProjectsList.Remove(ProjectsList[index]))
                {
                    ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The project was succesfully removed");
                    ResetColor();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The project could not be removed");
                    ResetColor();
                }

            }
        }
        catch (FormatException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id has to be an integer");
            Console.WriteLine("The task could not be removed");
            ResetColor();
        }
    }



    public void GetFromFile()
    {
        //Fetches strings from the file of stored projects and convert the strings to Project objects.
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> savedProjects = fileHandling.ReadFromFile();
        try
        {
            foreach (string projectString in savedProjects)
            {
                Project savedProject = new Project();
                ProjectsList.Add(savedProject.ItemFromString(projectString));
            }
        }
        catch (NullReferenceException)
        {

        }
        
    }

    public  void SaveToFile()
    //Converts the Project Objects to a list of strings and saves the string list to the file.
    {
        if (ProjectsList.Count > 0) 
        {
            List<string> projectsToSave = new List<string>();
            foreach (Project project in ProjectsList)
            {
                if(project.Id>0)
                {
                    projectsToSave.Add(project.ItemToString());

                }
            }
            FileHandling fileHandling = new FileHandling(NameOfFile);
            fileHandling.SaveToFile(projectsToSave);
        }
        
    }

    public  void Show(Tasks tasks)
    {
        WriteLine("Id".PadRight(5)+"Title".PadRight(25)+"Description".PadRight(25)+"Number of Tasks");
        foreach(Project project in ProjectsList) 
        {
            Write(project.Print());
            if (tasks.TasksList.Count>0) 
            {
                WriteLine($"{NumberOfTasks(project.Id, tasks)}");
            }
            else 
            {
                WriteLine("0");
            }
            
        }
    }

    public bool ProjectExists(int id)
    {
        return ProjectsList.Exists(project=>project.Id == id);
    }
    public int NumberOfTasks(int id,Tasks tasks)
    {
        int numberOfTasks = 0;
        try
        {
            tasks.TasksList.Where(task => task.TaskProject.Id == id).Count();
        }
        catch (NullReferenceException)
        {
            
        }
        return numberOfTasks;
    }
    public Project ProjectFromId(int id)
    {
        Project project =ProjectsList.Where(project=>project.Id == id).FirstOrDefault();
        return project;
    }
    public void ChangeTitle(int index)
    {
        WriteLine($"Old title: {ProjectsList[index].Title}");
        Write("New title: ");
        string title = ReadLine();
        ProjectsList[index].Title = title;
        ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The title is successfully changed");
        ResetColor();
    }
    public void ChangeDescription(int index)
    {
        WriteLine($"Old description: {ProjectsList[index].Description}");
        Write("New description: ");
        string description = ReadLine();
        ProjectsList[index].Description = description;
        ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The description is successfully changed");
        ResetColor();
    }
}

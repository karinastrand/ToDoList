namespace ToDoList;
public class Projects :Lists
{//Contains a list of Projects and the name of the file to save on
    public List<Project> ProjectsList { get; set; } = new List<Project>();
    public string NameOfFile { get; set; } = "projects.txt";
    public Projects()
    {
        NameOfFile = "projects.txt";
    }
    public Projects(string nameOfFile)
    {
        NameOfFile = nameOfFile;
    }
    public void AddNewItems()
    {//Adding new Projets until the user writes 'q'
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
            {//ProjectId is highest ProjectId in the list +1
                id = ProjectsList.Max(item => item.Id) + 1;
            }
            Project newProject = new Project(id, title, description);
            ProjectsList.Add(newProject);
            Messages.Success("The project has been added");
        }
    }
    public void EditProjects(Tasks tasks)
    {//Edit project, name and deecription can be changed
        Show(tasks);
        Write("What project do you want to edit? (Choose from the list above and write it's id: ");
        string projectIdString = ReadLine();
        int projectId = 0;
        try
        {//check if ther is a project with that id in the ProjectList
            projectId = Convert.ToInt32(projectIdString);
            if (!ProjectExists(projectId)) //Not in the ProjectList
            {
                Messages.NotInList();
            }
            else
            {//If the projectId was found in the list it is possible to edit it.
                int index = ProjectsList.FindIndex(project => project.Id == projectId); //the index of the Project the user wants to edit
                while (true)
                {//Edits the project until the user writes 3
                    Show(tasks); //uses TaskList to see how many tasks each project has
                    Menu.ShowEditProjectsMenu();
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
                                {//The user has to write an integer between 1 and 3
                                    Messages.NotInMenuList();
                                    break;
                                }
                        }
                    }
                    catch (FormatException) //the user wrote a menu choice which couldn't be converted to an integer
                    {
                        Messages.NotANumber();
                    }
                }
            }
        }
        catch (FormatException)//the user wrote a projectid which couldn't be converted to an integer
        {
           Messages.NotANumber();
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
            {//Not a valid ProjectId
               Messages.NotInList();
            }
            else if(NumberOfTasks(projectId,tasks)>0)
            {//The Project contains Tasks
                Messages.ProjectIsNotEmpty();
            }
            else
            {//ok to remove
                int index = ProjectsList.FindIndex(project => project.Id == projectId);//the index of the Project the user wants to remove
                if (ProjectsList.Remove(ProjectsList[index]))
                {
                    Messages.Success("The Project was removed");
                }
                else
                {
                    Messages.SomethingWentWrong();
                }
            }
        }
        catch (FormatException)
        {
            Messages.NotANumber();//The inputed ProjectId was not on integer
        }
    }
    public void GetFromFile()
    {
        //Fetches strings from the file of stored projects and convert the strings to Project objects.
        List<string> savedProjects = GetFromFile(NameOfFile); //Base class takes care of filehandling
        try
        {//Converts the returned strings to Project and saves them to ProjectList
            foreach (string projectString in savedProjects)
            {
                Project savedProject = new Project();
                ProjectsList.Add(savedProject.ItemFromString(projectString));
            }
        }
        catch (NullReferenceException)
        {
            Messages.SomethingWentWrong();
        }
    }
    public  void SaveToFile()
    //Converts the Project Objects to a list of strings and saves the string list to a file.
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
            SaveToFile(projectsToSave,NameOfFile); //Base class takes care of the filehandling
        }
    }

    public  void Show(Tasks tasks)
    {//Writes information of the Project to the console. 
        WriteLine("Id".PadRight(5)+"Title".PadRight(25)+"Description".PadRight(25)+"Number of Tasks");
        foreach(Project project in ProjectsList) 
        {
            Write(project.Print());
            if (tasks.TasksList.Count>0) 
            {
                WriteLine($"{NumberOfTasks(project.Id, tasks)}"); //Adds information about how many tasks the projects currently has
            }
            else 
            {//if there is no Tasks in the TaskList 
                WriteLine("0");
            }
        }
    }

    public bool ProjectExists(int id)
    {//returns true if the inputted id is an Id in the ProjectList
        return ProjectsList.Exists(project=>project.Id == id);
    }
    public int NumberOfTasks(int id,Tasks tasks)
    {//returns the number of Tasks the Project has
        int numberOfTasks = 0;
        try
        {
            tasks.TasksList.Where(task => task.TaskProject.Id == id).Count();
        }
        catch (NullReferenceException)
        {
            Messages.SomethingWentWrong();
        }
        return numberOfTasks;
    }
    
    public void ChangeTitle(int index)
    {//Change title of The Project
        WriteLine($"Old title: {ProjectsList[index].Title}");
        Write("New title: ");
        string title = ReadLine();
        ProjectsList[index].Title = title;
        Messages.Success("The title is edited");
    }
    public void ChangeDescription(int index)
    {//Change description of the Project
        WriteLine($"Old description: {ProjectsList[index].Description}");
        Write("New description: ");
        string description = ReadLine();
        ProjectsList[index].Description = description;
        Messages.Success("The description is edited");
    }
    public Project ProjectFromId(int id)
    {//returns the Project with the inputted id
        Project project = ProjectsList.Where(project => project.Id == id).FirstOrDefault();
        return project;
    }
}

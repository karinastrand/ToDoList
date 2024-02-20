namespace ToDoList;
public class Projects :Lists
{//Contains a list of Projects and the name of the file to save on
   
    public List<Project> ProjectsList { get; set; } = new List<Project>();
    public Projects(string nameOfFile) : base(nameOfFile)
    {
    }

    public void GetFromString()
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
    public void ProjectsToStringList()
    //Converts the Project Objects to a list of strings and saves the string list to a file.
    {
        if (ProjectsList.Count > 0)
        {
            List<string> projectsToSave = new List<string>();
            foreach (Project project in ProjectsList)
            {
                if (project.Id > 0)
                {
                    projectsToSave.Add(project.ItemToString());
                }
            }
            SaveToFile(projectsToSave, NameOfFile); //Base class takes care of the filehandling
        }
    }
    public void ShowProjects(Tasks tasks)
    {//Writes information of the Project to the console. 
        WriteLine("My projects");
        ForegroundColor=ConsoleColor.Magenta;
        WriteLine("Id".PadRight(5) + "Title".PadRight(25) + "Description".PadRight(31) + "Number of Tasks");
        ResetColor();
        foreach (Project project in ProjectsList)
        {
            Write(project.Print());
            if (tasks.TasksList.Count > 0)
            {
                WriteLine($"{Functions.NumberOfTasks(project.Id, tasks)}"); //Adds information about how many tasks the projects currently has
            }
            else
            {//if there is no Tasks in the TaskList 
                WriteLine("0");
            }
        }
        WriteLine();
    }
    public void AddNewItems()
    {//Adds new Projets until the user writes 'q'
        int id = 1;
        while (true)
        {
            Console.WriteLine("Add new projects, exit with 'q'");
            Write("Title: ");
            string title = ReadLine();
            if (title.ToLower().Trim() == "q")
            {
                break;
            }
            Write("Description (max 30 characters ) :");
            string description = ReadLine();
            if (description.Length>30)
            {
                description= description.Substring(0,30);
            }
            if (ProjectsList.Count > 0)
            {//ProjectId is highest ProjectId in the list +1
                id = ProjectsList.Max(item => item.Id) + 1;
            }
            //A new Project is created and added to the ProjectList
            Project newProject = new Project(id, title, description);
            ProjectsList.Add(newProject);
            Messages.Success("The project has been added");
        }
    }
    public Project ProjectToEdit(Tasks tasks, string message)
    {//Which project is going to be edited/removed?
        ShowProjects(tasks);
        Write($"{message}: ");
        string projectIdString = ReadLine();
        int projectId = 0;
        int index = -1;
        Project projectToEdit = new Project();
        try
        {//check if ther is a project with that id in the ProjectList
            projectId = Convert.ToInt32(projectIdString);
            if (!Functions.ProjectExists(this,projectId)) //Not in the ProjectList
            {
                Messages.NotInList();
            }
            else
            {//If the projectId was found in the list it is possible to edit it.
                index = ProjectsList.FindIndex(project => project.Id == projectId); //the index of the Project the user wants to edit
            }
        }
        catch (FormatException)//the user wrote a projectid which couldn't be converted to an integer
        {
           Messages.NotANumber();
        }
        if (index>-1)
        {
            projectToEdit = Functions.GetProject(projectId,ProjectsList);
        }
        return projectToEdit;
    }
    
    public void ChangeTitle(Tasks tasks)
    {//Change title of The Project
        Project projectToEdit = ProjectToEdit(tasks, "Which project do you want to change title on (write id)?");//Returns the project the user wants to remove
        if (projectToEdit.Id > 0) //if the user has chosen an existing project
        {
            WriteLine($"Old title: {projectToEdit.Title}");
            Write("New title: ");
            string title = ReadLine();
            projectToEdit.Title = title;
            if(Functions.NumberOfTasks(projectToEdit.Id, tasks)>0)         
            {
                Functions.EditProjectTitle(projectToEdit.Id, title,tasks);
            }
            Messages.Success("The title is edited");
        }
    }
    public void ChangeDescription(Tasks tasks)
    {//Change description of the Project
        Project projectToEdit = ProjectToEdit(tasks, "Which project do you want to change description on (write id)?");//Returns the project the user wants to remove
        if (projectToEdit.Id > 0)//if the user has chosen an existing project
        {
            WriteLine($"Old description: {projectToEdit.Description}");
            Write("New description (max 30 characters) : ");
            string description = ReadLine();
            if (description.Length > 30)
            {
                description = description.Substring(0,30);
            }
            projectToEdit.Description = description;

            {
                Functions.EditProjectDescription(projectToEdit.Id,description,tasks);
            }
            Messages.Success("The description is edited");
        }
    }
    public void RemoveProjects(Tasks tasks)
    {//Removes a projet, only possible if the project is empty of tasks    
        Project projectToRemove = ProjectToEdit(tasks, "What task do you want to remove (write id)?");//Returns the project the user wants to remove
        if (projectToRemove.Id > 0)//if the user has chosen an existing project
        {
            if (Functions.NumberOfTasks(projectToRemove.Id, tasks) > 0) //Not possible to remove a Project if it contains Tasks
            {
                Messages.ProjectIsNotEmpty();
            }
            else
            {//ok to remove
                if (ProjectsList.Remove(projectToRemove))
                {
                    Messages.Success("The Project was removed");
                }
                else
                {
                    Messages.SomethingWentWrong();
                }
            }
        }
    }


}

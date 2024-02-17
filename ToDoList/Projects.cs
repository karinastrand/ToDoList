
namespace ToDoList;

public class Projects:ILists
{
    public Projects()
    {
        ProjectList = new List<Project>();
        NameOfFile = "myProjects.txt";
    }

    public List<Project> ProjectList {  get; set; }
    public string NameOfFile { get; set; }


    public void Show()
    {
        WriteLine("My projects");
        WriteLine("Id".PadRight(20)+"Name".PadRight(20)+"Description");
        foreach (Project project in ProjectList) 
        {
            Console.WriteLine(project.PrintProject()); 
        }
    }
    public void AddNewProjects()
    {
        WriteLine("Add new projects, enter q when you are done");
        int id = 1;
        while (true)
        {
            WriteLine("ProjectName: ");
            string projectName = ReadLine();
            if (projectName.ToLower().Trim() == "q")
            {
                break;
            }
            WriteLine("Description:");
            string projectDescription = ReadLine();
            if (ProjectList.Count > 0)
            {
                id = ProjectList.Max(project => project.ProjectId) + 1;
            }
            Project newProject = new Project(id, projectName, projectDescription);
            ProjectList.Add(newProject);

        }

    }
    public void EditProjects()
    {
        
    }
    
    public void RemoveProjects()
    {
       
    }
    public List<string> ProjectListToStrings()
    {
        List<string> projecListToString = new List<string>();
        foreach (Project project in ProjectList) 
        {
            projecListToString.Add(project.ProjectToString());
        }
        return projecListToString;
    }
    
    public void SaveToFile()
    {
        //Converts the Projects in list of Projects to strings, adds them to a list of strings and writes them to the file.
        List<string> projectToSave = new List<string>();
        foreach (Project project in ProjectList)
        {
            if (project.ProjectName.Length > 0)
            {
                projectToSave.Add(project.ProjectToString());
            }
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(projectToSave);
    }
    
    public void GetFromFile()
    {
        FileHandling fileData = new FileHandling(NameOfFile);
        List<string> savedProjects = fileData.ReadFromFile();
        foreach (string projectString in savedProjects)
        {
            Project savedProject = new Project();
            ProjectList.Add(savedProject.ProjectFromString(projectString));
        }

    }
    public bool ProjectExists(int id)
    {
        return ProjectList.Exists(product => product.ProjectId == id);
    }

    public void StringListToProjectList(List<string> list)
    {
        foreach (string projectString in list)
        {
            Project project = new Project();
            project = project.ProjectFromString(projectString);
            ProjectList.Add(project);
        }
    }
}

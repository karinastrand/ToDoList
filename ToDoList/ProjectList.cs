
using System.Security.Cryptography.X509Certificates;

namespace ToDoList;

internal class ProjectList
{
    public ProjectList()
    {
        Projects = new List<Project>();
        FileName = "myProjects.txt";
    }

    public List<Project> Projects {  get; set; }
    public string FileName { get; set; }


    public void ShowProjects()
    {
        WriteLine("My projects");
        WriteLine("Id".PadRight(20)+"Name".PadRight(20)+"Description");
        foreach (Project project in Projects) 
        {
            Console.WriteLine(project.PrintProject()); 
        }
    }
    public void AddNewProjects()
    {
        WriteLine("Add new projects, enter q when you are done");
        int id = 1;
        while(true) 
        {
            WriteLine("ProjectName: ");
            string projectName = ReadLine();
            if(projectName.ToLower().Trim()=="q")
            {
                break;
            }
            WriteLine("Description:");
            string projectDescription = ReadLine();
            if (Projects.Count > 0)
            {
                id = Projects.Max(project => project.ProjectId) + 1;
            }
            Project newProject = new Project(id, projectName, projectDescription);
            Projects.Add(newProject);
            WriteLine(Projects.Count() + "!");
        }

    }
    public List<string> ProjectListToStrings()
    {
        List<string> projecListToString = new List<string>();
        foreach (Project project in Projects) 
        {
            projecListToString.Add(project.ProjectToString());
        }
        return projecListToString;
    }
    public void EditProjects()
    {

    }
    public void SaveProjectList()
    {
        FileHandling fileHandling = new FileHandling(FileName);
        List<string> projectsToSave = ProjectListToStrings();
        fileHandling.SaveToFile(projectsToSave);
    }
    public bool ProjectExists(int id)
    {
        return Projects.Exists(product => product.ProjectId == id);
    }
    public void LoadProjectList()
    {
        FileHandling fileData = new FileHandling(FileName);
        List<string> mySavedProjects = fileData.ReadFromFile();
        StringListToProjectList(mySavedProjects);
        
    }

    public void StringListToProjectList(List<string> list)
    {
        foreach (string projectString in list)
        {
            Project project = new Project();
            project = project.ProjectFromString(projectString);
            Projects.Add(project);
        }
    }
}

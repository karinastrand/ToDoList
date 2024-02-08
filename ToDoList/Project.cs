
using System.Net.Http.Headers;

namespace ToDoList;

internal class Project
{
    public Project(int projectId, string projectName, string projectDescription)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        ProjectDescription = projectDescription;
        tasks=new TaskList();
    }

    public Project()
    {
        tasks = new TaskList();
    }

    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public TaskList tasks { get; set; }

    public string ProjectToFile()
    {
        return $"{ProjectId.ToString()},{ProjectName},{ProjectDescription}";

    }
    public Project ProjectFromFile(string savedProject)
    {
        Project projectFromFile = new Project();
        int projectId = 0;
        Int32.TryParse(savedProject.Split(',')[0] , out projectId);
        projectFromFile.ProjectId = projectId;
        projectFromFile.ProjectName = savedProject.Split(',')[1];
        projectFromFile.ProjectDescription = savedProject.Split(',')[2];
        return projectFromFile;
    }
    public string PrintProject()
    {
        return $"{ ProjectId.ToString().PadRight(20)}{ProjectName.PadRight(20)}{ProjectDescription.PadRight(20)}";
        
    }
}

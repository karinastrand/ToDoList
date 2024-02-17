
namespace ToDoList;

public class Project
{
    public Project(int projectId, string projectName, string projectDescription)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        ProjectDescription = projectDescription;
        TaskList=new Tasks();
    }

    public Project()
    {
        TaskList = new Tasks();
    }

    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public Tasks TaskList { get; set; }

    public string ProjectToString()
    {
        return $"{ProjectId.ToString()},{ProjectName},{ProjectDescription}";

    }
    public Project ProjectFromString(string projectString)
    {
        Project projectFromString = new Project();
        int projectId = 0;
        Int32.TryParse(projectString.Split(',')[0] , out projectId);
        projectFromString.ProjectId = projectId;
        projectFromString.ProjectName = projectString.Split(',')[1];
        projectFromString.ProjectDescription = projectString.Split(',')[2];
        return projectFromString;
    }
    public string PrintProject()
    {
        return $"{ ProjectId.ToString().PadRight(20)}{ProjectName.PadRight(20)}{ProjectDescription.PadRight(20)}";
        
    }
}

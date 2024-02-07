
namespace ToDoList;

internal class ProjectList
{
    public ProjectList()
    {
        Projects = new List<Project>();
        FileName = "myProjects.txt";
    }

    public List<Project> Projects {  get; set; }
    public string FileName { get; }
}

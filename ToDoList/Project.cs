
namespace ToDoList;

internal class Project
{
    int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public TaskList tasks { get; set; }
}

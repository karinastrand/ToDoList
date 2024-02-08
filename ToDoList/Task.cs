
namespace ToDoList;

internal class Task
{
  
    public Task()
    {
    }

    public Task(int taskId, string taskTitle, DateTime dueDate, Status taskStatus, int projectId)
    {
        TaskId = taskId;
        TaskTitle = taskTitle;
        DueDate = dueDate;
        TaskStatus = taskStatus;
        ProjectId = projectId;
    }

    

    public int TaskId { get; set; }
    public string TaskTitle {  get; set; }
    public DateTime DueDate { get; set; }
    public Status TaskStatus { get; set; }
    public int ProjectId { get; set; }

    public string TaskToString()
    {
        return $"{TaskId},{TaskTitle},{DueDate.ToString("d")},{(int)TaskStatus},{ProjectId}";
    }
    
    public Task TaskFromString(string task)
    {
           
        string[] taskParts=task.Split(',');
        int id = 0;
        Int32.TryParse(taskParts[0], out id);
        int projektid = 0;
        Int32.TryParse(taskParts[4], out projektid);
        Status stat = 0;
        int intStatus = 0;
        Int32.TryParse(taskParts[3],out intStatus);
        stat = (Status)intStatus;
        Task taskFromFile = new Task(id, taskParts[1], Convert.ToDateTime(taskParts[2]), stat, projektid);
        return taskFromFile;
    }
    public void PrintTask()
    {
        WriteLine($"{TaskId.ToString().PadRight(20)}{TaskTitle.PadRight(20)}{DueDate.ToString("d").PadRight(20)}{TaskStatus.ToString().PadRight(20)}{ProjectId}");
    }

    
}

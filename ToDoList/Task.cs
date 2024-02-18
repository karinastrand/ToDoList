using System.Diagnostics;

namespace ToDoList;

public class Task:Project
{
    public Task(int id, string title, string description,DateTime dueDate, Status taskStatus, int projectId) : base(id, title, description)
    {
        DueDate = dueDate;
        TaskStatus = taskStatus;
        ProjectId = projectId;
    }

    public Task()
    {
    }

    public DateTime DueDate { get; set; }
    public Status TaskStatus { get; set; }
    public int ProjectId { get; set; }
    

    public override string ItemToString()
    {
        return $"{Id},{Title},{Description},{DueDate.ToString("d")},{(int)TaskStatus},{ProjectId}";
    }
    
    public override Task ItemFromString(string taskString)
    {
           
        string[] taskParts=taskString.Split(',');
        int id = 0;
        Int32.TryParse(taskParts[0], out id);
        int projectid = 0;
        Int32.TryParse(taskParts[5], out projectid);
        Status stat = 0;
        int intStatus = 0;
        Int32.TryParse(taskParts[4],out intStatus);
        stat = (Status)intStatus;
        Task taskFromString = new Task(id, taskParts[1], taskParts[2],Convert.ToDateTime(taskParts[3]), stat, projectid);
        return taskFromString;
    }
    public  string Print()
    {
        
        
         return($"{Id.ToString().PadRight(5)}{Title.PadRight(15)}{Description.PadRight(20)}{DueDate.ToString("d").PadRight(15)}{TaskStatus.ToString().PadRight(10)}{ProjectId.ToString().PadRight(15)}");
    }
  

}

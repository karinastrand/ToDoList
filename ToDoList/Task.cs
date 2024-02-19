using System.Diagnostics;

namespace ToDoList;

public class Task:Project
{
    public Task(int id, string title, string description,DateTime dueDate, Status taskStatus, Project taskProject) : base(id, title, description)
    {
        DueDate = dueDate;
        TaskStatus = taskStatus;
        TaskProject= taskProject;
    }

    public Task()
    {
    }

    public DateTime DueDate { get; set; }
    public Status TaskStatus { get; set; }
    public Project TaskProject { get; set; }
    

    public override string ItemToString()
    {
        return $"{Id},{Title},{Description},{DueDate.ToString("d")},{(int)TaskStatus},{TaskProject.Title},{TaskProject.Description},{TaskProject.Id}";
    }
    
    public override Task ItemFromString(string taskString)
    {
        Task taskFromString = new Task();
        try
        {
            string[] taskParts = taskString.Split(',');
            int id = Convert.ToInt32(taskParts[0]);
            int projectId = Convert.ToInt32(taskParts[7]);
            Status stat = 0;
            int intStatus = Convert.ToInt32(taskParts[4]);
            stat = (Status)intStatus;
            Project taskProject= new Project(projectId, taskParts[6],taskParts[5]);
            taskFromString = new Task(id, taskParts[1], taskParts[2], Convert.ToDateTime(taskParts[3]), stat, taskProject);
        }
        catch (FormatException)
        {
            ForegroundColor=ConsoleColor.Red;
            WriteLine("It was not possible to make a task form the string due to format problems");
            ResetColor();
        }
        catch (IndexOutOfRangeException)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("It was not possible to make a task form the string, index out of range");
            ResetColor();
        }
        return taskFromString;
    }
    public override string Print()
    { 
         return($"{DueDate.ToString("d").PadRight(15)}{Title.PadRight(20)}{Id.ToString().PadRight(5)}{Description.PadRight(25)}{TaskStatus.ToString().PadRight(10)}{TaskProject.Title.PadRight(25)}{TaskProject.Id}");
    }
  

}

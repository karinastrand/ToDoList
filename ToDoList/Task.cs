namespace ToDoList;
public class Task:Item
{//Repersents a Task, is a sub class to Item
    public DateTime DueDate { get; set; }
    public Status TaskStatus { get; set; }
    public Project TaskProject { get; set; }
    public Task()
    {
    }
    public Task(int id, string title, string description,DateTime dueDate, Status taskStatus, Project taskProject) : base(id, title, description)
    {
        DueDate = dueDate;
        TaskStatus = taskStatus;
        TaskProject= taskProject;
    }
    public override string ItemToString()
    {//Returns a string that can be saved to a text file
        return $"{Id},{Title},{Description},{DueDate.ToString("d")},{(int)TaskStatus},{TaskProject.Title},{TaskProject.Description},{TaskProject.Id}";
    }
    public override Task ItemFromString(string taskString)
    {//returns a Task created from a string (saved on a text file)
        Task taskFromString = new Task();
        try
        {//the saved string contains seven parts separated with ','
            string[] taskParts = taskString.Split(',');
            int id = Convert.ToInt32(taskParts[0]);
            int projectId = Convert.ToInt32(taskParts[7]);
            Status stat = 0;
            int intStatus = Convert.ToInt32(taskParts[4]);
            stat = (Status)intStatus; //converts int to enum Status
            Project taskProject= new Project(projectId, taskParts[5],taskParts[6]);
            taskFromString = new Task(id, taskParts[1], taskParts[2], Convert.ToDateTime(taskParts[3]), stat, taskProject);
        }
        catch (FormatException)
        {//taskPart[0],[4] and[7] has to be convertable to int and taskPart[3] has to be convertable to DateTime
            Messages.Error("It was not possible to make a task form the string due to format problems");
        }
        catch (IndexOutOfRangeException)
        {//If the comma seperated parts of the string doesn't match what the Task constructor needs.
            Messages.Error("It was not possible to make a task form the string due to problem with the string");
        }
        return taskFromString;
    }
    public override string Print()
    { //Converts Task to a string suiteable for writing on the console.
        return ($"{DueDate.ToString("d").PadRight(15)}{Title.PadRight(20)}{Id.ToString().PadRight(5)}{Description.PadRight(31)}{TaskStatus.ToString().PadRight(10)}{TaskProject.Title.PadRight(25)}{TaskProject.Id}");
    }
  

}

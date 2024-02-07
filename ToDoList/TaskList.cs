
namespace ToDoList;

internal class TaskList
{
    public TaskList()
    {
        Tasks = new List<Task>();
        FileName = "myTasks.txt";
        fileHandling=new FileHandling(FileName);
    }


    public List<Task> Tasks {  get; set; }
    public string FileName { get; }
    public  FileHandling fileHandling { get;}
    

    public void LoadTaskList()
    {
        List<string> mySavedTasks=fileHandling.ReadFromFile();
    }

    public void ShowTaskList()
    {
        WriteLine("Your tasks: ");
        foreach (Task task in Tasks) 
        {
            Console.Write("#");
            task.PrintTask();
           
        }
    }
    public void AddNewTask()
    {
        int taskId = 1;
        if (Tasks.Count > 0)
        {
            taskId = Tasks.Max(task => task.TaskId) + 1;
        }
        Status taskStatus= Status.Planned;
        DateTime dueDate= DateTime.Now;
        string taskTitle = "TestTask";
        int projectId = 1;
        Tasks.Add(new Task(taskId,taskTitle,dueDate,taskStatus,projectId));

    }
    public void EditTask()
    {

    }
    public void SaveTaskList()
    {

    }
    
}

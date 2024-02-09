
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
    public string FileName { get; set; }
    public  FileHandling fileHandling { get;}
    

    

    public void ShowTasks()
    {
        WriteLine("Your tasks: ");
        WriteLine("Id".PadRight(20)+"Title".PadRight(20)+"DueDate".PadRight(20)+"Status".PadRight(20)+"ProjectId");
        foreach (Task task in Tasks) 
        {
            task.PrintTask();
           
        }
    }
    public void AddNewTasks(ProjectList projects)
    {
        while(true) 
        {
            projects.ShowProjects();
            Console.WriteLine("Add a new task, write q when you are done");
            Write("Title: ");
            string taskTitle = ReadLine();
            if (taskTitle.ToLower().Trim()== "q") 
            {
                break;
            }
            int taskId = 1;
            if (Tasks.Count > 0)
            {
                taskId = Tasks.Max(task => task.TaskId) + 1;
            }
            Status status = 0;
            int statusInt = 0;
            Write("Status (1.Planned 2.Ongoing 3.Finished): ");
            string statusString = ReadLine();
            Int32.TryParse(statusString, out statusInt);
            if (statusInt > 0) 
            {
                status=(Status)statusInt; 
            }
            Write("DueDate: ");
            DateTime dueDate= DateTime.Now;
            string dateString = ReadLine();
            DateTime.TryParse(dateString, out dueDate);
            
            int projectId = 1;
            Write("Projectid(choose id from the list above): ");
            string projectIdString = ReadLine();
            bool exists=false;
            if(!Int32.TryParse(projectIdString , out projectId))
            {
                ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Id has to be an integer");
                Console.WriteLine("The task could not be added"); 
                ResetColor();
            }
           
            else if (!(projects.ProjectExists(projectId)))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your projectlist");
                Console.WriteLine("The task could not be added");
                ResetColor() ;
            }
            else
            {
                Tasks.Add(new Task(taskId, taskTitle, dueDate, status, projectId));
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The task was succesfully added");
                ResetColor();
            }
            

        }
    }
    public void TaskInfo()
    {
        int todo = Tasks.Where(task => (task.TaskStatus == Status.Ongoing)).Count();
        int tasksDone= Tasks.Where(task => (task.TaskStatus == Status.Finished)).Count();
        int planned = Tasks.Count() - todo - tasksDone;
        WriteLine($"You have {todo} tasks and {tasksDone} is finished. There are {planned} tasks not yet started." );
    }
    public void EditTasks()
    {

    }
    public void LoadTaskList()
    {
        List<string> mySavedTasks = fileHandling.ReadFromFile();
     
        StringListToTaskList(mySavedTasks);
        
    }
    public void SaveTaskList()
    {
        FileHandling fileHandling = new FileHandling(FileName);
        List<string> tasksToSave = TaskListToStrings();
        fileHandling.SaveToFile(tasksToSave);
        
    }
    public List<string> TaskListToStrings()
    {

        List<string> taskListToString = new List<string>();
        foreach (Task task in Tasks)
        {
            taskListToString.Add(task.TaskToString());
        }
        return taskListToString;
    }
    public void StringListToTaskList(List<string> list)
    {
        foreach (string taskString in list)
        {
            Task task = new Task();
            task = task.TaskFromString(taskString);
            Tasks.Add(task);
        }
    }

}


namespace ToDoList;

public class Tasks:ILists
{
    public Tasks()
    {
        List<Task> TaskList = new List<Task>();
        NameOfFile = "myTasks.txt";
        fileHandling=new FileHandling(NameOfFile);
    }


    public List<Task> TaskList {  get; set; }
    public string NameOfFile { get; set; }
    public  FileHandling fileHandling { get;}
    

    

    public void Show()
    {
        WriteLine("Your tasks: ");
        WriteLine("Id".PadRight(20)+"Title".PadRight(20)+"DueDate".PadRight(20)+"Status".PadRight(20)+"ProjectId");
        foreach (Task task in TaskList) 
        {
            task.PrintTask();
           
        }
    }
    
    public void TaskInfo()
    {
        int todo = TaskList.Where(task => (task.TaskStatus == Status.Ongoing)).Count();
        int tasksDone= TaskList.Where(task => (task.TaskStatus == Status.Finished)).Count();
        int planed = TaskList.Count() - todo - tasksDone;
        WriteLine($"You have {todo} tasks and {tasksDone} is finished. There are {planed} tasks not yet started." );
    }
    public void AddNewTasks(Projects projects)
    {
        while (true)
        {
            Show();
            Console.WriteLine("Add a new task, write q when you are done");
            Write("Title: ");
            string taskTitle = ReadLine();
            if (taskTitle.ToLower().Trim() == "q")
            {
                break;
            }
            Write("Description: ");
            string description = ReadLine();
            int taskId = 1;
            if (TaskList.Count > 0)
            {
                taskId = TaskList.Max(task => task.TaskId) + 1;
            }
            Status status = 0;
            int statusInt = 0;
            Write("Status (1.Planned 2.Ongoing 3.Finished): ");
            string statusString = ReadLine();
            Int32.TryParse(statusString, out statusInt);
            if (statusInt > 0)
            {
                status = (Status)statusInt;
            }
            Write("DueDate: ");
            DateTime dueDate = DateTime.Now;
            string dateString = ReadLine();
            DateTime.TryParse(dateString, out dueDate);

            int projectId = 1;
            Write("Projectid(choose id from the list above): ");
            string projectIdString = ReadLine();
            bool exists = false;
            if (!Int32.TryParse(projectIdString, out projectId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id has to be an integer");
                Console.WriteLine("The task could not be added");
                ResetColor();
            }

            else if (!(projects.ProjectExists(projectId)))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your projectlist");
                Console.WriteLine("The task could not be added");
                ResetColor();
            }
            else
            {
                TaskList.Add(new Task(taskId, taskTitle, dueDate, status, projectId, description));
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The task was succesfully added");
                ResetColor();
            }
        }
    }
    public void EditTasks()
    {
        
    }
    public void MarkAsDone()
    {

    }
    public void RemoveTasks()
    {

    }

    public void SaveToFile()
    {
        //Converts the Projects in list of Projects to strings, adds them to a list of strings and writes them to the file.
        List<string> taskToSave = new List<string>();
        foreach (Task task in TaskList)
        {
            if (task.TaskTitle.Length > 0)
            {
                taskToSave.Add(task.TaskToString());
            }
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(taskToSave);
    }

    public void GetFromFile()
    {
        FileHandling fileData = new FileHandling(NameOfFile);
        List<string> savedTasks = fileData.ReadFromFile();
        foreach (string taskString in savedTasks)
        {
            Task savedTask = new Task();
            TaskList.Add(savedTask.TaskFromString(taskString));
        }

    }
    public List<string> TaskListToStrings()
    {

        List<string> taskListToString = new List<string>();
        foreach (Task task in TaskList)
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
            TaskList.Add(task);
        }
    }

}

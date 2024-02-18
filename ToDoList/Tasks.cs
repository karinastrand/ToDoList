
namespace ToDoList;

public class Tasks
{
    
    public Tasks(string nameOfFile) 
    {
        NameOfFile = nameOfFile;
    }

    public Tasks()
    {
        NameOfFile = "tasks.txt";
    }

    public List<Task> TasksList { get; set; } = new List<Task>();
   
    public string NameOfFile { get; set; } 
    public void TaskInfo()
    {
        int todo = TasksList.Where(task => (task.TaskStatus == Status.Ongoing)).Count();
        int tasksDone= TasksList.Where(task => (task.TaskStatus == Status.Finished)).Count();
        int planed = TasksList.Count() - todo - tasksDone;
        WriteLine($"You have {todo} tasks and {tasksDone} is finished. There are {planed} tasks not yet started." );
    }
    public void GetFromFile()
    {
        //Fetches strings from the file of stored tasks and convert the strings to Task objects.
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> savedTasks = fileHandling.ReadFromFile();
        foreach (string taskString in savedTasks)
        {
            Task savedTask = new Task();
            TasksList.Add(savedTask.ItemFromString(taskString));
        }
    }
    public  void AddNewTasks(Projects projects)
    {
        
        while (true)
        {
            Show();
            Console.WriteLine("Add a new task, write q when you are done");
            Write("Title: ");
            string taskTitle = ReadLine();
            if (taskTitle.ToLower().Trim() == "q")
            {
                SaveToFile();
                break;
            }
            Write("Description: ");
            string description = ReadLine();
            int taskId = 1;
            if (TasksList.Count > 0)
            {
                taskId = TasksList.Max(task => task.Id) + 1;
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
            projects.Show();
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

            else if (!projects.ProjectExists(projectId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your projectlist");
                Console.WriteLine("The task could not be added");
                ResetColor();
            }
            else
            {
                TasksList.Add(new Task(taskId, taskTitle, description, dueDate, status, projectId));
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The task was succesfully added");
                ResetColor();
            }
        }
    }
    public  void RemoveItems()
    {

    }
    public  void TasksInfo()
    {
        int todo = TasksList.Where(item => ((Task)item).TaskStatus == Status.Ongoing).Count();
        int tasksDone = TasksList.Where(item => ((Task)item).TaskStatus == Status.Finished).Count();
        int planed = TasksList.Count() - todo - tasksDone;
    }
    public void Show()
    {
        Projects projects = new Projects("projects.txt");
        projects.GetFromFile();
        WriteLine("Id".PadRight(5) + "Title".PadRight(15) + "Description".PadRight(20)+"Due Date".PadRight(15)+"Status".PadRight(10)+"Project Id".PadRight(15)+ "Project Title");
        foreach (Task task in TasksList)
        {
            int projectId = task.ProjectId;
            Project project = projects.ProjectFromId(projectId);
            Write(task.Print());
            WriteLine($"{project.Title}");
        }
    }

    

    public  void SaveToFile()
    //Converts the Task Objects to a list of strings and saves the string list to the file.
    {
        List<string> tasksToSave = new List<string>();
        foreach (Task task in TasksList)
        {
            tasksToSave.Add(task.ItemToString());
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(tasksToSave);
    }
}

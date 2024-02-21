using System.Threading.Tasks;

namespace ToDoList;
public class Tasks:Lists
{//Contains a list of Tasks and name of the file where it i is stored, the base class takes care of the file handling
  
    public List<Task> TasksList { get; set; } = new List<Task>();
    public Tasks(string nameOfFile) : base(nameOfFile)
    {
    }
    public void GetFromString()
    {//Fetches strings from the file of stored tasks and convert the strings to Task objects. 
        //Base class fetches a list of strings from a file
        List<string> savedTasks = GetFromFile(NameOfFile);
        try
        {//Converting strings to Tasks and puts them in the list of Tasks
            foreach (string taskString in savedTasks)
            {
                Task savedTask = new Task();
                TasksList.Add(savedTask.ItemFromString(taskString));
            }
        }
        catch (NullReferenceException)
        {
            Messages.SomethingWentWrong();
        }      
    }
    public void TasksToStringList()
    {    //Converts the Task Objects to a list of strings and saves the string list to the file.
        if (TasksList.Count > 0) 
        {
            List<string> tasksToSave = new List<string>();
            foreach (Task task in TasksList)
            {
                if (task.Id>0)
                {
                    tasksToSave.Add(task.ItemToString());
                }
            }
            SaveToFile(tasksToSave,NameOfFile);//Base class takes care of saving to file
        }
    }
    public void ShowTasks()
    {//Prints the TaskList to the console sorted by DueDate
        try
        {
            List<Task> tasksSortedByDate = TasksList.OrderBy(task => task.DueDate).ToList();
            WriteLine("My tasks");
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Due Date".PadRight(15) +"Title".PadRight(20)+"Id".PadRight(5) + "Description".PadRight(31) + "Status".PadRight(10) + "Project Title".PadRight(25) + "Project Id");
            ResetColor();
            foreach (Task task in tasksSortedByDate)
            {
                if (task.TaskStatus == Status.ToDo)//if Task has status done the foreground color will be default color
                {
                    ForegroundColor = Functions.SetColor(task.DueDate,5,20);//The color depends on how many days it is to DueDate, <5:red, <20 and >5 yellow else green
                }
                WriteLine(task.Print());
                ResetColor();
            }
        }
        catch (NullReferenceException)
        {
            Messages.SomethingWentWrong();  
        }
    }
    public void ShowTasksSortedByProject()
    {//Prints the TaskList to the console sorted by ProjectName and then DueDate
        try
        {
            List<Task> tasksSortedByProject = TasksList.OrderBy(task => task.TaskProject.Title).ThenBy(task => task.DueDate).ToList();
            WriteLine("My tasks sorted by project title");
            ForegroundColor=ConsoleColor.DarkYellow;
            WriteLine("Due Date".PadRight(15) + "Title".PadRight(20) + "Id".PadRight(5) + "Description".PadRight(31) + "Status".PadRight(10) + "Project Title".PadRight(25) + "Project Id");
            ResetColor();
            foreach (Task task in tasksSortedByProject)
            {
                if (task.TaskStatus == Status.ToDo)
                {
                    ForegroundColor = Functions.SetColor(task.DueDate, 5, 20);
                }
                WriteLine(task.Print());
                ResetColor();
            }
        }
        catch (NullReferenceException)
        {
            Messages.SomethingWentWrong();
        }
    }
    public void TaskInfo()
    {//Info displayed when the program starts.
        int todo = TasksList.Where(task => (task.TaskStatus == Status.ToDo)).Count(); //Tasks with status todo
        int tasksDone = TasksList.Where(task => (task.TaskStatus == Status.Done)).Count();//Total number of Tasks
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine($"You have {todo} tasks to do and {tasksDone} tasks are finished.");
        ResetColor();
    }
    public void AddNewTasks(Projects projects)
    { //Adding new Tasks until the user writes 'q'      
        while (true)
        {
            ShowTasks();
            Console.WriteLine("Add a new task, write q when you are done");
            Write("Title: ");
            string taskTitle = ReadLine();
            if (taskTitle.ToLower().Trim() == "q")
            {
                break;
            }
            Write("Description (max 30 characters) : ");
            string description = ReadLine();
            if (description.Length > 30)
            {
                description = description.Substring(30);
            }
            int taskId = 1;
            if (TasksList.Count > 0)
            {
                taskId = TasksList.Max(task => task.Id) + 1;
            }
            
            Write("DueDate (On the format 'yyyy-mm-dd') : ");
            DateTime dueDate = DateTime.Now;
            string dateString = ReadLine();
            try
            {
                dueDate=Convert.ToDateTime(dateString);
            }
            catch (FormatException)
            {
                Messages.NotADate();
            }
            int projectId = 1;
            projects.ShowProjects(this);
            Write("Projectid(chose id from the list above): ");
            string projectIdString = ReadLine();
            try
            {//Checks if the input is convertable to an int and if there is a Project with that id in the ProjectList
                projectId=Convert.ToInt32(projectIdString);
                if (!Functions.ProjectExists(projects,projectId))
                {
                    Messages.NotInList();
                }
                else
                {//if everything is ok the Task is created and added to the TaskList
                    Project taskProject=Functions.GetProject(projectId,projects.ProjectsList); //fetches the Project from the ProjectList
                    TasksList.Add(new Task(taskId, taskTitle, description, dueDate, Status.ToDo, taskProject));
                    Messages.Success("The Task was succesfully added!");
                }
            }
            catch (FormatException)
            {
                Messages.NotANumber();
            } 
        }
    }
    private Task TaskToEdit(string message)
    {//Which project is going to be edited?
        ShowTasks();
        Write($"{message}: ");
        string taskIdString = ReadLine();
        int taskId = 0;
        int index = -1;
        Task taskToEdit = new Task();
        try
        {//check if ther is a project with that id in the ProjectList
            taskId = Convert.ToInt32(taskIdString);
            if (!Functions.TasksExists(this,taskId)) //Not in the ProjectList
            {
                Messages.NotInList();
                
            }
            else
            {//If the projectId was found in the list it is possible to edit it.
                index = TasksList.FindIndex(task => task.Id == taskId); //the index of the Task the user wants to edit
            }
        }
        catch (FormatException)//the user wrote a projectid which couldn't be converted to an integer
        {
            Messages.NotANumber();
            
        }
        if (index > -1)
        {
            taskToEdit = Functions.GetTask(taskId,TasksList);
        }
        return taskToEdit;
    }   
    public void ChangeTitle()
    {
        ShowTasks();
        Task taskToEdit = TaskToEdit("On which task to you want to change title (write id)?");
        if(taskToEdit.Id>0) 
        {
            WriteLine($"Old title: {taskToEdit.Title}");
            Write("New title: ");
            string title = ReadLine();
            taskToEdit.Title = title;
            Messages.Success("The title was successfully changed");
        }    
    }
    public void ChangeDescription()
    {
        ShowTasks();
        Task taskToEdit = TaskToEdit("On which task to you want to change description (write id)?");
        if (taskToEdit.Id > 0)
        {
            WriteLine($"Old description: {taskToEdit.Description}");
            Write("New description (max 30 characters) : ");
            string description = ReadLine();
            taskToEdit.Description = description;
            if (description.Length > 30)
            {
                description = description.Substring(30);
            }
            Messages.Success("The description was successfully changed");
        }
    }
    public void ChangeDueDate()
    {
        ShowTasks();
        Task taskToEdit = TaskToEdit("On which task to you want to change due date (write id)?");
        if (taskToEdit.Id > 0)
        {
            WriteLine($"Old due date: {DateOnly.FromDateTime(taskToEdit.DueDate)}");
            Write("New date: ");
            DateTime newDueDate;
            string dateString = ReadLine();
            try
            {
                newDueDate = Convert.ToDateTime(dateString);
                taskToEdit.DueDate = newDueDate;
                Messages.Success("The due date was successfully changed");
            }
            catch (Exception)
            {
                Messages.NotADate();
            }
        }
    }
    public void MarkAsDone()
    {//Change Status to Done
        ShowTasks();
        Task taskToEdit = TaskToEdit(("What task do you want to mark as done (Write id)?"));
        if (taskToEdit.Id > 0)
        {
            taskToEdit.TaskStatus = Status.Done;
        }
    }
    public void ChangeProject(Projects projects)
    {//Change which Project the Task belongs to
        ShowTasksSortedByProject();
        Task taskToEdit = TaskToEdit("Which task do you want to tie to another project (write id)?");
        if (taskToEdit.Id > 0)
        {
            projects.ShowProjects(this);
            WriteLine($"Old project: {taskToEdit.TaskProject.Id}: {taskToEdit.TaskProject.Title}");
            Write("New project: ");
            int projectId = 0;
            string idString = ReadLine();

            try
            {
                projectId = Convert.ToInt32(idString);

                if (!Functions.ProjectExists(projects, projectId))
                {
                    Messages.NotInList();
                }
                else
                {
                    taskToEdit.TaskProject = Functions.GetProject(projectId, projects.ProjectsList);
                    Messages.Success("Success! The task has a new project");
                }
            }
            catch (Exception)
            {
                Messages.NotANumber();
            }
        }
    }
    public void RemoveTasks()
    {
        ShowTasks();
        Task taskToRemove = TaskToEdit("What task do you want to remove (write id)?");
        if (taskToRemove.Id > 0)
        {
            if (TasksList.Remove(taskToRemove))
            {
                Messages.Success("The task was removed");
            }
            else
            {
                Messages.SomethingWentWrong();
            }
        }
    }
}

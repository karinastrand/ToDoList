
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

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
        int todo = TasksList.Where(task => (task.TaskStatus == Status.ToDo)).Count();
        int tasksDone= TasksList.Where(task => (task.TaskStatus == Status.Done)).Count();
        WriteLine($"You have {todo} tasks to do and {tasksDone} tasks are finished.");
    }
    public void GetFromFile()
    {
        //Fetches strings from the file of stored tasks and convert the strings to Task objects.
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> savedTasks = fileHandling.ReadFromFile();
        try
        {
            foreach (string taskString in savedTasks)
            {
                Task savedTask = new Task();
                TasksList.Add(savedTask.ItemFromString(taskString));
            }
        }
        catch (Exception)
        {
            WriteLine("Couldn't read from the file");
        }
        
    }
    public void SaveToFile()
    //Converts the Task Objects to a list of strings and saves the string list to the file.
    {
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
            FileHandling fileHandling = new FileHandling(NameOfFile);
            fileHandling.SaveToFile(tasksToSave);
        }
        
    }

    public void Show()
    {
        try
        {
            List<Task> tasksSortedByDate = TasksList.OrderBy(task => task.DueDate).ToList();
            WriteLine("Due Date".PadRight(15) +"Title".PadRight(20)+"Id".PadRight(5) + "Description".PadRight(25) + "Status".PadRight(10) + "Project Title".PadRight(25) + "Project Id");
            foreach (Task task in tasksSortedByDate)
            {
                if (task.TaskStatus == Status.ToDo)
                {
                    ForegroundColor = TaskColor(task.DueDate);
                }
                WriteLine(task.Print());
                ResetColor();

            }
        }
        catch (NullReferenceException)
        {

            
        }
       
    }
    public void ShowTasksSortedByProject()
    {
        try
        {
            List<Task> tasksSortedByProject = TasksList.OrderBy(task => task.TaskProject.Title).ThenBy(task => task.DueDate).ToList();

            WriteLine("Due Date".PadRight(15) + "Title".PadRight(20) + "Id".PadRight(5) +  "Description".PadRight(25) + "Status".PadRight(10) + "Project Title".PadRight(25) + "Project Id");
            foreach (Task task in tasksSortedByProject)
            {
                if (task.TaskStatus==Status.ToDo)
                {
                    ForegroundColor = TaskColor(task.DueDate);
                }
                WriteLine(task.Print());
                ResetColor();

            }
        }
        catch (NullReferenceException)
        {

          
        }
        
    }
    public bool TaskExists(int id)
    {
        return TasksList.Exists(task => task.Id == id);
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
                break;
            }
            Write("Description: ");
            string description = ReadLine();
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
                ForegroundColor=ConsoleColor.Red;
                WriteLine("You have to enter a date on the format 'yyyy-mm-dd' for example '2024-05-11'");
                ResetColor();
                break;
            }
            

            int projectId = 1;
            projects.Show(this);
            Write("Projectid(chose id from the list above): ");
            string projectIdString = ReadLine();
            bool exists = false;
            try
            {
                projectId=Convert.ToInt32(projectIdString);
                if (!projects.ProjectExists(projectId))
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no such id in your projectlist");
                    Console.WriteLine("The task could not be added");
                    ResetColor();
                }
                else
                {
                    Project taskProject = new Project();
                    taskProject=GetTaskProject(projectId,projects);
                    TasksList.Add(new Task(taskId, taskTitle, description, dueDate, Status.ToDo, taskProject));
                    ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The task was succesfully added");
                    ResetColor();
                }
            }
            catch (FormatException)
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id has to be an integer");
                Console.WriteLine("The task could not be added");
                ResetColor();
                break;
            }
            

            
        }
    } 
    public void EditTasks(Projects projects)
    {
        Show();
        Write("What task do you want to edit? (Choose from the list above and write it's id: ");
        string taskIdString = ReadLine();
        int taskId = 0;
        try
        {
            taskId = Convert.ToInt32(taskIdString);
            if (!TaskExists(taskId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your tasklist");
                Console.WriteLine("The task could not be edited");
                ResetColor();
            }
            else
            {
                int index = TasksList.FindIndex(task => task.Id == taskId);
                while(true)
                {
                    Show();
                    WriteLine("What do you want to change, write 'q' when you are ready (write an integer from the list) :");
                    WriteLine("1. Title");
                    WriteLine("2. Description");
                    WriteLine("3. Due Date");
                    WriteLine("4. Tie to another project");
                    WriteLine("5. Quit");

                    string answer = ReadLine();
                    if(answer.ToLower().Trim() =="5")
                    {
                        break;
                    }
                    int answerIndex = 0;
                    try
                    {
                        answerIndex = Convert.ToInt32(answer);
                        switch (answerIndex) 
                        {
                            case 1:
                                {
                                    ChangeTitle(index);
                                    break;
                                }
                            case 2:
                                {
                                    ChangeDescription(index);
                                    break;
                                }
                            case 3:
                                {
                                    ChangeDueDate(index);
                                    break;
                                }
                            case 4:
                                {
                                    TieToAnotherProject(index,projects);
                                    break;
                                }
                            default: 
                                {
                                    ForegroundColor=ConsoleColor.Red;
                                    Console.WriteLine("You have to choose a number from the list");
                                    ResetColor();
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        ForegroundColor=ConsoleColor.Red;
                        WriteLine("You have to write a number from the list");
                        ResetColor();
                    }
                }

            }
        }
        catch (FormatException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id has to be an integer");
            Console.WriteLine("The task could not be changed");
            ResetColor();
        }
    }
    public void MarkAsDone(Projects projects)
    {
        Show();
        Write("What task do you want to mark as done? (Choose from the list above and write it's id: ");
        string taskIdString= ReadLine();
        int taskId = 0;
        try
        {
            taskId = Convert.ToInt32(taskIdString);
            if (!TaskExists(taskId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your tasklist");
                Console.WriteLine("The task could not be changed");
                ResetColor();
            }
            else
            {
                int index = TasksList.FindIndex(task=>task.Id== taskId);
                TasksList[index].TaskStatus= Status.Done;
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The task was succesfully changed");
                ResetColor();
            }
        }
        catch (FormatException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id has to be an integer");
            Console.WriteLine("The task could not be changed");
            ResetColor();
        }
    }
    public  void RemoveTasks(Projects projects)
    {
        Show();
        Write("What task do you want to remove? (Choose from the list above and write it's id: ");
        string taskIdString = ReadLine();
        int taskId = 0;
        try
        {
            taskId = Convert.ToInt32(taskIdString);
            if (!TaskExists(taskId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your tasklist");
                Console.WriteLine("The task could not be removed");
                ResetColor();
            }
            else
            {
                int index = TasksList.FindIndex(task => task.Id == taskId);
                if(TasksList.Remove(TasksList[index]))
                {
                    ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The task was succesfully removed");
                    ResetColor();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The task could not be removed");
                    ResetColor();
                }
               
            }
        }
        catch (FormatException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Id has to be an integer");
            Console.WriteLine("The task could not be removed");
            ResetColor();
        }
    }
    
    

   

    public void ChangeTitle(int index)
    {
        WriteLine($"Old title: {TasksList[index].Title}");
        Write("New title: ");
        string title=ReadLine();
        TasksList[index].Title = title;
        ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The title is successfully changed");
        ResetColor();
    }
    public void ChangeDescription(int index)
    {
        WriteLine($"Old description: {TasksList[index].Description}");
        Write("New description: ");
        string description = ReadLine();
        TasksList[index].Description = description;
        ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The description is successfully changed");
        ResetColor();
    }
    public void ChangeDueDate(int index)
    {
        WriteLine($"Old due date: {DateOnly.FromDateTime(TasksList[index].DueDate)}");
        Write("New date: ");
        DateTime newDueDate;
        string dateString = ReadLine();
        
        try
        {
            newDueDate=Convert.ToDateTime(dateString);
            TasksList[index].DueDate = newDueDate;
            ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The date is successfully changed");
            ResetColor();
        }
        catch (Exception)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("You have to write a date in the format yyyy-mm-dd (for example 2024-03-27)");
            ResetColor();
        }
    }
    public void TieToAnotherProject(int index, Projects projects)
    {
        projects.Show(this);
        WriteLine($"Old project: {TasksList[index].TaskProject.Id}");
        Write("New project: ");
        int projectId = 0;
        string idString = ReadLine();

        try
        {
            projectId = Convert.ToInt32(idString);
           
            if (!projects.ProjectExists(projectId))
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such id in your projectlist");
                Console.WriteLine("The task could not be tied to that project");
                ResetColor();
            }
            TasksList[index].TaskProject = GetTaskProject(projectId,projects);
            ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The task is now successfully tied to a new project");
            ResetColor();
        }
        catch (Exception)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("You have to write an integer from the list of projects");
            ResetColor();
        }
    }
    public Project GetTaskProject(int projectId,Projects projects)
    {
        Project taskProject = new Project();
        return taskProject = projects.ProjectsList.Where(project => project.Id == projectId).FirstOrDefault();

    }
    public ConsoleColor TaskColor(DateTime dueDate)
    {
        ConsoleColor color = ConsoleColor.DarkBlue;
        TimeSpan diff=(dueDate-DateTime.Now);
        int days = diff.Days;
        if (days < 5)
        {
            color = ConsoleColor.Red;
        }
        else if (days<20)
        {
            color = ConsoleColor.DarkYellow;
        }
        else
        {
            color = ConsoleColor.Green;
        }

        return color;
    }
}

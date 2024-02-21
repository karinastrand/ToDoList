namespace ToDoList;
public static class Functions
{//Helpers
    public static Project GetProject(int projectId, List<Project> projects)
    {//returns the Project with the id=projectId
        Project project = new Project();
        return project = projects.Where(project => project.Id == projectId).FirstOrDefault();
    }
    public static Task GetTask(int taskId, List<Task> tasks)
    {//returns the Task with the id=taskId
        Task task = new Task();
        return task = tasks.Where(task => task.Id == taskId).FirstOrDefault();
    }
    public static ConsoleColor SetColor(DateTime date, int numberOfDays, int numberOfDays2 = 0)//numberOfDays2 is default=0 so not necessary
    {//returns color depending on how many days a date is from today
        ConsoleColor color;
        TimeSpan diff = (date - DateTime.Now);
        int days = diff.Days;
        if (days < numberOfDays)//Color is red if the date is less than numberOfDays away
        {
            color = ConsoleColor.Red;
        }
        else if (numberOfDays2 > 0 && days < numberOfDays2)//Color is yellow if the date is less than numberOfDays2 away
        {
            color = ConsoleColor.DarkYellow;
        }
        else
        {
            color = ConsoleColor.Green;
        }
        return color;
    }
    public static int NumberOfTasks(int id, Tasks tasks)
    {//returns the number of Tasks a project has
        int numberOfTasks = 0;
        try
        {
            numberOfTasks = tasks.TasksList.Where(task => task.TaskProject.Id == id).Count();
        }
        catch (NullReferenceException)
        {
            Messages.SomethingWentWrong();
        }
        return numberOfTasks;
    }
    public static void EditProjectTitle(int projectId,string title, Tasks tasks)
    {//If the Project has been changed the projects in Tasks has to be changed too
        foreach (Task task in tasks.TasksList) 
        {
            if(task.TaskProject.Id==projectId)           
            {
                task.TaskProject.Title = title;
            } 
        }
    }
    public static void EditProjectDescription(int projectId, string description, Tasks tasks)
    {//If the Project has been changed the projects in Tasks has to be changed too
        foreach (Task task in tasks.TasksList)
        {
            if (task.TaskProject.Id == projectId)
            {
                task.TaskProject.Description = description;
            }
        }
    }
    public static bool ProjectExists(Projects projects, int id)
    {//returns true if the inputted id is an Id in the ProjectList
        return projects.ProjectsList.Exists(project => project.Id == id);
    }
    public static bool TasksExists(Tasks tasks, int id)
    {//returns true if the inputted id is an Id in the ProjectList
        return tasks.TasksList.Exists(task => task.Id == id);
    }
}




namespace ToDoList;

public class Projects 
{
    
    public Projects(string nameOfFile)
    {
        NameOfFile = nameOfFile;
    }

    public Projects()
    {
        NameOfFile = "projects.txt";
    }

    public List<Project> ProjectsList { get; set; } = new List<Project>();
    public string NameOfFile { get; set; } = "projects.txt";
    public void AddNewItems()
    {

        int id = 1;
        while (true)
        {
            Console.WriteLine("Add new projects, exit with 'q'");
            WriteLine("Title: ");
            string title = ReadLine();
            if (title.ToLower().Trim() == "q")
            {
                break;
            }
            WriteLine("Description:");
            string description = ReadLine();


            if (ProjectsList.Count > 0)
            {
                id = ProjectsList.Max(item => item.Id) + 1;
            }
            Project newProject = new Project(id, title, description);
            ProjectsList.Add(newProject);

        }

    }
    public void EditProjects()
    {

    }
    public  void RemoveProjects()
    {

    }


    public void GetFromFile()
    {
        //Fetches strings from the file of stored projects and convert the strings to Project objects.
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> savedProjects = fileHandling.ReadFromFile();
        foreach (string projectString in savedProjects)
        {
            Project savedProject = new Project();
            ProjectsList.Add(savedProject.ItemFromString(projectString));
        }
    }

    public  void SaveToFile()
    //Converts the Project Objects to a list of strings and saves the string list to the file.
    {
        List<string> projectsToSave = new List<string>();
        foreach (Project project in ProjectsList)
        {
            projectsToSave.Add(project.ItemToString());
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(projectsToSave);
    }

    public  void Show()
    {
        WriteLine("Id".PadRight(5)+"Title".PadRight(20)+"Description");
        foreach(Project project in ProjectsList) 
        {
            WriteLine(project.Print());
        }
    }

    public bool ProjectExists(int id)
    {
        return ProjectsList.Exists(project=>project.Id == id);
    }
    public Project ProjectFromId(int id)
    {
        Project project =ProjectsList.Where(project=>project.Id == id).FirstOrDefault();
        return project;
    }
}

namespace ToDoList;
public class Project
{//represents a Project and is the base class to Task
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description{ get; set;}
    public Project()
    {
    }
    public Project(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    public virtual string ItemToString()
    {//Returns a string that can be saved to a text file
        return $"{Id.ToString()},{Title},{Description}";
    }
    public virtual Project ItemFromString(string itemString)
    {//returns a Project created from a string (saved on a text file)
        Project itemFromString = new Project();
        int id = 0;
        try
        {//the saved string contains three parts separated with ','
            itemFromString.Id=Convert.ToInt32(itemString.Split(',')[0]);
            itemFromString.Title = itemString.Split(',')[1];
            itemFromString.Description = itemString.Split(',')[2];
        }
        catch (FormatException)
        {//something wrong with the string part that saves the int (id)
            ForegroundColor=ConsoleColor.Red;
            WriteLine("It wasn't possible to create a Project from the string due to format problems" );
            ResetColor();
        }
        catch(IndexOutOfRangeException)
        {//If the comma seperated parts of the string doesn't match what the Project constructor needs.
            ForegroundColor=ConsoleColor.Red;
            WriteLine("It wasn't possible to create a Project from the string due to problem with the string");
            ResetColor();
        }
        return itemFromString;
    }
    public virtual string Print()
    {//converts Projet to a string suitable to print on the console
        return $"{Id.ToString().PadRight(5)}{Title.PadRight(25)}{Description.PadRight(25)}";
    }
   
}

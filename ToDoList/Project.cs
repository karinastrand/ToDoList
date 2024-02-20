using ToDoList;

namespace ToDoList;
public class Project:Item
{//represents a Project and is subclass to Item
   
    public Project()
    {

    }

    public Project(int id, string title, string description) : base(id, title, description)
    {
    }

    public override Project ItemFromString(string itemString)
    {//returns a Project created from a string (saved on a text file)
        Project itemFromString = new Project();
        int id = 0;
        try
        {//the saved string contains three parts separated with ','
            itemFromString.Id = Convert.ToInt32(itemString.Split(',')[0]);
            itemFromString.Title = itemString.Split(',')[1];
            itemFromString.Description = itemString.Split(',')[2];
        }
        catch (FormatException)
        {//something wrong with the string part that saves the int (id)
            Messages.Error("It was not possible to make a Project form the string due to format problems");
        }
        catch (IndexOutOfRangeException)
        {//If the comma seperated parts of the string doesn't match what the Project constructor needs.
            Messages.Error("It was not possible to make a Project form the string due to problem with the string");
        }
        return itemFromString;
    }
}

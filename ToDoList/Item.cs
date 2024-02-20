namespace ToDoList;

public abstract class Item
{//base class for Project and Task
    public Item()
    {

    }
    public Item(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual string ItemToString()
    {//Returns a string that can be saved to a text file
        return $"{Id.ToString()},{Title},{Description}";
    }
    public abstract Item ItemFromString(string itemString); //Has to be implemented in the sub classes, creats an object
    public virtual string Print()
    {//converts Projet to a string suitable to print on the console
        return $"{Id.ToString().PadRight(5)}{Title.PadRight(25)}{Description.PadRight(31)}";
    }

}

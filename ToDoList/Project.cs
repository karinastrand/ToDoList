using System.Diagnostics;

namespace ToDoList;

public class Project
{
    public Project(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Project()
    {
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public  virtual void AddNewItem(List<Project> itemList)
    {

    }
    
    public virtual string ItemToString()
    {
        return $"{Id.ToString()},{Title},{Description}";

    }
    public virtual Project ItemFromString(string itemString)
    {
        Project itemFromString = new Project();
        int id = 0;
        Int32.TryParse(itemString.Split(',')[0], out id);
        itemFromString.Id = id;
        itemFromString.Title = itemString.Split(',')[1];
        itemFromString.Description = itemString.Split(',')[2];
        return itemFromString;
    }
    public virtual string Print()
    {
        return $"{Id.ToString().PadRight(5)}{Title.PadRight(20)}{Description}";

    }
    public virtual void AddNewItem()
    {

    }
    
    
}

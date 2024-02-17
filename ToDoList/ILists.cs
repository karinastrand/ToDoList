namespace ToDoList;
public interface ILists
{    //Interface for the different lists
    public string NameOfFile { get; set; }
    //Prints the list to the console
    public void Show();
    //Fetches the list from the file
    public void GetFromFile();
    //Saves the list to the file
    public void SaveToFile();
}

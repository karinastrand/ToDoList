namespace ToDoList;
public abstract class Lists
{//Base class for the different lists, takes care of the filehandling
    public string NameOfFile { get; set; }
    
    //Fetches the list from the file
    public List<string> GetFromFile(string nameOfFile)
    {
        List<string> savedItems = new List<string>();
        //Fetches strings from the file of stored projects and convert the strings to Project objects.
        FileHandling fileHandling = new FileHandling(nameOfFile);
        try
        {
            savedItems = fileHandling.ReadFromFile();
        }
        catch (NullReferenceException)
        {
        }
        return savedItems;
    }
    //Saves the list to the file
    public void SaveToFile(List<string> itemsToSave, string nameOfFile)
    {
        FileHandling fileHandling = new FileHandling(nameOfFile);
        fileHandling.SaveToFile(itemsToSave);
    }
   
}

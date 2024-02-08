

namespace ToDoList;

internal class FileHandling
{
    

    public FileHandling(string fileName)
    {
        FileName = fileName;
        Dir=Directory.GetCurrentDirectory();
    }

    public string FileName { get; set; }
    public string Dir { get; set; }

    
    public void SaveToFile(List<string> linesToSave)
    {
        string path = Path.Combine(Dir, FileName);
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists) 
        {
            fileInfo.Delete();
        }
        StreamWriter sw=fileInfo.CreateText();
     
     
        foreach (string line in linesToSave)
        {
           
            sw.WriteLine(line);
        }

        sw.Close();
    }

    public List<string> ReadFromFile()
    {
        string line = string.Empty;
        string path = Path.Combine(Dir, FileName);
        List<string> lines= new List<string>();
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists) 
        {
            StreamReader sr = new StreamReader(path);

            while ((line = sr.ReadLine()) is not null)
            {
                lines.Add(line);
            }
            sr.Close();
        }
        
        return lines;
    }

}

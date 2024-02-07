

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
        StreamWriter sw = new StreamWriter(path);
        foreach (string line in linesToSave)
        {
            sw.WriteLine(line);
        }

        sw.Close();
    }

    public List<string> ReadFromFile()
    {
        string path = Path.Combine(Dir, FileName);
        List<string> lines = new List<string>();

        StreamReader sr = new StreamReader(path);

        string line;

        while ((line = sr.ReadLine()) is not null)
        {
            lines.Add(line);
        }
        sr.Close();
        return lines;
    }

}

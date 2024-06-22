using System.ComponentModel;
using System.Diagnostics;

public class Journal
{
    private readonly List<string> entries = new List<string>();

    private static int count = 0;

    public int AddEntry(string text)
    {
        entries.Add($"{++count}: {text}");
        return count; //memento
    }

    public void RemoveEntry(int index)
    {
        entries.RemoveAt(index);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }

    //public void Save(string filename)
    //{
    //    File.WriteAllText(filename, ToString());
    //}

    //public static void Load(string filename)
    //{

    //}
}

public class Persistance
{
    public void SaveToFile(Journal j, string filename, bool overwrite = false)
    {
        if(overwrite || !File.Exists(filename))
            File.WriteAllText(filename, j.ToString());
    }

    public static void Load(string filename)
    {

    }
}
public class Demo
{
    static void Main(string[] args)
    {
        var j = new Journal();
        j.AddEntry("I write this line");
        j.AddEntry("I use the second line");
        Console.WriteLine(j);

        var p = new Persistance();
        var filename = @"D:\Github\Design Patterns\SOLID\journal.txt";
        p.SaveToFile(j, filename, true);
        // 创建一个 ProcessStartInfo 对象，指定文件路径
        ProcessStartInfo processStartInfo = new ProcessStartInfo
        {
            FileName = filename,
            UseShellExecute = true // 使用操作系统的 shell 来启动进程
        };

        try
        {
            // 启动进程
            Process.Start(processStartInfo);
            Console.WriteLine($"Successfully opened the file: {filename}");
        }
        catch (Win32Exception ex)
        {
            // 捕获并处理可能的异常
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}